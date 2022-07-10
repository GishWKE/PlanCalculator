namespace CalculatorComponents
{

	partial class Field
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
			this.FieldPanel = new System.Windows.Forms.GroupBox();
			this.FieldDegree = new BaseComponents.IntTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.WeightValue = new BaseComponents.DoubleTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Time_value = new CalculatorComponents.Time();
			this.L_value = new CalculatorComponents.Lung();
			this.OTV_value = new CalculatorComponents.OTV();
			this.FieldPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldPanel
			// 
			this.FieldPanel.Controls.Add(this.FieldDegree);
			this.FieldPanel.Controls.Add(this.label3);
			this.FieldPanel.Controls.Add(this.label2);
			this.FieldPanel.Controls.Add(this.WeightValue);
			this.FieldPanel.Controls.Add(this.label1);
			this.FieldPanel.Controls.Add(this.Time_value);
			this.FieldPanel.Controls.Add(this.L_value);
			this.FieldPanel.Controls.Add(this.OTV_value);
			this.FieldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FieldPanel.Location = new System.Drawing.Point(0, 0);
			this.FieldPanel.Name = "FieldPanel";
			this.FieldPanel.Size = new System.Drawing.Size(650, 70);
			this.FieldPanel.TabIndex = 0;
			this.FieldPanel.TabStop = false;
			// 
			// FieldDegree
			// 
			this.FieldDegree.AlwaysPositive = true;
			this.FieldDegree.BackColor = System.Drawing.SystemColors.Window;
			this.FieldDegree.Correct_tooltip = "Угол гантри для поля";
			this.FieldDegree.FractionalPlaces = 0;
			this.FieldDegree.Location = new System.Drawing.Point(315, 48);
			this.FieldDegree.Name = "FieldDegree";
			this.FieldDegree.PlaceHolder = "";
			this.FieldDegree.Regex = "^([12]?\\d{0,2}|3[0-5]\\d|360)?$";
			this.FieldDegree.Size = new System.Drawing.Size(31, 20);
			this.FieldDegree.TabIndex = 8;
			this.FieldDegree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.FieldDegree.Type = BaseComponents.NumericTextBoxTypes.INT;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(349, 47);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(11, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "°";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(294, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(15, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "∠";
			// 
			// WeightValue
			// 
			this.WeightValue.AlwaysPositive = true;
			this.WeightValue.Correct_tooltip = "Весовой коэфициент";
			this.WeightValue.FractionalPlaces = 3;
			this.WeightValue.Location = new System.Drawing.Point(38, 48);
			this.WeightValue.Name = "WeightValue";
			this.WeightValue.PlaceHolder = "";
			this.WeightValue.Size = new System.Drawing.Size(50, 20);
			this.WeightValue.TabIndex = 5;
			this.WeightValue.Text = "1,000";
			this.WeightValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.WeightValue.Type = BaseComponents.NumericTextBoxTypes.DOUBLE;
			this.WeightValue.Value = 1D;
			this.WeightValue.ValueChanged += new System.EventHandler(this.AllRecalculate);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Вес";
			// 
			// Time_value
			// 
			this.Time_value.Location = new System.Drawing.Point(94, 48);
			this.Time_value.MinimumSize = new System.Drawing.Size(185, 20);
			this.Time_value.Name = "Time_value";
			this.Time_value.Size = new System.Drawing.Size(185, 20);
			this.Time_value.TabIndex = 3;
			// 
			// L_value
			// 
			this.L_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.L_value.FileName = null;
			this.L_value.Location = new System.Drawing.Point(352, 19);
			this.L_value.MinimumSize = new System.Drawing.Size(290, 20);
			this.L_value.Name = "L_value";
			this.L_value.Size = new System.Drawing.Size(292, 20);
			this.L_value.TabIndex = 2;
			this.L_value.ValueChanged += new System.EventHandler(this.Any_ValueChanged);
			// 
			// OTV_value
			// 
			this.OTV_value.FileName = null;
			this.OTV_value.Location = new System.Drawing.Point(196, 19);
			this.OTV_value.MinimumSize = new System.Drawing.Size(150, 20);
			this.OTV_value.Name = "OTV_value";
			this.OTV_value.Size = new System.Drawing.Size(150, 20);
			this.OTV_value.TabIndex = 1;
			this.OTV_value.ValueChanged += new System.EventHandler(this.Any_ValueChanged);
			// 
			// Field
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.FieldPanel);
			this.MinimumSize = new System.Drawing.Size(650, 70);
			this.Name = "Field";
			this.Size = new System.Drawing.Size(650, 70);
			this.FieldPanel.ResumeLayout(false);
			this.FieldPanel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox FieldPanel;
		private Lung L_value;
		private OTV OTV_value;
		private Time Time_value;
		private BaseComponents.DoubleTextBox WeightValue;
		private System.Windows.Forms.Label label1;
		private BaseComponents.IntTextBox FieldDegree;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
	}
}
