namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using DB_Worker;

	using Resource;
	using Resource.Properties;

	public partial class EditDevices : Form
	{
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => Devices.FileName;
			set
			{
				Devices.FileName = value;
				sql.DataSource = value;
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
			Devices.Current [ "Мощность" ] = Devices.Power.Value;
			for ( var i = 0; i < Devices.Count; i++ )
			{
				var dev = Devices [ i ];
				sql.ExecuteQuery ( SQL.UpdateDevice, new List<(string name, object value)>
				{
					( SQL.DevicePower_Table, dev["Мощность"] ),
					( SQL.DeviceCheckPower_Table, DateTime.Today ),
					( SQL.DeviceName_Table, dev["Аппарат"] )
				} );
			}
			Cursor = tmp;
		}
	}
}
