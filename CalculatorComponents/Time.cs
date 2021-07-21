namespace CalculatorComponents
{
using System.ComponentModel;
	using System.Windows.Forms;

	using Resource.Properties;

	public partial class Time : UserControl
	{
		private bool is_sec = true;
		[DefaultValue ( false )]
		public bool IsInMinutes
		{
			get => !IsInSeconds;
			set => IsInSeconds = !value;
		}
		[DefaultValue ( true )]
		public bool IsInSeconds
		{
			get => is_sec;
			set
			{
				is_sec = value;
				Time_label1.Text = value ? Resources.Time_seconds : Resources.Time_minutes;
				Time_value.FractionalPlaces = value ? 1 : 2;
				Value = Value;
			}
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => Time_value.Value;
			set => Time_value.Value = value;
		}
		public Time ( )
		{
			InitializeComponent ( );
			IsInSeconds = true;
		}
	}
}
