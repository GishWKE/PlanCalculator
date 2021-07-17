namespace BaseComponents
{
	using System;
	using System.Drawing;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	public partial class IntTextBox : TextBox
	{
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private new readonly Color DefaultBackColor;
		public int? Value
		{
			get => this.IsEmpty ( ) || !IsCorrect ? null : ( int? ) this.ToInt ( );
			set
			{
				if ( value == null )
				{
					ResetText ( );
				}
				else
				{
					Text = value.ToString ( );
				}
				SelectionStart = Text.Length;
				OnValueChanged ( EventArgs.Empty );
			}
		}
		private string default_tooltip = string.Empty;
		public string Correct_tooltip
		{
			get => default_tooltip;
			set
			{
				if ( !value.IsEmpty ( ) )
				{
					default_tooltip = value;
					toolTip1.SetToolTip ( this, value );
				}
			}
		}
		public string Wrong_tooltip
		{
			get;
			set;
		}
		public bool IsCorrect => this.IsEmpty ( ) || Regex.IsEmpty ( ) || Checker.IsMatch ( Text );
		private bool can_neg = false;
		public bool CanBeNegative
		{
			get => can_neg;
			set
			{
				can_neg = value;
				if ( can_neg )
				{
					KeyPress -= IntTextBox_KeyPress_NoMinus;
				}
				else
				{
					KeyPress += IntTextBox_KeyPress_NoMinus;
					DeleteMinus ( );
				}
			}
		}
		private Regex Checker = null;
		public string Regex
		{
			get => ( Checker == null ) ? string.Empty : Checker.ToString ( );
			set
			{
				if ( !value.IsEmpty ( ) )
				{
					Checker = new Regex ( value );
				}
			}
		}
		private void IntTextBox_KeyPress_NoMinus ( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == '-' )
			{
				e.Handled = true;
			}
		}
		public IntTextBox ( ) : base ( )
		{
			DefaultBackColor = base.BackColor;
			InitializeComponent ( );
		}
		private void DeleteMinus ( )
		{
			if ( !this.IsEmpty ( ) && !CanBeNegative )
			{
				Text = Text.Replace ( "-", string.Empty );
				SelectionStart = Text.Length;
			}
		}
		private void IntTextBox_KeyPress ( object sender, KeyPressEventArgs e )
		{
			switch ( e.KeyChar )
			{
				case '-':
					if ( !Text.Contains ( e.KeyChar ) && SelectionStart == 0 )
					{
						return;
					}
					break;
				case ( char ) Keys.Enter:
					OnLeave ( EventArgs.Empty );
					break;
			}
			if ( !char.IsDigit ( e.KeyChar ) && !char.IsControl ( e.KeyChar ) )
			{
				e.Handled = true;
			}
		}
		private void IntTextBox_TextChanged ( object sender, EventArgs e ) => BackColor = IsCorrect ? DefaultBackColor : Color.Red;
		private void IntTextBox_BackColorChanged ( object sender, EventArgs e )
		{
			var err = BackColor != DefaultBackColor;
			var txt = err ? Wrong_tooltip : Correct_tooltip;
			toolTip1.ToolTipIcon = err ? ToolTipIcon.Error : ToolTipIcon.Info;
			toolTip1.RemoveAll ( );
			if ( !txt.IsEmpty ( ) )
			{
				toolTip1.SetToolTip ( this, txt );
			}
		}
		private void IntTextBox_Leave ( object sender, EventArgs e )
		{
			if ( Text == "-" )
			{
				Value = null;
			}
			else
			{
				Value = Value;
			}
		}
	}
}
