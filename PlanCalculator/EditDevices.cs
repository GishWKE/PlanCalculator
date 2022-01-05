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
	using System.ComponentModel;
	using System.Data;
	using System.IO;
	using System.Windows.Forms;

	using DB_Worker;

	using Resource.Properties;

	public partial class EditDevices : Form
	{
		private readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue ( "" )]
		public FileInfo FileName
		{
			get => sql.FileName;
			set => Devices.FileName = sql.FileName = value;
		}
		public EditDevices ( )
		{
			InitializeComponent ( );
			Devices.DeviceChanged += SelIndCH;
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
			foreach ( var dev in Devices )
			{
				var d = dev as DataRowView;
				sql.AddParameter ( SQL.DeviceName_Table, d [ "Аппарат" ] );
				sql.AddParameter ( SQL.DevicePower_Table, d [ "Мощность" ] );
				sql.ExecuteQuery ( SQL.UpdateDevice );
			}
			Cursor = tmp;
		}
	}
}
