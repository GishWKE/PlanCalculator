﻿namespace PlanCalculator
{
	using System;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class CreateDevice : Form
	{
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}
		private bool IsEmpty => DeviceName.IsEmpty ( ) || SCD.Value == null || Power.Value == null;
		private bool IsNotEmpty => !DeviceName.IsEmpty ( ) || SCD.Value != null || Power.Value != null;
		private bool IsFull => !DeviceName.IsEmpty ( ) && SCD.Value != null && Power.Value != null;
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
			sql.AddParameter ( SQL.DeviceSCD_Table, SCD.Value );
			sql.AddParameter ( SQL.DeviceTime_Table, Minutes.Checked );
			sql.AddParameter ( SQL.DeviceCheckPower_Table, dateTimePicker1.Value );
			sql.ExecuteQuery ( SQL.CreateDevice );
		}
	}
}
