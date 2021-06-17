namespace CalculatorComponents
{

	partial class Lung
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
			this.IsLung = new System.Windows.Forms.CheckBox();
			this.Lung_parameters = new System.Windows.Forms.Panel();
			this.L = new BaseComponents.DoubleTextBox();
			this.Thickness = new BaseComponents.DoubleTextBox();
			this.Distance = new BaseComponents.IntTextBox();
			this.L_label2 = new System.Windows.Forms.Label();
			this.L_label1 = new System.Windows.Forms.Label();
			this.L_label0 = new System.Windows.Forms.Label();
			this.Lung_parameters.SuspendLayout();
			this.SuspendLayout();
			// 
			// IsLung
			// 
			this.IsLung.AutoSize = true;
			this.IsLung.Location = new System.Drawing.Point(3, 3);
			this.IsLung.Name = "IsLung";
			this.IsLung.Size = new System.Drawing.Size(106, 17);
			this.IsLung.TabIndex = 0;
			this.IsLung.Text = "Легочная ткань";
			this.IsLung.UseVisualStyleBackColor = true;
			this.IsLung.CheckedChanged += new System.EventHandler(this.IsLung_CheckedChanged);
			// 
			// Lung_parameters
			// 
			this.Lung_parameters.Controls.Add(this.L);
			this.Lung_parameters.Controls.Add(this.Thickness);
			this.Lung_parameters.Controls.Add(this.Distance);
			this.Lung_parameters.Controls.Add(this.L_label2);
			this.Lung_parameters.Controls.Add(this.L_label1);
			this.Lung_parameters.Controls.Add(this.L_label0);
			this.Lung_parameters.Location = new System.Drawing.Point(115, 0);
			this.Lung_parameters.Name = "Lung_parameters";
			this.Lung_parameters.Size = new System.Drawing.Size(175, 22);
			this.Lung_parameters.TabIndex = 1;
			this.Lung_parameters.Visible = false;
			// 
			// L
			// 
			this.L.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.L.CanBeNegative = false;
			this.L.Correct_tooltip = "Значние коэффициента L";
			this.L.FractionalPlaces = 3;
			this.L.Location = new System.Drawing.Point(131, 0);
			this.L.MaxLength = 5;
			this.L.Name = "L";
			this.L.ReadOnly = true;
			this.L.Regex = "";
			this.L.Size = new System.Drawing.Size(41, 20);
			this.L.TabIndex = 5;
			this.L.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.L.Value = null;
			this.L.Wrong_tooltip = null;
			// 
			// Thickness
			// 
			this.Thickness.BackColor = System.Drawing.SystemColors.Window;
			this.Thickness.CanBeNegative = false;
			this.Thickness.Correct_tooltip = "Толщина легочной ткани";
			this.Thickness.FractionalPlaces = 1;
			this.Thickness.Location = new System.Drawing.Point(73, 0);
			this.Thickness.MaxLength = 4;
			this.Thickness.Name = "Thickness";
			this.Thickness.Regex = "^$|^(0?[,.][5-9]|[1-9]|1[0-1]|12|[1-9][,.]\\d?|1[0-1][,.]\\d?|12[,.]0?)$";
			this.Thickness.Size = new System.Drawing.Size(27, 20);
			this.Thickness.TabIndex = 4;
			this.Thickness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Thickness.Value = null;
			this.Thickness.Wrong_tooltip = "Допустимые значения параметра [0.5-12.0]";
			this.Thickness.Leave += new System.EventHandler(this.DT_Leave);
			// 
			// Distance
			// 
			this.Distance.BackColor = System.Drawing.SystemColors.Window;
			this.Distance.CanBeNegative = false;
			this.Distance.Correct_tooltip = "Расстояние от точки расчета до легкого (не более)";
			this.Distance.Location = new System.Drawing.Point(28, 0);
			this.Distance.MaxLength = 2;
			this.Distance.Name = "Distance";
			this.Distance.Regex = "^$|^([1-9]|1[0-4])$";
			this.Distance.Size = new System.Drawing.Size(23, 20);
			this.Distance.TabIndex = 3;
			this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Distance.Value = null;
			this.Distance.Wrong_tooltip = "Допустимые значения параметра [1-14]";
			this.Distance.Leave += new System.EventHandler(this.DT_Leave);
			// 
			// L_label2
			// 
			this.L_label2.AutoSize = true;
			this.L_label2.Location = new System.Drawing.Point(106, 3);
			this.L_label2.Name = "L_label2";
			this.L_label2.Size = new System.Drawing.Size(19, 13);
			this.L_label2.TabIndex = 2;
			this.L_label2.Text = ") =";
			// 
			// L_label1
			// 
			this.L_label1.AutoSize = true;
			this.L_label1.Location = new System.Drawing.Point(57, 3);
			this.L_label1.Name = "L_label1";
			this.L_label1.Size = new System.Drawing.Size(10, 13);
			this.L_label1.TabIndex = 1;
			this.L_label1.Text = ",";
			// 
			// L_label0
			// 
			this.L_label0.AutoSize = true;
			this.L_label0.Location = new System.Drawing.Point(3, 3);
			this.L_label0.Name = "L_label0";
			this.L_label0.Size = new System.Drawing.Size(19, 13);
			this.L_label0.TabIndex = 0;
			this.L_label0.Text = "L (";
			// 
			// Lung
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Lung_parameters);
			this.Controls.Add(this.IsLung);
			this.MinimumSize = new System.Drawing.Size(290, 20);
			this.Name = "Lung";
			this.Size = new System.Drawing.Size(290, 20);
			this.Leave += new System.EventHandler(this.Lung_Leave);
			this.Lung_parameters.ResumeLayout(false);
			this.Lung_parameters.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox IsLung;
		private System.Windows.Forms.Panel Lung_parameters;
		private BaseComponents.IntTextBox Distance;
		private System.Windows.Forms.Label L_label2;
		private System.Windows.Forms.Label L_label1;
		private System.Windows.Forms.Label L_label0;
		private BaseComponents.DoubleTextBox Thickness;
		private BaseComponents.DoubleTextBox L;
	}
}
