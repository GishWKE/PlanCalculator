namespace CalculatorComponents
{
	using System;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	public partial class Lung : UserControl
	{
		public void Recalculate ( )
		{
			OnLeave ( new EventArgs ( ) );
		}
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
		private void DT_Leave ( object sender, EventArgs e )
		{
			Recalculate ( );
		}
		private void Lung_Leave ( object sender, EventArgs e )
		{
			UpdateL ( );
		}
		private void UpdateL ( )
		{
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

			var SQL_string = $@"SELECT [Легочная ткань].L FROM [Легочная ткань] WHERE [Легочная ткань].[Толщина легкого]={TT} AND [Легочная ткань].[Расстояние от точки расчета до легкого (не более)]={DD};".Replace ( Extension.DblDot, '.' );

			Value = ( double? ) sql.GetValue ( SQL_string );
		}
		private void IsLung_CheckedChanged ( object sender, EventArgs e )
		{
			Lung_parameters.Visible = Visible;
			Recalculate ( );
		}
	}
}
