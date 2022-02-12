namespace BaseComponents
{
	partial class MyTextBox
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent ( )
		{
			components = new System.ComponentModel.Container ( );

			this.toolTip = new System.Windows.Forms.ToolTip ( this.components );
			this.SuspendLayout ( );
			// 
			// toolTip
			// 
			this.toolTip.AutoPopDelay = 5000;
			this.toolTip.InitialDelay = 200;
			this.toolTip.IsBalloon = true;
			this.toolTip.ReshowDelay = 100;
			this.toolTip.ShowAlways = true;
			this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTip.ToolTipTitle = "Информация о поле ввода";
			// 
			// NumericTextBox
			// 
			this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.ResumeLayout ( false );

		}

		#endregion
		private System.Windows.Forms.ToolTip toolTip;
	}
}
