namespace CalculatorComponents
{
	using System.Windows.Forms;

	public partial class Time : UserControl
	{
		private bool is_sec = true;
		public bool IsInMinutes
		{
			get => !IsInSeconds;
			set => IsInSeconds = !value;
		}
		public bool IsInSeconds
		{
			get => is_sec;
			set
			{
				is_sec = value;
				Time_label1.Text = value ? "секунд" : "минут";
				Time_value.FractionalPlaces = value ? 1 : 2;
				Value = Value;
			}
		}
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
