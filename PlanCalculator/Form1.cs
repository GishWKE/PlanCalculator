namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Drawing.Printing;
using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	using BaseComponents;

	using CalculatorComponents;

	using Resource.Properties;

	public partial class Form1 : Form
	{
		[DefaultValue ( @".\Resources\DB.accdb" )]
		private readonly string FileName = @".\Resources\DB.accdb";
		private readonly List<Field> fields = new List<Field> ( );
		public Form1 ( )
		{
			InitializeComponent ( );
			Text.Clear ( );
			Devices.DeviceChanged += DeviceChanged;
			Devices.FileName = FileName;
			dateTitle.RunWorkerAsync ( );
		}
		private void Form1_FormClosing ( object sender, FormClosingEventArgs e ) => dateTitle.CloseAndWait ( );


		private void DateTitle_ProgressChanged ( object sender, ProgressChangedEventArgs e )
		{
			Text = ( ( DateTime ) e.UserState ).ToString ( "d" );
			Devices.FileName = FileName;
			Calculate ( );
		}

		private void DateTitle_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e ) => cToken.Cancel ( );

		private readonly CancellationTokenSource cToken = new CancellationTokenSource ( );
		private void DateTitle_DoWork ( object sender, DoWorkEventArgs e )
		{
			var bw = ( ( BackgroundWorker ) sender );
			var dateToday = DateTime.Now;
			bw.ReportProgress ( 0, dateToday );
			while ( !bw.CancellationPending )
			{
				var dateTomorrow = DateTime.Today.AddDays ( 1 );
				var diff = dateTomorrow - dateToday;
				cToken.CancelAfter ( diff );
				new Task ( ( ) => Thread.Sleep ( Timeout.Infinite ), cToken.Token ).Start ( );
				while ( !cToken.IsCancellationRequested )
				{
					if ( bw.CancellationPending )
					{
						return;
					}
				}
				dateToday = DateTime.Now;
				bw.ReportProgress ( 0, dateToday );
			}
		}

		private static readonly string regex_fmt = $"{RegEx.Begin}({RegEx.Values_0__9_9}|{{0}})?{RegEx.End}";

		private void DeviceChanged ( object sender, EventArgs e )
		{
			var sel = Devices.Selected;
			// var scd = sel [ "РИЦ" ].ToString ( ).ToInt(); // ППерестал работать cast object->int
			var scd = ( int ) sel [ "РИЦ" ];
			var sec = ( bool ) sel [ "Время в минутах" ];
			var regex_str = string.Empty;
			switch ( scd )
			{
				case var _ when scd >= 40 && scd <= 100 && scd % 10 == 0: // 40,50,60,70,80,90,100
					{
						regex_str = RegEx.Format_end0;
						break;
					}
				case var _ when scd >= 45 && scd <= 95 && scd % 10 == 5: // 45,55,65,75,85,95
					{
						regex_str = RegEx.Format_end5;
						break;
					}
				default:
					Distance.Regex.Clear ( );
					break;
			}
			if ( !regex_str.IsEmpty ( ) )
			{
				var tmp = scd / 10;
				var temp = string.Format ( regex_str, tmp - 1, tmp );
				Distance.Regex = string.Format ( regex_fmt, temp );
			}
			CalcSSD ( );
			foreach ( var f in fields )
			{
				f.IsInMinutes = sec;
				f.SCD = scd;
			}
		}
		private void Dose_Changed ( object sender, EventArgs e ) => Calculate ( );
		private void Calculate ( )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			foreach ( var f in fields )
			{
				Calculate ( f );
			}
			Cursor = tmp;
		}
		private void Calculate ( object fld )
		{
			if ( !( fld is Field ) )
			{
				return;
			}

			var f = fld as Field;
			f.Time = null;

			if ( new [ ] { D.Value, P.Value, f.Kb, f.OTV }.Any ( v => v == null ) || ( f.IsLung && f.L == null ) )
			{
				return;
			}

			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			var mult = new double [ ] { ( double ) D.Value, 100, 100, ( double ) N.Value };
			var div = new List<double> { ( double ) P.Value, ( double ) Devices.Selected [ "Мощность" ], ( double ) FieldsCount.Value, ( double ) f.Kb, ( double ) f.OTV };
			if ( f.IsLung )
			{
				div.Add ( ( double ) f.L );
			}

			if ( f.IsInMinutes )
			{
				div.Add ( 60 );
			}

			var Numerator = mult.AsParallel ( ).Aggregate ( 1D, ( aggregator, current ) => aggregator * current );
			var Divisor = div.AsParallel ( ).Aggregate ( 1D, ( aggregator, current ) => aggregator * current );
			f.Time = Numerator / Divisor;
			Cursor = tmp;
		}

		private void FieldCount_ValueChanged ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			var cnt = ( int ) FieldsCount.Value;
			if ( cnt == 0 )
			{
				AllFields.SuspendLayout ( );
				AllFields.Controls.Clear ( );
				fields.Clear ( );
				AllFields.ResumeLayout ( );
			}
			else if ( cnt < fields.Count )
			{
				AllFields.SuspendLayout ( );
				for ( var i = fields.Count - 1; i >= cnt; i-- )
				{
					AllFields.Controls.Remove ( fields [ i ] );
					fields.RemoveAt ( i );
				}
				AllFields.ResumeLayout ( );
				Calculate ( );
			}
			else
			{
				AllFields.SuspendLayout ( );
				var fld = new List<Field> ( );
				for ( var i = fields.Count; i < cnt; i++ )
				{
					var f = new Field
					{
						Text = $@"№{i + 1}:",
						Dock = DockStyle.Top,
						FileName = FileName,
						SCD = ( int ) Devices.SCD,
						A = ( int ) A.Value,
						B = ( int ) B.Value,
						IsInMinutes = ( bool ) Devices.Selected [ "Время в минутах" ]
					};
					f.RecalculationNeed += RecalculationNeed;
					fld.Add ( f );
				}
				fields.AddRange ( fld );
				AllFields.Controls.AddRange ( fld.ToArray ( ) );
				AllFields.ResumeLayout ( );
				Calculate ( );
			}
			Cursor = tmp;
		}

		private void RecalculationNeed ( object sender, EventArgs e ) => Calculate ( sender );

		private void AB_ValueChanged ( object sender, EventArgs e )
		{
			var obj = sender as NumericUpDown;
			var isA = obj.Name == "A";
			foreach ( var f in fields )
			{
				if ( isA )
				{
					f.A = ( int ) obj.Value;
				}
				else
				{
					f.B = ( int ) obj.Value;
				}
			}
		}
		private void Exit_Button_Click ( object sender, EventArgs e ) => Application.Exit ( );

		private void EditDevices_Click ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			if ( new EditDevices { FileName = FileName }.ShowDialog ( this ) == DialogResult.OK )
			{
				Devices.FileName = FileName;
				Calculate ( );
			}
			Cursor = tmp;
		}
		private void Distance_Leave ( object sender, EventArgs e ) => CalcSSD ( );
		private void CalcSSD ( )
		{
			var DST = Distance.Value;
			var SCD = Devices.SCD;
			SSD.Clear ( );
			if ( SSD == null || DST == null || SCD == null || DST > SCD )
			{
				return;
			}
			SSD.Value = SCD - DST;
		}

		private void добавлениеАппаратовToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			if ( new CreateDevice { FileName = FileName }.ShowDialog ( this ) == DialogResult.Yes )
			{
				Devices.FileName = FileName;
				Calculate ( );
			}
			Cursor = tmp;
		}

		private void оПрограммеToolStripMenuItem_Click ( object sender, EventArgs e ) => new AboutBox1 ( ).ShowDialog ( this );

		private void очиститьToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			FieldsCount.Value = 0;
			A.Value = 4;
			B.Value = 4;
			D.Value = null;
			Distance.Value = null;
			Devices.FileName = FileName;
		}

		private void просмотрМощностейToolStripMenuItem_Click ( object sender, EventArgs e ) => new PowerTable { FileName = FileName }.ShowDialog ( this );
		private void печататьToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			var sb = new StringBuilder ( );
			sb.AppendLine ( ( string ) Devices.Selected [ "Аппарат" ] );
			sb.Append ( "РИЦ = " );
			sb.Append ( ( int ) Devices.Selected [ "РИЦ" ] );
			sb.AppendLine ( " см" );
			sb.Append ( "P = " );
			sb.Append ( ( ( double ) Devices.Selected [ "Мощность" ] ).ToStringWithDecimalPlaces ( 2 ) );
			sb.AppendLine ( " сГр/с" );
			sb.Append ( "D (" );
			sb.Append ( P.Value );
			sb.Append ( "%) = " );
			sb.Append ( D.Value.ToStringWithDecimalPlaces ( 1 ) );
			sb.AppendLine ( " Гр" );
			sb.Append ( "N = " );
			sb.Append ( N.Value.ToString() );
			sb.Append ( "; n = " );
			sb.AppendLine ( FieldsCount.Value.ToString ( ) );
			var axb = new Func<dynamic, dynamic, string> ( ( A, B ) => $@"{A} x {B}" );
			var diff = true;
			if ( fields.Any ( ) && fields.All ( f => f.A.Value == A.Value && f.B.Value == B.Value ) )
			{
				diff = false;
				var ab = axb ( A.Value, B.Value );
				sb.Append ( "A x B = " );
				sb.AppendLine ( ab );
				sb.Append ( "Кб (" );
				sb.Append ( ab );
				sb.Append ( ") = " );
				sb.AppendLine ( fields [ 0 ].Kb.ToStringWithDecimalPlaces ( 3 ) );
			}
			sb.AppendLine ( );
			var sb_t = new StringBuilder ( );
			foreach ( var f in fields )
			{
				var fld = f.Text.Replace ( "№", string.Empty );
				if ( diff )
				{
					sb.Append ( "Поле " );
					sb.Append ( f.Text );
					sb.Append ( " " );
					var ab = axb ( f.A.Value, f.B.Value );
					sb.Append ( "A x B = " );
					sb.AppendLine ( ab );
					sb.Append ( "Кб" );
					sb.Append ( fld );
					sb.Append ( " (" );
					sb.Append ( ab );
					sb.Append ( ") = " );
					sb.Append ( f.Kb.ToStringWithDecimalPlaces ( 3 ) );
					sb.AppendLine ( "; " );
				}
				sb.Append ( "ОТВ" );
				sb.Append ( fld );
				sb.Append ( " (" );
				sb.Append ( f.Depth.ToStringWithDecimalPlaces ( 1 ) );
				sb.Append ( ") = " );
				sb.Append ( f.OTV.ToStringWithDecimalPlaces ( 3 ) );
				if ( f.IsLung )
				{
					sb.AppendLine ( ";" );
					sb.Append ( "L" );
					sb.Append ( fld );
					sb.Append ( " = " );
					sb.Append ( f.L.ToStringWithDecimalPlaces ( 3 ) );
				}
				sb.AppendLine ( );
				sb_t.Append ( "t" );
				sb_t.Append ( fld );
				sb_t.Append ( " = " );
				if ( f.IsInMinutes )
				{
					sb_t.Append ( f.Time.ToStringWithDecimalPlaces ( 2 ) );
					sb_t.AppendLine ( " минут" );
				}
				else
				{
					sb_t.Append ( f.Time.ToStringWithDecimalPlaces ( 1 ) );
					sb_t.AppendLine ( " секунд" );
				}
			}
			sb.AppendLine ( );
			sb.AppendLine ( sb_t.ToString ( ) );
			sb.AppendLine ( );
			sb.Append ( "РИП = " );
			sb.Append ( SSD.Value.ToStringWithDecimalPlaces ( 1 ) );
			sb.AppendLine ( " см" );
			sb.AppendLine ( );
			sb.AppendLine ( Text );
			sb.Append ( "инж.радиолог __________________" );
			printString = sb.ToString ( );
			printDocument1.DocumentName = DateTime.Now.ToString ( "G" );
			printPreviewDialog1.Document = printDocument1;
			try
			{
				printPreviewDialog1.ShowDialog ( this );
			}
			catch ( Exception ex )
			{
				throw new Exception ( "Exception Occured While Printing", ex );
			}
		}
		private string printString;
		private void printDocument1_PrintPage ( object sender, PrintPageEventArgs e )
		{
			e.Graphics.DrawString ( printString, new Font ( "Arial", 14 ), new SolidBrush ( Color.Black ), new RectangleF ( 0, 0, ( ( PrintDocument ) sender ).DefaultPageSettings.PrintableArea.Width, ( ( PrintDocument ) sender ).DefaultPageSettings.PrintableArea.Height ) );
		}
	}
}
