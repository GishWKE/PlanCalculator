namespace BaseComponents
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Runtime.InteropServices;
	using System.Windows.Forms;

	using BaseComponents.ToolTip;
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

		private readonly Dictionary<bool, TT_Type> TT = new Dictionary<bool, TT_Type> { { false, null }, { true, null } };

		[DefaultValue ( "" )]
		public string Correct_tooltip
		{
			get => TT [ true ] ?? string.Empty;
			set
			{
				toolTip.RemoveAll ( );
				TT [ true ] = null;
				if ( !value.IsEmpty ( ) )
				{
					TT [ true ] = new TT_Type ( (text: value, icon: ToolTipIcon.Info) );
					SetToolTip ( true );
				}
			}
		}
		[DefaultValue ( "" )]
		public string Wrong_tooltip
		{
			get => TT [ false ] ?? string.Empty;
			set
			{
				TT [ false ] = null;
				if ( !value.IsEmpty ( ) )
				{
					TT [ false ] = new TT_Type ( (text: value, icon: ToolTipIcon.Error) );
				}
			}
		}
		public void SetToolTip ( bool isCorrect )
		{
			toolTip.RemoveAll ( );
			if ( TT [ isCorrect ] != null && ( bool ) TT [ isCorrect ] )
			{
				toolTip.ToolTipIcon = ( ToolTipIcon ) TT [ isCorrect ];
				toolTip.SetToolTip ( this, TT [ isCorrect ] );
			}
		}
		#endregion
		public MyTextBox ( ) : base ( ) => InitializeComponent ( );
	}
}
