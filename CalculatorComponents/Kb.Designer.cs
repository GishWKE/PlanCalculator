using CalculatorComponents.Properties;

namespace CalculatorComponents
{

	partial class Kb_Control
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
			this.Kb_label0 = new System.Windows.Forms.Label();
			this.A_size = new BaseComponents.IntTextBox();
			this.B_size = new BaseComponents.IntTextBox();
			this.Kb_label1 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.Kb = new BaseComponents.DoubleTextBox();
			this.SuspendLayout();
			// 
			// Kb_label0
			// 
			this.Kb_label0.AutoSize = true;
			this.Kb_label0.Location = new System.Drawing.Point(3, 3);
			this.Kb_label0.Name = "Kb_label0";
			this.Kb_label0.Size = new System.Drawing.Size(26, 13);
			this.Kb_label0.TabIndex = 0;
			this.Kb_label0.Text = "Кб (";
			// 
			// A_size
			// 
			this.A_size.BackColor = System.Drawing.SystemColors.Window;
			this.A_size.CanBeNegative = false;
			this.A_size.Correct_tooltip = Resource.ToolTip_Kb_A;
			this.A_size.Location = new System.Drawing.Point(35, 0);
			this.A_size.MaxLength = 2;
			this.A_size.Name = "A_size";
			this.A_size.Regex = Resource.RegEx_AB;
			this.A_size.Size = new System.Drawing.Size(20, 20);
			this.A_size.TabIndex = 1;
			this.A_size.Tag = "A";
			this.A_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.A_size.Value = null;
			this.A_size.Wrong_tooltip = Resource.ToolTip_Kb_AB_wrong;
			this.A_size.TextChanged += new System.EventHandler(this.AB_Changed_Leave);
			this.A_size.Leave += new System.EventHandler(this.AB_Changed_Leave);
			// 
			// B_size
			// 
			this.B_size.CanBeNegative = false;
			this.B_size.Correct_tooltip = Resource.ToolTip_Kb_B;
			this.B_size.Location = new System.Drawing.Point(79, 0);
			this.B_size.MaxLength = 2;
			this.B_size.Name = "B_size";
			this.B_size.Regex = Resource.RegEx_AB;
			this.B_size.Size = new System.Drawing.Size(20, 20);
			this.B_size.TabIndex = 3;
			this.B_size.Tag = "B";
			this.B_size.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.B_size.Value = null;
			this.B_size.Wrong_tooltip = Resource.ToolTip_Kb_AB_wrong;
			this.B_size.TextChanged += new System.EventHandler(this.AB_Changed_Leave);
			this.B_size.Leave += new System.EventHandler(this.AB_Changed_Leave);
			// 
			// Kb_label1
			// 
			this.Kb_label1.AutoSize = true;
			this.Kb_label1.Location = new System.Drawing.Point(61, 3);
			this.Kb_label1.Name = "Kb_label1";
			this.Kb_label1.Size = new System.Drawing.Size(12, 13);
			this.Kb_label1.TabIndex = 2;
			this.Kb_label1.Text = "x";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = ") =";
			// 
			// Kb
			// 
			this.Kb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Kb.CanBeNegative = false;
			this.Kb.Correct_tooltip = Resource.ToolTip_Kb;
			this.Kb.FractionalPlaces = 3;
			this.Kb.Location = new System.Drawing.Point(130, 0);
			this.Kb.MaxLength = 5;
			this.Kb.Name = "Kb";
			this.Kb.ReadOnly = true;
			this.Kb.Regex = "";
			this.Kb.Size = new System.Drawing.Size(51, 20);
			this.Kb.TabIndex = 5;
			this.Kb.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Kb.Value = null;
			this.Kb.Wrong_tooltip = null;
			// 
			// Kb_Control
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Kb);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.B_size);
			this.Controls.Add(this.Kb_label1);
			this.Controls.Add(this.A_size);
			this.Controls.Add(this.Kb_label0);
			this.MinimumSize = new System.Drawing.Size(184, 20);
			this.Name = "Kb_Control";
			this.Size = new System.Drawing.Size(184, 20);
			this.Leave += new System.EventHandler(this.Kb_Control_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Kb_label0;
		public BaseComponents.IntTextBox A_size;
		public BaseComponents.IntTextBox B_size;
		private System.Windows.Forms.Label Kb_label1;
		private System.Windows.Forms.Label label1;
		public BaseComponents.DoubleTextBox Kb;
	}
}
