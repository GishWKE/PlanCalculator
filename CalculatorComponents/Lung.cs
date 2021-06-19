namespace CalculatorComponents
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using BaseComponents;

	using Resource;
	using Resource.Properties;

	using DB_Worker;

	public partial class Lung : UserControl
	{
		public void Recalculate ( ) => OnLeave ( new EventArgs ( ) );
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}
		public int? D => Distance.Value;
		public double? T => Thickness.Value;
		public double? Value
		{
			get
			{
				if ( D != null && T != null )
				{
					return L.Value;
				}

				return null;
			}
			private set => L.Value = value;
		}
		public new bool Visible
		{
			get => IsLung.Checked;
			set => IsLung.Checked = value;
		}
		public Lung ( ) => InitializeComponent ( );
		private void DT_Leave ( object sender, EventArgs e ) => Recalculate ( );
		private void Lung_Leave ( object sender, EventArgs e ) => UpdateL ( );

		private void UpdateL ( )
		{
			if ( Parent == null ) // Не размещен на форме/компоненте
			{
				return;
			}

			L.ResetText ( );
			if ( !Visible )
			{
				return;
			}

			var TT = T;
			var DD = D;
			if ( TT == null || DD == null || FileName.IsEmpty ( ) )
			{
				return;
			}

			Value = ( double? ) sql.GetValue ( SQL.Lung, new List<(string name, object value)>
			{
				(SQL.Lung_Thickness, TT),
				(SQL.Lung_Distance, DD)
			} );
		}
		private void IsLung_CheckedChanged ( object sender, EventArgs e )
		{
			Lung_parameters.Visible = Visible;
			Recalculate ( );
		}
	}
}
