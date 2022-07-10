namespace BaseComponents
{
	using System.Windows.Forms;

	internal class TT_Type
	{
		private string _text = string.Empty;
		public string Text
		{
			get => _text;
			set
			{
				if ( !_text.IsEmpty ( ) && !value.IsEmpty ( ) && _text == value )
				{
					return;
				}
				_text.Clear ( );
				if ( value != null )
				{
					_text = value;
				}
			}
		}
		public ToolTipIcon Icon = ToolTipIcon.None;
		public TT_Type ( (string text, ToolTipIcon icon) val )
		{
			Text = val.text;
			Icon = val.icon;
		}
		public TT_Type ( string text, ToolTipIcon icon ) : this ( (text, icon) )
		{ }
		public TT_Type ( ToolTipIcon icon, string text ) : this ( (text, icon) )
		{ }
		public void Clear ( ) => Text = null;
		public static implicit operator bool ( TT_Type o ) => !o.Text.IsEmpty ( );
		public static implicit operator string ( TT_Type o ) => o.Text;
		public static implicit operator ToolTipIcon ( TT_Type o ) => o.Icon;
	}
}
