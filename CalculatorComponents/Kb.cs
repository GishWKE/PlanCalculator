namespace CalculatorComponents
{
	using System;
	using System.Windows.Forms;
	using System.Data.OleDb;
	using System.Collections.Generic;

	using DB_Worker;

	using BaseComponents;

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
			private set => Kb.Value = value;
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

		public static readonly string SQL_Query = "SELECT Кб.Кб FROM Кб WHERE Кб.РИЦ=? AND Кб.A=? AND Кб.B=?;";
		private void UpdateKb ( )
		{
			if ( Parent == null ) // Не размещен на форме/компоненте
				return;
			Kb.ResetText ( );
			var AA = A;
			var BB = B;
			if ( AA == null || BB == null || SCD == 0 || FileName.IsEmpty ( ) )
			{
				return;
			}

			Value = ( double? ) sql.GetValue ( SQL_Query, new List<(string name, object value)>
			{
				("Кб.РИЦ",SCD),
				("Кб.A",AA),
				("Кб.B",BB)
			} );
		}
	}
}
