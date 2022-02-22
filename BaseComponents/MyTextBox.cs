namespace BaseComponents
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Drawing;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;
	[Description ( "Текстовое поле с заполнителем (placeholder) и выпадающими подсказками для правильного и неправильного ввода" )]
	public partial class MyTextBox : TextBox
	{
		#region Placeholder
		private const int EM_SETCUEBANNER = 0x1501;
		[DllImport ( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		[return: MarshalAs ( UnmanagedType.Bool )]
		private static extern bool SendMessage ( IntPtr hWnd, int msg, [MarshalAs ( UnmanagedType.Bool )] bool wParam, [MarshalAs ( UnmanagedType.LPWStr )] string lParam );
		private string _placeHolder = string.Empty;
		[DefaultValue ( null )]
		public string PlaceHolder
		{
			get => _placeHolder;
			set
			{
				_placeHolder = value ?? string.Empty;
				if ( !SendMessage ( Handle, EM_SETCUEBANNER, false, _placeHolder ) )
				{
					throw new Win32Exception ( Marshal.GetLastWin32Error ( ) );
				}
			}
		}
		#endregion
		#region ToolTip
		private class TT_Type
		{
			public string Text;
			public ToolTipIcon Icon;
			public TT_Type ( (string text, ToolTipIcon icon) val )
			{
				Text = val.text;
				Icon = val.icon;
			}
			public static implicit operator bool ( TT_Type o ) => !( ( string ) o ).IsEmpty ( );
			public static implicit operator string ( TT_Type o ) => o.Text;
			public static implicit operator ToolTipIcon ( TT_Type o ) => o.Icon;
		}
		private readonly Dictionary<bool, TT_Type> TT = new Dictionary<bool, TT_Type> { { false, null }, { true, null } };

		[DefaultValue ( "" )]
		public string Correct_tooltip
		{
			get => TT [ true ];
			set
			{
				toolTip.RemoveAll ( );
				if ( !value.IsEmpty ( ) )
				{
					TT [ true ] = new TT_Type ( (text: value, icon: ToolTipIcon.Info) );
					SetToolTip ( true );
				}
				else
				{
					TT [ true ] = null;
				}
			}
		}
		[DefaultValue ( "" )]
		public string Wrong_tooltip
		{
			get => TT [ false ];
			set
			{
				if ( !value.IsEmpty ( ) )
				{
					TT [ false ] = new TT_Type ( (text: value, icon: ToolTipIcon.Error) );
				}
				else
				{
					TT [ false ] = null;
				}
			}
		}
		public void SetToolTip ( bool isCorrect )
		{
			toolTip.RemoveAll ( );
			if ( TT [ isCorrect ] != null && TT [ isCorrect ] )
			{
				toolTip.ToolTipIcon = TT [ isCorrect ];
				toolTip.SetToolTip ( this, TT [ isCorrect ] );
			}
		}
		#endregion
		private new readonly Color DefaultBackColor;
		public MyTextBox ( ) : base ( )
		{
			DefaultBackColor = base.BackColor;
			InitializeComponent ( );
		}
	}
}
