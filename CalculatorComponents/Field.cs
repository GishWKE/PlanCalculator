namespace CalculatorComponents
{
	using System;
using System.ComponentModel;
	using System.Windows.Forms;
	public partial class Field : UserControl
	{
		public event EventHandler RecalculationNeed;
		protected virtual void OnRecalculationNeed ( EventArgs e ) => RecalculationNeed?.Invoke ( this, e );
		[DefaultValue ( "" )]
		public new string Text
		{
			get => FieldPanel.Text;
			set => FieldPanel.Text = value;
		}
		public bool IsLung => L_value.Visible;
		[DefaultValue ( true )]
		public bool IsInSeconds
		{
			get => Time_value.IsInSeconds;
			set => Time_value.IsInSeconds = value;
		}
		[DefaultValue ( false )]
		public bool IsInMinutes
		{
			get => Time_value.IsInMinutes;
			set => Time_value.IsInMinutes = value;
		}
		public double? Kb => Kb_value.Value;
		public double? OTV => OTV_value.Value;
		public double? L => L_value.Value;
		[DefaultValue ( null )]
		public double? Time
		{
			get => Time_value.Value;
			set => Time_value.Value = value;
		}
		[DefaultValue ( "" )]
		public string FileName
		{
			get => Kb_value.FileName;
			set => Kb_value.FileName = OTV_value.FileName = L_value.FileName = value;
		}
		[DefaultValue ( 0 )]
		public int SCD
		{
			get => Kb_value.SCD;
			set => OTV_value.SCD = Kb_value.SCD = value;
		}
		[DefaultValue ( null )]
		public int? A
		{
			get => Kb_value.A;
			set
			{
				OTV_value.A = value;
				Kb_value.A = value;
			}
		}
		[DefaultValue ( null )]
		public int? B
		{
			get => Kb_value.B;
			set
			{
				OTV_value.B = value;
				Kb_value.B = value;
			}
		}
		public Field ( ) : base ( ) => InitializeComponent ( );
		private void UpdateOTV_AB ( object sender, EventArgs e )
		{
			OTV_value.B = null;
			OTV_value.A = Kb_value.A;
			OTV_value.B = Kb_value.B;
		}

		private void Any_ValueChanged ( object sender, EventArgs e ) => OnRecalculationNeed ( EventArgs.Empty );

	}
}
