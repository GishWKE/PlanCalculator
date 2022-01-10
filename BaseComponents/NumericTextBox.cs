namespace BaseComponents
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	public enum TextBoxType
	{
		Integer,
		Double
	}
	[DefaultEvent ( "ValueChanged" )]
	public partial class NumericTextBox : TextBox
	{
		private TextBoxType type = TextBoxType.Double;
		[Description ( "Событие, генерируемое при изменении переменной в поле ввода" )]
		[Browsable ( true )]
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private new readonly Color DefaultBackColor;
		private static readonly Regex EmptyDBL = new Regex ( "^-?[,.]?$" );
		private static readonly Regex EmptyINT = new Regex ( "^-?$" );
		private Regex empty = EmptyDBL;
		private bool settedFP = false;
		private bool settedT = false;
		[Description ( "Тип выводимых даннх (int или double)" )]
		[Browsable ( true )]
		public TextBoxType Type
		{
			get => type;
			set
			{
				if ( type == value )
				{
					return;
				}

				type = value;
				settedT = true;
				switch ( type )
				{
					case TextBoxType.Integer:
						empty = EmptyINT;
						if ( !settedFP )
						{
							FractionalPlaces = 0;
						}

						break;
					case TextBoxType.Double:
						empty = EmptyDBL;
						if ( !settedFP )
						{
							FractionalPlaces = NumberFormatInfo.CurrentInfo.NumberDecimalDigits;
						}

						break;
				}
				settedT = false;
			}
		}
		[Description ( "Число символов, выводимых после запятой" )]
		[Browsable ( true )]
		public int FractionalPlaces
		{
			get => nfi.NumberDecimalDigits;
			set
			{
				if ( value == FractionalPlaces )
				{
					return;
				}

				try
				{
					nfi.NumberDecimalDigits = value;
					settedFP = true;
				}
				catch { throw; }
				if ( !settedT )
				{
					Type = ( value == 0 ) ? TextBoxType.Integer : TextBoxType.Double;
				}

				settedFP = false;
			}
		}
		private readonly NumberFormatInfo nfi = ( NumberFormatInfo ) NumberFormatInfo.CurrentInfo.Clone ( );
		[DefaultValue ( null )]
		[Description ( "Переменная, отображаемая в поле" )]
		[Browsable ( true )]
		public decimal? Value
		{
			get => this.IsEmpty ( ) || !IsCorrect ? null : ( decimal? ) this.ToDecimal ( );
			set
			{
				if ( value == null )
				{
					ResetText ( );
				}
				else
				{
					Text = value.Value.ToString ( "F", nfi );
				}
				SelectionStart = Text.Length;
				OnValueChanged ( EventArgs.Empty );
			}
		}
		public static implicit operator decimal? ( NumericTextBox dtb ) => dtb.Value;
		public static implicit operator decimal ( NumericTextBox dtb ) => ( ( decimal? ) dtb ).GetValueOrDefault ( decimal.Zero );
		private string default_tooltip = string.Empty;
		[DefaultValue ( "" )]
		[Description ( "Текст выпадающей подсказки" )]
		[Browsable ( true )]
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
		[DefaultValue ( "" )]
		[Description ( "Текст выпадающей подсказки для неправильного ввода данных" )]
		[Browsable ( true )]
		public string Wrong_tooltip
		{
			get;
			set;
		}
		private bool can_neg = false;
		[DefaultValue ( false )]
		[Description ( "Может ли вводимая переменная быть отрицательной" )]
		[Browsable ( true )]
		public bool CanBeNegative
		{
			get => can_neg;
			set
			{
				can_neg = value;
				if ( can_neg )
				{
					KeyPress -= NumericTextBox_KeyPress_NoMinus;
				}
				else
				{
					KeyPress += NumericTextBox_KeyPress_NoMinus;
					DeleteMinus ( );
				}
			}
		}
		private Regex Checker = null;
		[DefaultValue ( "" )]
		[Description ( "Регулярное выражение для проверки правильности ввода" )]
		[Browsable ( true )]
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
		[Description ( "Проверка на соответствие введенных данных регулярному выражению" )]
		[Browsable ( true )]
		public bool IsCorrect => this.IsEmpty ( ) || Regex.IsEmpty ( ) || Checker.IsMatch ( Text );
		private void NumericTextBox_KeyPress_NoMinus ( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar == '-' )
			{
				e.Handled = true;
			}
		}
		public NumericTextBox ( ) : base ( )
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
		private void NumericTextBox_KeyPress ( object sender, KeyPressEventArgs e )
		{
			switch ( e.KeyChar )
			{
				case '.':
				case ',':
					if ( Type != TextBoxType.Integer ) // Если разрешена дробная часть
					{
						e.KeyChar = Extension.DblDot; // Подменяем на лету дробный разделитель
						if ( !Text.Contains ( e.KeyChar ) ) // Если дробный разделитель отсутсвует
						{
							return;
						}
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
		private void NumericTextBox_TextChanged ( object sender, EventArgs e ) => BackColor = IsCorrect ? DefaultBackColor : Color.Red;
		private void NumericTextBox_BackColorChanged ( object sender, EventArgs e )
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
		private void NumericTextBox_Leave ( object sender, EventArgs e )
		{
			if ( empty.IsMatch ( Text ) )
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
