﻿namespace BaseComponents
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	public enum NumericTextBoxTypes
	{
		DOUBLE,
		INT
	}
	public partial class NumericTextBox : TextBox
	{
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private new readonly Color DefaultBackColor;
		private static readonly Regex EmptyDBL = new Regex ( "^-?[,.]?$" );
		private static readonly Regex EmptyINT = new Regex ( "^-?$" );
		private Regex empty = EmptyDBL;
		private int NumberDecimalDigits = Extension.NumberDecimalDigits;
		private NumericTextBoxTypes _type = NumericTextBoxTypes.DOUBLE;
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
					if ( value == 0 )
					{
						empty = EmptyINT;
						Type = NumericTextBoxTypes.INT;
					}
					else
					{
						empty = EmptyDBL;
						Type = NumericTextBoxTypes.DOUBLE;
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
				if ( value == null )
				{
					ResetText ( );
				}
				else
				{
					Text = value.ToStringWithDecimalPlaces ( NumberDecimalDigits );
				}
				SelectionStart = Text.Length;
				OnValueChanged ( EventArgs.Empty );
			}
		}
		public static implicit operator decimal? ( NumericTextBox dtb ) => dtb.Value;
		public static implicit operator decimal ( NumericTextBox dtb ) => dtb.Value.GetValueOrDefault ( decimal.Zero );
		private string default_tooltip = string.Empty;
		[DefaultValue ( "" )]
		public string Correct_tooltip
		{
			get => default_tooltip;
			set
			{
				if ( !value.IsEmpty ( ) )
				{
					default_tooltip = value;
					toolTip.SetToolTip ( this, default_tooltip );
				}
			}
		}
		[DefaultValue ( "" )]
		public string Wrong_tooltip;
		private bool can_neg = false;
		[DefaultValue ( false )]
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
			}
		}
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
					if ( FractionalPlaces != 0 ) // Если разрешена дробная часть
					{
						e.KeyChar = Extension.NumberDecimalSeparator; // Подменяем на лету дробный разделитель
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
			toolTip.ToolTipIcon = err ? ToolTipIcon.Error : ToolTipIcon.Info;
			toolTip.RemoveAll ( );
			if ( !txt.IsEmpty ( ) )
			{
				toolTip.SetToolTip ( this, txt );
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
