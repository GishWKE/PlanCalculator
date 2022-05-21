namespace BaseComponents.ToolTip
{
	using System.Windows.Forms;

	internal class TT_Type
	{
		private readonly string Text = null;
		private readonly ToolTipIcon Icon;
		public TT_Type ( (string text, ToolTipIcon icon) val )
		{
			Text = val.text;
			Icon = val.icon;
		}
		public override string ToString ( ) => Text ?? string.Empty;
		public static implicit operator string ( TT_Type o ) => o.ToString ( );
		public static implicit operator bool ( TT_Type o ) => !o.ToString ( ).IsEmpty ( );
		public static implicit operator ToolTipIcon ( TT_Type o ) => o.Icon;
	}
}
