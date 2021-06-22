namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Windows.Forms;

	using DB_Worker;

	using Resource.Properties;

	public partial class EditDevices : Form
	{
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set
			{
				Devices.FileName = sql.DataSource = value;
			}
		}
		public EditDevices ( )
		{
			InitializeComponent ( );
			Devices.Add ( SelIndCH );
		}
		private void SelIndCH ( object sender, EventArgs e )
		{
			var prev = Devices.Previous;
			if ( prev == null )
			{
				return;
			}

			prev [ "Мощность" ] = Devices.PreviousPower;
		}
		private void Button_Click ( object sender, EventArgs e ) => Close ( );
		private void EditDevices_FormClosing ( object sender, FormClosingEventArgs e )
		{
			switch ( DialogResult )
			{
				case DialogResult.Abort:
					return;
				case DialogResult.OK:
					Save ( );
					return;
				default:
					if ( MessageBox.Show ( "Хотите ли Вы сохранить измененные данные?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
					{
						DialogResult = DialogResult.OK;
						Save ( );
					}
					return;
			}
		}
		private void Save ( )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			Devices.Selected [ "Мощность" ] = Devices.Power.Value;
			var par = new Dictionary<string, object> ( );
			foreach ( var dev in Devices )
			{
				var d = dev as DataRowView;
				par [ SQL.DevicePower_Table ] = d [ "Мощность" ];
				par [ SQL.DeviceCheckPower_Table ] = DateTime.Today;
				par [ SQL.DeviceName_Table ] = d [ "Аппарат" ];
				sql.ExecuteQuery ( SQL.UpdateDevice, par );
			}
			Cursor = tmp;
		}
	}
}
