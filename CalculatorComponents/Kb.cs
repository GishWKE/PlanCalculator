namespace CalculatorComponents
{
	using System;
	using System.Windows.Forms;

	using DB_Worker;

	public partial class Kb_Control : UserControl
	{
		public void Recalculate ( )
		{
			OnLeave ( new EventArgs ( ) );
		}
		private int scd_val = 0;
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}
		public int SCD
		{
			get => scd_val;
			set
			{
				scd_val = value;
				Recalculate ( );
			}
		}
		public double? Value
		{
			get
			{
				if ( A != null && B != null )
				{
					return Kb.Value;
				}

				return null;
			}
			private set
			{
				Kb.ResetText ( );
				if(value != null )
					Kb.Text = $"{( double ) value:F3}";
			}
		}
		public int? A
		{
			get => A_size.Value;
			set => A_size.Value = value;
		}
		public int? B
		{
			get => B_size.Value;
			set => B_size.Value = value;
		}

		public Kb_Control ( ) => InitializeComponent ( );
		private void AB_Changed_Leave ( object sender, EventArgs e )
		{
			Recalculate ( );
		}

		private void Kb_Control_Leave ( object sender, EventArgs e )
		{
			UpdateKb ( );
		}

		private void UpdateKb ( )
		{
			Kb.ResetText ( );
			var AA = A;
			var BB = B;
			if ( AA == null || BB == null || SCD == 0 || FileName.IsEmpty ( ) )
			{
				return;
			}

			var SQL_string = $@"SELECT Кб.Кб FROM Кб WHERE Кб.РИЦ={SCD} AND Кб.A={( int ) AA} AND Кб.B={( int ) BB};";
			Value = ( double? ) sql.GetValue ( SQL_string );
		}
	}
}
