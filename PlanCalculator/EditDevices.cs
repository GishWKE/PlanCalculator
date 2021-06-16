namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.Text;
	using System.Windows.Forms;

	using DB_Worker;

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
		private string ReSQL ( )
		{
			var sqlQuery = new StringBuilder ( );
			sqlQuery.Append ( "UPDATE [Аппараты] SET [Аппараты].[Мощность] = ?" );
			sqlQuery.Append ( ", [Аппараты].[Дата замера мощности] = ?" );
			sqlQuery.Append ( $" WHERE [Аппараты].[Аппарат] = ?;" );
			return sqlQuery.ToString ( );
		}
		private List<OleDbParameter> Parameters ( DataRowView r ) => new List<OleDbParameter>
			{
				new OleDbParameter ( "[Аппараты].[Мощность]", r["Мощность"] ),
				new OleDbParameter ( "[Аппараты].[Дата замера мощности]", DateTime.Today ),
				new OleDbParameter ( "[Аппараты].[Аппарат]", r["Аппарат"] )
			};

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
			for ( var i = 0; i < Devices.Count; i++ )
			{
				var dev = Devices [ i ];
				sql.ExecuteQuery ( ReSQL ( ), Parameters ( dev ) );
			}
		}
	}
}
