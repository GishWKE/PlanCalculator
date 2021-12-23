/*
  Copyright © 2021 Antipov Roman (https://github.com/GishWKE), Tsys' Alexandr (https://github.com/AlexTsys256)


   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
namespace BaseComponents
{
	using System;
	using System.ComponentModel;
	using System.Drawing;
	using System.Globalization;
	using System.Linq;
	using System.Text.RegularExpressions;
	using System.Windows.Forms;
	public partial class DoubleTextBox : TextBox
	{
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private new readonly Color DefaultBackColor;
		private readonly Regex empty = new Regex ( "^-?[,.]?$" );
		public int FractionalPlaces
		{
			get => nfi.NumberDecimalDigits;
			set
			{
				try
				{
					nfi.NumberDecimalDigits = value;
				}
				catch { throw; }
			}
		}
		private readonly NumberFormatInfo nfi = ( NumberFormatInfo ) NumberFormatInfo.CurrentInfo.Clone ( );
		[DefaultValue ( null )]
		public double? Value
		{
			get => this.IsEmpty ( ) || !IsCorrect ? null : ( double? ) this.ToDouble ( );
			set
			{
				if ( value == null )
				{
					ResetText ( );
				}
				else
				{
					Text = ( ( double ) value ).ToString ( "F", nfi );
				}
				SelectionStart = Text.Length;
				OnValueChanged ( EventArgs.Empty );
			}
		}
		public static implicit operator double? ( DoubleTextBox dtb ) => dtb.Value;
		public static implicit operator double ( DoubleTextBox dtb ) => ( ( ( double? ) dtb ) ?? 0D );
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
					toolTip1.SetToolTip ( this, default_tooltip );
				}
			}
		}
		[DefaultValue ( "" )]
		public string Wrong_tooltip
		{
			get;
			set;
		}
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
					KeyPress -= DoubleTextBox_KeyPress_NoMinus;
				}
				else
				{
					KeyPress += DoubleTextBox_KeyPress_NoMinus;
					DeleteMinus ( );
				}
			}
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
		public bool IsCorrect => this.IsEmpty ( ) || Regex.IsEmpty ( ) || Checker.IsMatch ( Text );
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
					OnLeave ( EventArgs.Empty );
					break;
			}
			if ( !char.IsDigit ( e.KeyChar ) && !char.IsControl ( e.KeyChar ) )
			{
				e.Handled = true;
			}
		}
		private void DoubleTextBox_TextChanged ( object sender, EventArgs e ) => BackColor = IsCorrect ? DefaultBackColor : Color.Red;
		private void DoubleTextBox_BackColorChanged ( object sender, EventArgs e )
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
		private void DoubleTextBox_Leave ( object sender, EventArgs e )
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
