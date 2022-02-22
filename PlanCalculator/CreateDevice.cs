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
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class CreateDevice : Form
	{
		private static readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.FileName;
			set => sql.FileName = value;
		}
		private bool IsEmpty => DeviceName.IsEmpty ( ) || Power.Value == null;
		private bool IsNotEmpty => !DeviceName.IsEmpty ( ) || Power.Value != null;
		private bool IsFull => !IsEmpty;
		public CreateDevice ( )
		{
			InitializeComponent ( );
			dateTimePicker1.MaxDate = DateTime.Today.AddDays ( 1 ).AddTicks ( -1 );
		}

		private void CreateDevice_FormClosing ( object sender, FormClosingEventArgs e )
		{
			switch ( DialogResult )
			{
				case DialogResult.Cancel:
					if ( IsEmpty )
					{
						return;
					}
					if ( IsFull && MessageBox.Show ( "Сохранить введенные данные?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes )
					{
						CreateDeviceSQL ( );
						DialogResult = DialogResult.Yes;
					}

					if ( IsNotEmpty && MessageBox.Show ( "Отменить внесенные изменения?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
					{
						e.Cancel = true;
					}

					return;
				case DialogResult.No:
					return;
				case DialogResult.Yes:
					CreateDeviceSQL ( );
					return;
			}
		}
		private void CreateDeviceSQL ( )
		{
			sql.AddParameter ( SQL.DeviceName_Table, DeviceName.Text );
			sql.AddParameter ( SQL.DevicePower_Table, Power.Value );
			sql.AddParameter ( SQL.DeviceSCD_Table, ( int ) SCD.Value );
			sql.AddParameter ( SQL.DeviceTime_Table, Minutes.Checked );
			sql.AddParameter ( SQL.DeviceCheckPower_Table, dateTimePicker1.Value.Date );
			sql.ExecuteQuery ( SQL.CreateDevice );
		}
	}
}
