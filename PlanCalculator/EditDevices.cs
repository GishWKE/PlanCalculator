using BaseComponents;

using DB_Worker;

using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace PlanCalculator
{
	public partial class EditDevices : Form
{
		OleDB_Worker sql = new OleDB_Worker ( );
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
					return;
			prev [ "Мощность" ] = Devices.PreviousPower;
			/*
			sql.ExecuteQuery ( ReSQL ( prev [ "Аппарат" ] ), Parameters( ( double ) Devices.PreviousPower ) );*/
		}
		private void Button_Ok_Click ( object sender, EventArgs e )
		{
			Close ( );
		}
		string ReSQL ( object elem )
		{
			var sqlQuery = new StringBuilder ( );
			sqlQuery.Append ( "UPDATE [Аппараты] SET [Аппараты].[Мощность] = ?" );
			sqlQuery.Append ( ", [Аппараты].[Дата замера мощности] = ?" );
			sqlQuery.Append ( $" WHERE [Аппараты].[Аппарат] = '" );
			sqlQuery.Append ( elem );
			sqlQuery.Append ( "';" );
			return sqlQuery.ToString ( );
		}
		List <OleDbParameter> Parameters (double pow )
		{
			return new List<OleDbParameter>
			{
				new OleDbParameter ( "[Аппараты].[Мощность]", pow ),
				new OleDbParameter ( "[Аппараты].[Дата замера мощности]", DateTime.Today )
			};
		}

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
			Devices.Current [ "Мощность" ] = Devices.Power.Value;
			//sql.ExecuteQuery ( ReSQL ( Devices.Current [ "Аппарат" ] ), Parameters ( ( double ) Devices.Power.Value ) );
			for ( var i = 0; i < Devices.Count; i++ )
			{
				var dev = Devices [ i ];
				sql.ExecuteQuery ( ReSQL ( dev [ "Аппарат" ] ), Parameters ( ( double ) dev [ "Мощность" ] ) );
			}
		}
		private void buttonCancel_Click ( object sender, EventArgs e )
		{
			Close ( );
		}
	}
}
