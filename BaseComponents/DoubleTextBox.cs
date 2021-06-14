namespace BaseComponents
{
	using System;
	using System.Drawing;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;


	public partial class DoubleTextBox : TextBox
	{
		private new readonly Color DefaultBackColor;
		private readonly Regex empty = new Regex ( "^-?[,.]?$" );
		public double? Value
		{
			get
			{
				if ( this.IsEmpty ( ) || !IsCorrect )
				{
					return null;
				}

				return this.ToDouble ( );
			}
			set
			{
				if ( value == null )
				{
					ResetText ( );
				}
				else
				{
					Text = value.ToString ( );
					if ( Text.Length > MaxLength )
					{
						var sym = ( int ) Math.Ceiling ( Math.Log ( ( double ) value, 10 ) );
						if ( sym > MaxLength )
						{
							MaxLength = Text.Length;
						}
						else
						{
							var left = MaxLength - sym - 1;
							var pow = Math.Pow ( 10, left );
							var tmp = ( int ) Math.Round ( ( double ) value * pow );
							Text = ( tmp / pow ).ToString ( );
						}
					}
				}
				SelectionStart = Text.Length;
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
					toolTip1.SetToolTip ( this, default_tooltip );
				}
			}
		}
		public string Wrong_tooltip
		{
			get;
			set;
		}
		private bool can_neg = false;
		public bool CanBeNegative
		{
			get => can_neg;
			set
			{
				can_neg = value;
				if ( can_neg )
				{
					KeyPress -= DoubleTextBox_KeyPress_NoMinus;
				}
				else
				{
					KeyPress += DoubleTextBox_KeyPress_NoMinus;
				}
				DeleteMinus ( );
			}
		}
		private Regex Checker = null;
		public string regex
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
		public bool IsCorrect => ( this.IsEmpty ( ) || regex.IsEmpty ( ) ) ? true : Checker.IsMatch ( Text );
		private void DoubleTextBox_KeyPress_NoMinus ( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == '-' )
			{
				e.Handled = true;
			}
		}

		public DoubleTextBox ( ) : base ( )
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

		private void DoubleTextBox_KeyPress ( object sender, KeyPressEventArgs e )
		{
			switch ( e.KeyChar )
			{
				case '.':
				case ',':
					e.KeyChar = Extension.DblDot;
					if ( !Text.Contains ( e.KeyChar ) )
					{
						return;
					}
					break;
				case '-':
					if ( !Text.Contains ( e.KeyChar ) && SelectionStart == 0 )
					{
						return;
					}
					break;
				case ( char ) Keys.Enter:
					OnLeave ( new EventArgs ( ) );
					break;
			}
			if ( !char.IsDigit ( e.KeyChar ) && !char.IsControl ( e.KeyChar ) )
			{
				e.Handled = true;
			}
		}

		private void DoubleTextBox_TextChanged ( object sender, EventArgs e )
		{
			BackColor = IsCorrect ? DefaultBackColor : Color.Red;
		}

		private void DoubleTextBox_BackColorChanged ( object sender, EventArgs e )
		{
			var txt = BackColor != DefaultBackColor ? Wrong_tooltip : Correct_tooltip;
			toolTip1.RemoveAll ( );
			if ( !txt.IsEmpty ( ) )
			{
				toolTip1.SetToolTip ( this, txt );
			}
		}
		private void DoubleTextBox_Leave ( object sender, EventArgs e )
		{
			if ( empty.IsMatch ( Text ) )
			{
				Value = null;
			}
			else Value = Value;
		}
	}
}
