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
			this.label1 = new System.Windows.Forms.Label();
			this.WeightValue = new BaseComponents.DoubleTextBox();
			this.Time_value = new CalculatorComponents.Time();
			this.L_value = new CalculatorComponents.Lung();
			this.OTV_value = new CalculatorComponents.OTV();
			this.Kb_value = new CalculatorComponents.Kb_Control();
			this.FieldPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// FieldPanel
			// 
			this.FieldPanel.Controls.Add(this.WeightValue);
			this.FieldPanel.Controls.Add(this.label1);
			this.FieldPanel.Controls.Add(this.Time_value);
			this.FieldPanel.Controls.Add(this.L_value);
			this.FieldPanel.Controls.Add(this.OTV_value);
			this.FieldPanel.Controls.Add(this.Kb_value);
			this.FieldPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FieldPanel.Location = new System.Drawing.Point(0, 0);
			this.FieldPanel.Name = "FieldPanel";
			this.FieldPanel.Size = new System.Drawing.Size(650, 70);
			this.FieldPanel.TabIndex = 0;
			this.FieldPanel.TabStop = false;
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
			// WeightValue
			// 
			this.WeightValue.BackColor = System.Drawing.SystemColors.Window;
			this.WeightValue.Correct_tooltip = "Весовой коэфициент";
			this.WeightValue.FractionalPlaces = 3;
			this.WeightValue.Location = new System.Drawing.Point(38, 48);
			this.WeightValue.Name = "WeightValue";
			this.WeightValue.Size = new System.Drawing.Size(50, 20);
			this.WeightValue.TabIndex = 5;
			this.WeightValue.Text = "1,000";
			this.WeightValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.WeightValue.Value = 1D;
			this.WeightValue.Wrong_tooltip = null;
			this.WeightValue.ValueChanged += new System.EventHandler(this.AllRecalculate);
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
			// Kb_value
			// 
			this.Kb_value.FileName = null;
			this.Kb_value.Location = new System.Drawing.Point(6, 19);
			this.Kb_value.MinimumSize = new System.Drawing.Size(184, 20);
			this.Kb_value.Name = "Kb_value";
			this.Kb_value.Size = new System.Drawing.Size(184, 20);
			this.Kb_value.TabIndex = 0;
			this.Kb_value.ValueChanged += new System.EventHandler(this.Any_ValueChanged);
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
		private Kb_Control Kb_value;
		private Time Time_value;
		private BaseComponents.DoubleTextBox WeightValue;
		private System.Windows.Forms.Label label1;
	}
}
