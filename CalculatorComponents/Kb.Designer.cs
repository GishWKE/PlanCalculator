namespace CalculatorComponents
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Drawing;
	using Resource;
	using Resource.Properties;
	using BaseComponents;

	partial class Kb_Control
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private IContainer components = null;

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
			this.Kb_label0 = new Label();
			this.A_size = new BaseComponents.IntTextBox();
			this.B_size = new BaseComponents.IntTextBox();
			this.Kb_label1 = new Label();
			this.label1 = new Label();
			this.Kb = new BaseComponents.DoubleTextBox();
			this.SuspendLayout();
			// 
			// Kb_label0
			// 
			this.Kb_label0.AutoSize = true;
			this.Kb_label0.Location = new Point(3, 3);
			this.Kb_label0.Name = "Kb_label0";
			this.Kb_label0.Size = new Size(26, 13);
			this.Kb_label0.TabIndex = 0;
			this.Kb_label0.Text = "Кб (";
			// 
			// A_size
			// 
			this.A_size.BackColor = SystemColors.Window;
			this.A_size.CanBeNegative = false;
			this.A_size.Correct_tooltip = ToolTips.A;
			this.A_size.Location = new Point(35, 0);
			this.A_size.MaxLength = 2;
			this.A_size.Name = "A_size";
			this.A_size.Regex = RegEx.AB;
			this.A_size.Size = new Size(20, 20);
			this.A_size.TabIndex = 1;
			this.A_size.Tag = "A";
			this.A_size.TextAlign = HorizontalAlignment.Right;
			this.A_size.Value = null;
			this.A_size.Wrong_tooltip = ToolTips.AB_wrong;
			this.A_size.TextChanged += new EventHandler(this.AB_Changed_Leave);
			this.A_size.Leave += new EventHandler(this.AB_Changed_Leave);
			// 
			// B_size
			// 
			this.B_size.CanBeNegative = false;
			this.B_size.Correct_tooltip = ToolTips.B;
			this.B_size.Location = new Point(79, 0);
			this.B_size.MaxLength = 2;
			this.B_size.Name = "B_size";
			this.B_size.Regex = RegEx.AB;
			this.B_size.Size = new Size(20, 20);
			this.B_size.TabIndex = 3;
			this.B_size.Tag = "B";
			this.B_size.TextAlign = HorizontalAlignment.Right;
			this.B_size.Value = null;
			this.B_size.Wrong_tooltip = ToolTips.AB_wrong;
			this.B_size.TextChanged += new EventHandler(this.AB_Changed_Leave);
			this.B_size.Leave += new EventHandler(this.AB_Changed_Leave);
			// 
			// Kb_label1
			// 
			this.Kb_label1.AutoSize = true;
			this.Kb_label1.Location = new Point(61, 3);
			this.Kb_label1.Name = "Kb_label1";
			this.Kb_label1.Size = new Size(12, 13);
			this.Kb_label1.TabIndex = 2;
			this.Kb_label1.Text = "x";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new Point(105, 3);
			this.label1.Name = "label1";
			this.label1.Size = new Size(19, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = ") =";
			// 
			// Kb
			// 
			this.Kb.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.Kb.CanBeNegative = false;
			this.Kb.Correct_tooltip = ToolTips.Kb;
			this.Kb.FractionalPlaces = 3;
			this.Kb.Location = new Point(130, 0);
			this.Kb.MaxLength = 5;
			this.Kb.Name = "Kb";
			this.Kb.ReadOnly = true;
			this.Kb.Regex = "";
			this.Kb.Size = new Size(51, 20);
			this.Kb.TabIndex = 5;
			this.Kb.TextAlign = HorizontalAlignment.Right;
			this.Kb.Value = null;
			this.Kb.Wrong_tooltip = null;
			// 
			// Kb_Control
			// 
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.Kb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.B_size);
			this.Controls.Add(this.Kb_label1);
			this.Controls.Add(this.A_size);
			this.Controls.Add(this.Kb_label0);
			this.MinimumSize = new Size(184, 20);
			this.Name = "Kb_Control";
			this.Size = new Size(184, 20);
			this.Leave += new EventHandler(this.Kb_Control_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label Kb_label0;
		public BaseComponents.IntTextBox A_size;
		public BaseComponents.IntTextBox B_size;
		private Label Kb_label1;
		private Label label1;
		public BaseComponents.DoubleTextBox Kb;
	}
}
