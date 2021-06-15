namespace CalculatorComponents
{

	partial class OTV
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
			sql.Dispose ( );
			base.Dispose ( disposing );
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.OTV_label0 = new System.Windows.Forms.Label();
			this.OTV_label1 = new System.Windows.Forms.Label();
			this.Depth = new BaseComponents.DoubleTextBox();
			this.OTV_value = new BaseComponents.DoubleTextBox();
			this.SuspendLayout();
			// 
			// OTV_label0
			// 
			this.OTV_label0.AutoSize = true;
			this.OTV_label0.Location = new System.Drawing.Point(7, 3);
			this.OTV_label0.Name = "OTV_label0";
			this.OTV_label0.Size = new System.Drawing.Size(35, 13);
			this.OTV_label0.TabIndex = 0;
			this.OTV_label0.Text = "ОТВ (";
			// 
			// OTV_label1
			// 
			this.OTV_label1.AutoSize = true;
			this.OTV_label1.Location = new System.Drawing.Point(84, 3);
			this.OTV_label1.Name = "OTV_label1";
			this.OTV_label1.Size = new System.Drawing.Size(19, 13);
			this.OTV_label1.TabIndex = 1;
			this.OTV_label1.Text = ") =";
			// 
			// Depth
			// 
			this.Depth.BackColor = System.Drawing.SystemColors.Window;
			this.Depth.CanBeNegative = false;
			this.Depth.Correct_tooltip = "Глубина";
			this.Depth.Location = new System.Drawing.Point(48, 0);
			this.Depth.MaxLength = 4;
			this.Depth.Name = "Depth";
			this.Depth.Regex = "^$|^(0?[,.][5-9]|[1-9]|[1-2]\\d|30|[1-9][,.]\\d?|[1-2]\\d[,.]\\d?|30[,.]0?)$";
			this.Depth.Size = new System.Drawing.Size(30, 20);
			this.Depth.TabIndex = 2;
			this.Depth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Depth.Value = null;
			this.Depth.Wrong_tooltip = "Допустимые значения параметра [0.5-30.0]";
			this.Depth.TextChanged += new System.EventHandler(this.AB_Depth_Changed_Leave);
			this.Depth.Leave += new System.EventHandler(this.AB_Depth_Changed_Leave);
			// 
			// OTV_value
			// 
			this.OTV_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OTV_value.BackColor = System.Drawing.SystemColors.Window;
			this.OTV_value.CanBeNegative = false;
			this.OTV_value.Correct_tooltip = "Значение коэффициента ОТВ";
			this.OTV_value.Enabled = false;
			this.OTV_value.Location = new System.Drawing.Point(109, 0);
			this.OTV_value.MaxLength = 5;
			this.OTV_value.Name = "OTV_value";
			this.OTV_value.Regex = "";
			this.OTV_value.Size = new System.Drawing.Size(38, 20);
			this.OTV_value.TabIndex = 3;
			this.OTV_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.OTV_value.Value = null;
			this.OTV_value.Wrong_tooltip = null;
			// 
			// OTV
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.OTV_value);
			this.Controls.Add(this.Depth);
			this.Controls.Add(this.OTV_label1);
			this.Controls.Add(this.OTV_label0);
			this.MinimumSize = new System.Drawing.Size(150, 20);
			this.Name = "OTV";
			this.Size = new System.Drawing.Size(150, 20);
			this.Leave += new System.EventHandler(this.OTV_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label OTV_label0;
		private System.Windows.Forms.Label OTV_label1;
		private BaseComponents.DoubleTextBox Depth;
		private BaseComponents.DoubleTextBox OTV_value;
	}
}
