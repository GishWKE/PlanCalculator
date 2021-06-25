namespace CalculatorComponents
{
	using System;
	using System.Windows.Forms;
	public partial class Field : UserControl
	{
		public Action<object> TimeCalculator;
		public new string Text
		{
			get => FieldPanel.Text;
			set => FieldPanel.Text = value;
		}
		public bool IsLung => L_value.Visible;
		public bool IsInSeconds
		{
			get => Time_value.IsInSeconds;
			set => Time_value.IsInSeconds = value;
		}
		public bool IsInMinutes
		{
			get => Time_value.IsInMinutes;
			set => Time_value.IsInMinutes = value;
		}
		public double? Kb => Kb_value.Value;
		public double? OTV => OTV_value.Value;
		public double? L => L_value.Value;
		public double? Time
		{
			get => Time_value.Value;
			set => Time_value.Value = value;
		}
		public string FileName
		{
			get => Kb_value.FileName;
			set => Kb_value.FileName = OTV_value.FileName = L_value.FileName = value;
		}
		public int SCD
		{
			get => Kb_value.SCD;
			set => OTV_value.SCD = Kb_value.SCD = value;
		}
		public int? A
		{
			get => Kb_value.A;
			set => OTV_value.A = Kb_value.A = value;
		}
		public int? B
		{
			get => Kb_value.B;
			set => OTV_value.B = Kb_value.B = value;
		}
		public Field ( ) => InitializeComponent ( );
		private void Field_Leave ( object sender, EventArgs e )
		{
			Kb_value.Recalculate ( );
			OTV_value.Recalculate ( );
			L_value.Recalculate ( );
		}

		private void Kb_Leave ( object sender, EventArgs e )
		{
			OTV_value.A = Kb_value.A;
			OTV_value.B = Kb_value.B;
			OTV_value.Recalculate ( );
			Recalculate ( );
		}

		private void OTV_Leave ( object sender, EventArgs e ) => Recalculate ( );

		private void L_Leave ( object sender, EventArgs e ) => Recalculate ( );
		private void Recalculate() => TimeCalculator?.Invoke ( this );
	}
}
