namespace BaseComponents
{
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Windows.Forms;
	[Description ( "Текстовое поле с заполнителем (placeholder) и выпадающими подсказками для правильного и неправильного ввода" )]
	public partial class MyTextBox : TextBox
	{
		#region Placeholder
		[DefaultValue ( null )]
		public string PlaceHolder
		{
			get => this.GetPlaceholder ( );
			set => this.SetPlaceholder ( value );
		}
		#endregion
		#region ToolTip
		private readonly Dictionary<bool, TT_Type> TT = new Dictionary<bool, TT_Type> { { false, new TT_Type ( null, ToolTipIcon.Error ) }, { true, new TT_Type ( null, ToolTipIcon.Info ) } };

		[DefaultValue ( "" )]
		public string Correct_tooltip
		{
			get => TT [ true ];
			set
			{
				TT [ true ].Text = value;
				SetToolTip ( true );
			}
		}
		[DefaultValue ( "" )]
		public string Wrong_tooltip
		{
			get => TT [ false ];
			set => TT [ false ].Text = value;
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
		public MyTextBox ( ) : base ( ) => InitializeComponent ( );
	}
}
