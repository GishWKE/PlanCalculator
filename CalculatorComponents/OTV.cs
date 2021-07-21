namespace CalculatorComponents
{
	using System;
using System.ComponentModel;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class OTV : UserControl
	{
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );

		private readonly Kb_Control Kb = new Kb_Control ( );
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.DataSource;
			set => Kb.FileName = sql.DataSource = value;
		}
		[DefaultValue ( null )]
		public int? A
		{
			get => Kb.A;
			set => Kb.A = value;
		}
		[DefaultValue ( null )]
		public int? B
		{
			get => Kb.B;
			set => Kb.B = value;
		}
		[DefaultValue ( 0 )]
		public int SCD
		{
			get => Kb.SCD;
			set => Kb.SCD = value;
		}
		[DefaultValue ( null )]
		public double? D
		{
			get => Depth.Value;
			set => Depth.Value = value;
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => A != null && B != null && D != null ? OTV_value.Value : null;
			private set => OTV_value.Value = value;
		}
		public OTV ( )
		{
			InitializeComponent ( );
			Kb.ValueChanged += new EventHandler ( OTV_RecalculationNeed );
		}

		private void OTV_value_ValueChanged ( object sender, EventArgs e ) => OnValueChanged ( EventArgs.Empty );

		private void OTV_RecalculationNeed ( object sender, EventArgs e )
		{
			OTV_value.ResetText ( );
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
	}
}
