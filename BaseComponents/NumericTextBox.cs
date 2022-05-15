namespace BaseComponents
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;

	[Description ( "Тип вводимых данных" )]
	public enum NumericTextBoxTypes
	{
		UNKNOWN = -1,
		DOUBLE,
		INT
	}
	public partial class NumericTextBox : MyTextBox
	{
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		protected Regex empty = null;
		private int NumberDecimalDigits = -1;
		private NumericTextBoxTypes _type = NumericTextBoxTypes.UNKNOWN;
		private bool fromType = false, fromFrac = false; // Для выхода из рекурсии
		public NumericTextBoxTypes Type
		{
			get => _type;
			set
			{
				if ( fromType )
				{
					return;
				}

				if ( _type == value )
				{
					return;
				}

				_type = value;
				fromType = true;
				switch ( value )
				{
					case NumericTextBoxTypes.INT:
						FractionalPlaces = 0;
						break;
					case NumericTextBoxTypes.DOUBLE:
						FractionalPlaces = Extension.NumberDecimalDigits;
						break;
					default:
						FractionalPlaces = -1;
						break;
				}
				fromType = false;
			}
		}
		public int FractionalPlaces
		{
			get => NumberDecimalDigits;
			set
			{
				if ( fromFrac )
				{
					return;
				}

				try
				{
					if ( value == NumberDecimalDigits )
					{
						return;
					}

					NumberDecimalDigits = value;
					fromFrac = true;
					switch ( value )
					{
						case 0:
							Type = NumericTextBoxTypes.INT;
							break;
						case var tmp when tmp > 0:
							Type = NumericTextBoxTypes.DOUBLE;
							break;
						default:
							Type = NumericTextBoxTypes.UNKNOWN;
							break;
					}
				}
				catch { throw; }
				fromFrac = false;
			}
		}
		public bool IsCorrect => this.IsEmpty ( ) || Regex.IsEmpty ( ) || Checker.IsMatch ( Text );
		[DefaultValue ( null )]
		public decimal? Value
		{
			get => this.IsEmpty ( ) || !IsCorrect ? null : ( decimal? ) this.ToDecimal ( );
			set
			{
				if ( value == null || Type == NumericTextBoxTypes.UNKNOWN )
				{
					ResetText ( );
				}
				else
				{
					var newVal = value.ToStringWithDecimalPlaces ( NumberDecimalDigits );
					if ( Text == newVal )
					{
						return;
					}

					Text = newVal;
				}
				SelectionStart = Text.Length;
				OnValueChanged ( EventArgs.Empty );
			}
		}
		public static implicit operator decimal? ( NumericTextBox dtb ) => dtb.Value;
		public static implicit operator decimal ( NumericTextBox dtb ) => dtb.Value.GetValueOrDefault ( decimal.Zero );

		private bool can_neg = false;
		[DefaultValue ( false )]
		public bool CanBeNegative
		{
			get => can_neg;
			set
			{
				can_neg = value;
				if ( CanBeNegative )
				{
					KeyPress -= NumericTextBox_KeyPress_NoMinus;
				}
				else
				{
					DeleteMinus ( );
					KeyPress += NumericTextBox_KeyPress_NoMinus;
				}
			}
		}
		public bool AlwaysPositive
		{
			get => !CanBeNegative;
			set => CanBeNegative = !value;
		}
		private Regex Checker = null;
		[DefaultValue ( "" )]
		public string Regex
		{
			get => ( Checker == null ) ? string.Empty : Checker.ToString ( );
			set
			{
				if ( !value.IsEmpty ( ) )
				{
					Checker = new Regex ( value );
				}
				else
				{
					Checker = null;
				}
			}
		}
		private void NumericTextBox_KeyPress_NoMinus ( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == '-' )
			{
				e.Handled = true;
			}
		}
		public NumericTextBox ( ) : base ( ) => InitializeComponent ( );
		public NumericTextBox ( string Empty ) : this ( ) => empty = new Regex ( Empty );
		private void DeleteMinus ( )
		{
			if ( !this.IsEmpty ( ) && !CanBeNegative )
			{
				Text = Text.Replace ( "-", string.Empty );
				SelectionStart = Text.Length;
			}
		}
		private void NumericTextBox_KeyPress ( object sender, KeyPressEventArgs e )
		{
			switch ( e.KeyChar )
			{
				case '.':
				case ',':
				case '\'':
					e.KeyChar = Extension.NumberDecimalSeparator; // Подменяем на лету дробный разделитель
					if ( Type == NumericTextBoxTypes.DOUBLE && !Text.Contains ( e.KeyChar ) ) // Если дробный разделитель отсутсвует
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
					OnLeave ( EventArgs.Empty );
					break;
			}
			if ( !char.IsDigit ( e.KeyChar ) && !char.IsControl ( e.KeyChar ) )
			{
				e.Handled = true;
			}
		}
		private readonly Color errorColor = Color.Red;
		private void NumericTextBox_TextChanged ( object sender, EventArgs e )// => BackColor = IsCorrect ? DefaultBackColor : Color.Red;
		{
			if ( IsCorrect )
			{
				ResetBackColor ( );
			}
			else
			{
				BackColor = errorColor;
			}
		}
		private void NumericTextBox_BackColorChanged ( object sender, EventArgs e ) => SetToolTip ( BackColor != errorColor );
		private void NumericTextBox_Leave ( object sender, EventArgs e )
		{
			if ( empty != null && empty.IsMatch ( Text ) )
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
