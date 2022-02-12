namespace BaseComponents
{
	using System;
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
		public void SetToolTip ( bool isCorrect )
		{
			var txt = isCorrect ? Correct_tooltip : Wrong_tooltip;
			toolTip.ToolTipIcon = isCorrect ? ToolTipIcon.Info : ToolTipIcon.Error;
			toolTip.RemoveAll ( );
			if ( !txt.IsEmpty ( ) )
			{
				toolTip.SetToolTip ( this, txt );
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
