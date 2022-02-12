﻿namespace BaseComponents
{
	partial class NumericTextBox
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
			this.components = new System.ComponentModel.Container();
			this.SuspendLayout();
			// 
			// NumericTextBox
			// 
			this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.BackColorChanged += new System.EventHandler(this.NumericTextBox_BackColorChanged);
			this.TextChanged += new System.EventHandler(this.NumericTextBox_TextChanged);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumericTextBox_KeyPress);
			this.Leave += new System.EventHandler(this.NumericTextBox_Leave);
			this.ResumeLayout(false);

		}

		#endregion
	}
}
