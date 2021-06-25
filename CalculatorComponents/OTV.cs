namespace CalculatorComponents
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class OTV : UserControl
	{
		public void Recalculate ( ) => OnLeave ( new EventArgs ( ) );

		private readonly Kb_Control Kb = new Kb_Control ( );
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => Kb.FileName = sql.DataSource = value;
		}
		public int? A
		{
			get => Kb.A;
			set => Kb.A = value;
		}
		public int? B
		{
			get => Kb.B;
			set => Kb.B = value;
		}
		public int SCD
		{
			get => Kb.SCD;
			set => Kb.SCD = value;
		}
		public double? D
		{
			get => Depth.Value;
			set => Depth.Value = value;
		}
		public double? Value
		{
			get => A != null && B != null && D != null ? OTV_value.Value : null;
			private set => OTV_value.Value = value;
		}
		private void AB_Depth_Changed_Leave ( object sender, EventArgs e ) => Recalculate ( );
		private void OTV_Leave ( object sender, EventArgs e ) => UpdateOTV ( );
		private void UpdateOTV ( )
		{
			if ( Parent == null ) // Не размещен на форме/компоненте
			{
				return;
			}

			OTV_value.ResetText ( );
			if ( !Visible )
			{
				return;
			}

			var AA = A;
			var BB = B;
			var DD = D;
			if ( AA == null || BB == null || DD == null || FileName.IsEmpty ( ) )
			{
				return;
			}
			sql.AddParameter ( SQL.OTV_A, AA );
			sql.AddParameter ( SQL.OTV_B, BB );
			sql.AddParameter ( SQL.OTV_Depth, DD );
			Value = ( double? ) sql.GetValue ( SQL.OTV );
		}
		public OTV ( )
		{
			Kb.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			InitializeComponent ( );
		}
	}
}
