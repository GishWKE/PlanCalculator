namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows.Forms;

	using BaseComponents;

	using CalculatorComponents;

	using Resource.Properties;

	public partial class Form1 : Form
	{
		private readonly string FileName;
		private readonly List<Field> fields;
		public Form1 ( )
		{
			FileName = @".\Resources\DB.accdb";
			fields = new List<Field> ( );
			InitializeComponent ( );
			Devices.Add ( new EventHandler ( DeviceChanged ) );
			Devices.FileName = FileName;
			Text = DateTime.Today.ToString ( "d" );
		}

		private static readonly string regex_fmt = $"{RegEx.Empty}|{RegEx.Begin}({RegEx.Values_0__9_9}|{{0}}){RegEx.End}";

		private void DeviceChanged ( object sender, EventArgs e )
		{
			var sel = Devices.Selected;
			var scd = ( int ) sel [ "РИЦ" ];
			var sec = ( bool ) sel [ "Время в минутах" ];
			var tmp = scd / 10;
			var tmp0 = scd % 10;
			/// C#>=8.0
			/// Рекурсивный шаблон
			/// C#>=9.0
			/// Реляционный шаблон
			/// Пример:
			/*
			Distance.Regex = scd switch
			{
				var _ when scd >= 40 && scd <= 100 && scd % 10 == 0 => $"{empty}|{str_beg}({r_0_10}|{string.Format ( formatter_div10, tmp - 1, scd )}){str_end}",
				var _ when scd >= 45 && scd <= 95 && scd % 10 == 5 => $"{empty}|{str_beg}({r_0_10}|{string.Format ( formatter_div5, tmp - 1, tmp, scd )}){str_end}",
				_ => string.Empty
			};
			*/
			switch ( scd )
			{
				case var _ when scd >= 40 && scd <= 100 && tmp0 == 0: // 40,50,60,70,80,90,100
					{
						var temp = string.Format ( RegEx.Format_end0, tmp - 1, scd );
						Distance.Regex = string.Format ( regex_fmt, temp );
						break;
					}
				case var _ when scd >= 45 && scd <= 95 && tmp0 == 5: // 45,55,65,75,85,95
					{
						var temp = string.Format ( RegEx.Format_end5, tmp - 1, tmp, scd );
						Distance.Regex = string.Format ( regex_fmt, temp );
						break;
					}
				default:
					Distance.Regex.Clear ( );
					break;
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
			if ( D.Value == null || P.Value == null || f.Kb == null || f.OTV == null || ( f.IsLung && f.L == null ) )
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
					fld.Add ( new Field
					{
						Text = $@"№{i + 1}:",
						Dock = DockStyle.Top,
						FileName = FileName,
						SCD = ( int ) Devices.SCD,
						A = ( int ) A.Value,
						B = ( int ) B.Value,
						IsInMinutes = ( bool ) Devices.Selected [ "Время в минутах" ],
						TimeCalculator = Calculate
					} );
				}
				fields.AddRange ( fld );
				AllFields.Controls.AddRange ( fld.ToArray ( ) );
				AllFields.ResumeLayout ( );
				Calculate ( );
			}
			Cursor = tmp;
		}
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
			if ( new EditDevices { FileName = FileName }.ShowDialog ( ) == DialogResult.OK )
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
			if ( SSD == null || DST > SCD )
			{
				return;
			}
			SSD.Value = SCD - DST;
		}

		private void добавлениеАппаратовToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			if ( new CreateDevice { FileName = FileName }.ShowDialog ( ) == DialogResult.Yes )
			{
				Devices.FileName = FileName;
				Calculate ( );
			}
			Cursor = tmp;
		}
	}
}
