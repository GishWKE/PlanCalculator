namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Windows.Forms;

	using CalculatorComponents;


	public partial class Form1 : Form
	{
		private readonly string FileName;
		private readonly List<Field> fields;
		public Form1 ( )
		{
			FileName = @".\Resources\DB.accdb";
			//FileName = Path.GetFullPath ( FileName );
			fields = new List<Field> ( );
			InitializeComponent ( );
			Devices.Add ( new EventHandler ( DeviceChanged ) );
			Devices.FileName = FileName;
			Text = DateTime.Today.ToString ( "d" );
		}
		private void DeviceChanged ( object sender, EventArgs e )
		{
			var sel = Devices.Selected;
			var scd = ( int ) sel [ "РИЦ" ];
			var sec = ( bool ) sel [ "Время в минутах" ];
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
			var div = new List<double> { ( double ) P.Value, ( double ) Devices.Power.Value, ( double ) FieldsCount.Value, ( double ) f.Kb, ( double ) f.OTV };
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
				AllFields.ResumeLayout ( false );
				AllFields.PerformLayout ( );
			}
			else if ( cnt < fields.Count )
			{
				AllFields.SuspendLayout ( );
				for ( var i = fields.Count - 1; i >= cnt; i-- )
				{
					AllFields.Controls.Remove ( fields [ i ] );
					fields.RemoveAt ( i );
				}
				AllFields.ResumeLayout ( true );
				AllFields.PerformLayout ( );
				Calculate ( );
			}
			else
			{
				AllFields.SuspendLayout ( );
				for ( var i = fields.Count; i < cnt; i++ )
				{
					fields.Add ( new Field
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
					AllFields.Controls.Add ( fields [ i ] );
				}
				AllFields.ResumeLayout ( true );
				AllFields.PerformLayout ( );
				Calculate ( );
			}
			Cursor = tmp;
		}
		private void AB_ValueChanged ( object sender, EventArgs e )
		{
			var obj = ( sender as NumericUpDown );
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
	}
}
