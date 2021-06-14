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
		public bool IsLung
		{
			get => L_value.Visible;
		}
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
			set => Kb_value.SCD = value;
		}
		public int? A
		{
			get => Kb_value.A;
			set
			{
				Kb_value.A = value;
				OTV_value.A = value;
			}
		}
		public int? B
		{
			get => Kb_value.B;
			set
			{
				Kb_value.B = value;
				OTV_value.B = value;
			}
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
			OTV_value.Recalculate ( );
			TimeCalculator?.Invoke ( this );
		}

		private void OTV_Leave ( object sender, EventArgs e )
		{
			TimeCalculator?.Invoke ( this );
		}

		private void L_Leave ( object sender, EventArgs e )
		{
			TimeCalculator?.Invoke ( this );
		}
	}
}
