/*
  Copyright © 2021 Antipov Roman (https://github.com/GishWKE), Tsys' Alexandr (https://github.com/AlexTsys256)


   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
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

	public partial class MainForm : Form
	{
		[DefaultValue ( @".\Resources\DB.accdb" )]
		private readonly string FileName = @".\Resources\DB.accdb";
		private readonly List<Field> fields = new List<Field> ( );
		private void ClearFields ( )
		{
			_ = fields.AsParallel ( ).Select ( f => { f.Dispose ( ); return true; } );
			fields.Clear ( );
		}
		public MainForm ( )
		{
			InitializeComponent ( );
			ClearFields ( );
			Text.Clear ( );
			Devices.DeviceChanged += DeviceChanged;
			Devices.FileName = FileName;
			dateTitle.RunWorkerAsync ( );
		}
		private void Form1_FormClosing ( object sender, FormClosingEventArgs e ) => dateTitle.CloseAndWait ( );

		private void DateTitle_ProgressChanged ( object sender, ProgressChangedEventArgs e )
		{
			Text = ( ( DateTime ) e.UserState ).ToString ( Resources.DateFormat );
			Devices.FileName = FileName;
			Calculate ( );
		}

		private void DateTitle_RunWorkerCompleted ( object sender, RunWorkerCompletedEventArgs e ) => cToken.Cancel ( );

		private readonly CancellationTokenSource cToken = new CancellationTokenSource ( );
		private void DateTitle_DoWork ( object sender, DoWorkEventArgs e )
		{
			var bw = ( BackgroundWorker ) sender;
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
			Calculate ( );
		}
		private void Dose_Changed ( object sender, EventArgs e ) => Calculate ( );

		private void Calculate ( )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			Weight = WeightSumm ( );
			foreach ( var f in fields )
			{
				Calculate ( f );
			}
			Cursor = tmp;
		}
		private double? Weight = null;
		private double? WeightSumm ( )
		{
			if ( fields.IsEmpty ( ) )
			{
				return null;
			}
			var fld = fields.AsParallel ( );
			return fld.Any ( f => f.Weight == null ) ? null : ( double? ) fld.Select ( f => ( double ) f.Weight ).Sum ( );
		}
		private void Calculate ( object fld )
		{
			if ( !( fld is Field ) )
			{
				return;
			}

			var f = fld as Field;
			f.Time = null;

			if ( new double? [ ] { D, P, f.Kb, f.OTV, Weight }.Any ( v => v == null ) || f.IsLung && f.L == null )
			{
				return;
			}

			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			var mult = new [ ] { D, 100D, 100D, ( double ) f.Weight };
			var div = new List<double> { P, ( double ) Devices.Selected [ "Мощность" ], ( double ) Weight, ( double ) f.Kb, ( double ) f.OTV };
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
				ClearFields ( );
				AllFields.ResumeLayout ( );
			}
			else if ( cnt < fields.Count )
			{
				AllFields.SuspendLayout ( );
				for ( var i = fields.Count - 1; i >= cnt; i-- )
				{
					fields [ i ].RecalculationNeed -= RecalculationNeed;
					fields [ i ].TotalRecalculationNeed -= TotalRecalculationNeed;
					AllFields.Controls.Remove ( fields [ i ] );
					fields [ i ].Dispose ( );
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
						Weight = 1,
						Dock = DockStyle.Top,
						FileName = FileName,
						SCD = ( int ) Devices.SCD,
						A = ( int ) A.Value,
						B = ( int ) B.Value,
						IsInMinutes = ( bool ) Devices.Selected [ "Время в минутах" ]
					};
					f.RecalculationNeed += RecalculationNeed;
					f.TotalRecalculationNeed += TotalRecalculationNeed;
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
		private void TotalRecalculationNeed ( object sender, EventArgs e ) => Calculate ( );

		private void AB_ValueChanged ( object sender, EventArgs e )
		{
			var obj = sender as NumericUpDown;
			var isA = obj.Name == "A";
			var val = ( int ) obj.Value;
			foreach ( var f in fields )
			{
				if ( isA )
				{
					f.A = val;
				}
				else
				{
					f.B = val;
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

		private void оПрограммеToolStripMenuItem_Click ( object sender, EventArgs e ) => new AboutBox ( ).ShowDialog ( this );

		private void очиститьToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			FieldsCount.Value = 0;
			D.Value = null;
			A.Value = 4;
			B.Value = 4;
			Distance.Value = null;
			Devices.FileName = FileName;
			P.Value = 90;
		}

		private void просмотрМощностейToolStripMenuItem_Click ( object sender, EventArgs e ) => new PowerTable { FileName = FileName }.ShowDialog ( this );

		private string PreparePrintData ( )
		{

			var sb = new StringBuilder ( );
			_ = sb.AppendLine ( ( string ) Devices.Selected [ "Аппарат" ] );
			_ = sb.Append ( "РИЦ = " );
			_ = sb.Append ( ( int ) Devices.Selected [ "РИЦ" ] );
			_ = sb.AppendLine ( " см" );
			_ = sb.Append ( "P = " );
			_ = sb.Append ( ( ( double ) Devices.Selected [ "Мощность" ] ).ToStringWithDecimalPlaces ( 4 ) );
			_ = sb.AppendLine ( " сГр/с" );
			_ = sb.Append ( "D (" );
			_ = sb.Append ( P.Value );
			_ = sb.Append ( "%) = " );
			_ = sb.Append ( D.Value.ToStringWithDecimalPlaces ( 1 ) );
			_ = sb.AppendLine ( " Гр" );
			_ = sb.Append ( "N = " );
			_ = sb.Append ( N.Value.ToString ( ) );
			_ = sb.Append ( "; n = " );
			_ = sb.AppendLine ( FieldsCount.Value.ToString ( ) );
			var axb = new Func<dynamic, dynamic, string> ( ( A, B ) => $@"{A} x {B}" );
			var diff = true;
			var _axb = "A x B = ";
			var eq0 = " = ";
			var eq = $@"){eq0}";
			if ( fields.Any ( ) && fields.All ( f => f.A.Value == A.Value && f.B.Value == B.Value ) )
			{
				diff = false;
				var ab = axb ( A.Value, B.Value );
				_ = sb.Append ( _axb );
				_ = sb.AppendLine ( ab );
				_ = sb.Append ( "Кб (" );
				_ = sb.Append ( ab );
				_ = sb.Append ( eq );
				_ = sb.AppendLine ( fields [ 0 ].Kb.ToStringWithDecimalPlaces ( 3 ) );
			}
			_ = sb.AppendLine ( );
			var sb_t = new StringBuilder ( );
			foreach ( var f in fields )
			{
				var fld = f.Text.Replace ( "№", string.Empty );
				if ( diff )
				{
					_ = sb.Append ( "Поле " );
					_ = sb.Append ( f.Text );
					_ = sb.Append ( " " );
					var ab = axb ( f.A.Value, f.B.Value );
					_ = sb.Append ( _axb );
					_ = sb.AppendLine ( ab );
					_ = sb.Append ( "Кб" );
					_ = sb.Append ( fld );
					_ = sb.Append ( " (" );
					_ = sb.Append ( ab );
					_ = sb.Append ( eq );
					_ = sb.Append ( f.Kb.ToStringWithDecimalPlaces ( 3 ) );
					_ = sb.AppendLine ( "; " );
				}
				_ = sb.Append ( "ОТВ" );
				_ = sb.Append ( fld );
				_ = sb.Append ( " (" );
				_ = sb.Append ( f.Depth.ToStringWithDecimalPlaces ( 1 ) );
				_ = sb.Append ( eq );
				_ = sb.Append ( f.OTV.ToStringWithDecimalPlaces ( 3 ) );
				if ( f.IsLung )
				{
					_ = sb.AppendLine ( ";" );
					_ = sb.Append ( "L" );
					_ = sb.Append ( fld );
					_ = sb.Append ( eq0 );
					_ = sb.Append ( f.L.ToStringWithDecimalPlaces ( 3 ) );
				}
				_ = sb.AppendLine ( );
				_ = sb_t.Append ( "t" );
				_ = sb_t.Append ( fld );
				_ = sb_t.Append ( eq0 );
				if ( f.IsInMinutes )
				{
					_ = sb_t.Append ( f.Time.ToStringWithDecimalPlaces ( 2 ) );
					_ = sb_t.Append ( " минут" );
				}
				else
				{
					_ = sb_t.Append ( f.Time.ToStringWithDecimalPlaces ( 1 ) );
					_ = sb_t.Append ( " секунд" );
				}
				_ = sb_t.AppendLine ( " (∠" + ( f.Degree != null ? f.Degree.ToString ( ) : @"_____" ) + "°)" );
			}
			_ = sb.AppendLine ( );
			_ = sb.AppendLine ( sb_t.ToString ( ) );
			_ = sb.AppendLine ( );
			_ = sb.Append ( "РИП = " );
			_ = sb.Append ( SSD.Value.ToStringWithDecimalPlaces ( 1 ) );
			_ = sb.AppendLine ( " см" );
			_ = sb.AppendLine ( );
			_ = sb.AppendLine ( Text );
			_ = sb.Append ( "инж.радиолог __________________" );
			return sb.ToString ( );
		}
		private void печататьToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			if ( !fromPreview )
			{
				printString = PreparePrintData ( );
			}

			fromPreview = false;
			printDocument1.DocumentName = DateTime.Now.ToString ( "U" );
			printDialog1.Document = printDocument1;
			try
			{
				if ( printDialog1.ShowDialog ( this ) == DialogResult.OK )
				{
					printDocument1.Print ( );
				}
			}
			catch ( Exception ex )
			{
				throw new Exception ( "Exception Occured While Printing", ex );
			}
		}
		private bool fromPreview = false;
		private string printString;
		private void printDocument1_PrintPage ( object sender, PrintPageEventArgs e ) =>
			e.Graphics.DrawString ( printString, new Font ( "Arial", 14 ), new SolidBrush ( Color.Black ), new RectangleF ( 10, 10, ( ( PrintDocument ) sender ).DefaultPageSettings.PrintableArea.Width, ( ( PrintDocument ) sender ).DefaultPageSettings.PrintableArea.Height ) );

		private void предварителоьныйПросмотрToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			fromPreview = false;
			printString = PreparePrintData ( );
			var formPreview = new PrintPreview ( printString );
			if ( formPreview.ShowDialog ( ) == DialogResult.OK )
			{
				fromPreview = true;
				printString = formPreview.Preview;
				распечататьToolStripMenuItem.PerformClick ( );
			}
		}

		private void среднемесячнаяToolStripMenuItem_Click ( object sender, EventArgs e ) => new MonthPowerTable { FileName = FileName }.ShowDialog ( this );

		private void средняяToolStripMenuItem_Click ( object sender, EventArgs e ) => new AllDevicesPowerTable { FileName = FileName }.ShowDialog ( this );
	}
}
