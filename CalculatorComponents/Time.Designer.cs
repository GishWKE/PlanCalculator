namespace CalculatorComponents
{

	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Drawing;
	using Resource;
	using Resource.Properties;
	using BaseComponents;
	partial class Time
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
			this.Time_label0 = new System.Windows.Forms.Label();
			this.Time_label1 = new System.Windows.Forms.Label();
			this.Time_value = new BaseComponents.DoubleTextBox();
			this.SuspendLayout();
			// 
			// Time_label0
			// 
			this.Time_label0.AutoSize = true;
			this.Time_label0.Location = new System.Drawing.Point(1, 3);
			this.Time_label0.Name = "Time_label0";
			this.Time_label0.Size = new System.Drawing.Size(26, 13);
			this.Time_label0.TabIndex = 0;
			this.Time_label0.Text = "T = ";
			// 
			// Time_label1
			// 
			this.Time_label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Time_label1.AutoSize = true;
			this.Time_label1.Location = new System.Drawing.Point(139, 3);
			this.Time_label1.Name = "Time_label1";
			this.Time_label1.Size = new System.Drawing.Size(0, 13);
			this.Time_label1.TabIndex = 1;
			// 
			// Time_value
			// 
			this.Time_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Time_value.BackColor = System.Drawing.SystemColors.Window;
			this.Time_value.CanBeNegative = false;
			this.Time_value.Correct_tooltip = "";
			this.Time_value.FractionalPlaces = -1;
			this.Time_value.Location = new System.Drawing.Point(33, 0);
			this.Time_value.MaxLength = 8;
			this.Time_value.Name = "Time_value";
			this.Time_value.ReadOnly = true;
			this.Time_value.Regex = "";
			this.Time_value.Size = new System.Drawing.Size(100, 20);
			this.Time_value.TabIndex = 2;
			this.Time_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Time_value.Value = null;
			this.Time_value.Wrong_tooltip = null;
			// 
			// Time
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Time_value);
			this.Controls.Add(this.Time_label1);
			this.Controls.Add(this.Time_label0);
			this.MinimumSize = new System.Drawing.Size(185, 20);
			this.Name = "Time";
			this.Size = new System.Drawing.Size(185, 20);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Time_label0;
		private System.Windows.Forms.Label Time_label1;
		private BaseComponents.DoubleTextBox Time_value;
	}
}
