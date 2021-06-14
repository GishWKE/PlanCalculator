namespace PlanCalculator
{
	using System.Windows.Forms;
	partial class Form1
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

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.components = new System.ComponentModel.Container();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.B = new System.Windows.Forms.NumericUpDown();
			this.B_label = new System.Windows.Forms.Label();
			this.A = new System.Windows.Forms.NumericUpDown();
			this.A_label = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.FieldsCount = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.N = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.Dose_panel = new System.Windows.Forms.Panel();
			this.Dose_label2 = new System.Windows.Forms.Label();
			this.D = new BaseComponents.DoubleTextBox();
			this.Dose_label1 = new System.Windows.Forms.Label();
			this.P = new BaseComponents.IntTextBox();
			this.Dose_label0 = new System.Windows.Forms.Label();
			this.Devices = new CalculatorComponents.Device();
			this.AllFields = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.A)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FieldsCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.N)).BeginInit();
			this.Dose_panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			this.splitContainer1.Panel1.Controls.Add(this.Dose_panel);
			this.splitContainer1.Panel1.Controls.Add(this.Devices);
			this.splitContainer1.Panel1MinSize = 390;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.AllFields);
			this.splitContainer1.Size = new System.Drawing.Size(1084, 461);
			this.splitContainer1.SplitterDistance = 401;
			this.splitContainer1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.B);
			this.panel2.Controls.Add(this.B_label);
			this.panel2.Controls.Add(this.A);
			this.panel2.Controls.Add(this.A_label);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 127);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(401, 20);
			this.panel2.TabIndex = 3;
			// 
			// B
			// 
			this.B.Location = new System.Drawing.Point(226, 0);
			this.B.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.B.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.B.Name = "B";
			this.B.Size = new System.Drawing.Size(157, 20);
			this.B.TabIndex = 3;
			this.toolTip1.SetToolTip(this.B, "Высота поля");
			this.B.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.B.ValueChanged += new System.EventHandler(this.AB_ValueChanged);
			// 
			// B_label
			// 
			this.B_label.AutoSize = true;
			this.B_label.Location = new System.Drawing.Point(196, 2);
			this.B_label.Name = "B_label";
			this.B_label.Size = new System.Drawing.Size(23, 13);
			this.B_label.TabIndex = 2;
			this.B_label.Text = "B =";
			this.toolTip1.SetToolTip(this.B_label, "Высота поля");
			// 
			// A
			// 
			this.A.Location = new System.Drawing.Point(30, 0);
			this.A.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.A.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.A.Name = "A";
			this.A.Size = new System.Drawing.Size(160, 20);
			this.A.TabIndex = 1;
			this.toolTip1.SetToolTip(this.A, "Ширина поля");
			this.A.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.A.ValueChanged += new System.EventHandler(this.AB_ValueChanged);
			// 
			// A_label
			// 
			this.A_label.AutoSize = true;
			this.A_label.Location = new System.Drawing.Point(0, 2);
			this.A_label.Name = "A_label";
			this.A_label.Size = new System.Drawing.Size(23, 13);
			this.A_label.TabIndex = 0;
			this.A_label.Text = "A =";
			this.toolTip1.SetToolTip(this.A_label, "Ширина поля");
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.FieldsCount);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.N);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 107);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(401, 20);
			this.panel1.TabIndex = 2;
			// 
			// FieldsCount
			// 
			this.FieldsCount.Location = new System.Drawing.Point(226, 0);
			this.FieldsCount.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
			this.FieldsCount.Name = "FieldsCount";
			this.FieldsCount.Size = new System.Drawing.Size(157, 20);
			this.FieldsCount.TabIndex = 3;
			this.toolTip1.SetToolTip(this.FieldsCount, "Число полей");
			this.FieldsCount.ValueChanged += new System.EventHandler(this.FieldCount_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(196, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(22, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "n =";
			this.toolTip1.SetToolTip(this.label2, "Число полей");
			// 
			// N
			// 
			this.N.Location = new System.Drawing.Point(30, 0);
			this.N.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.N.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.N.Name = "N";
			this.N.ReadOnly = true;
			this.N.Size = new System.Drawing.Size(160, 20);
			this.N.TabIndex = 1;
			this.toolTip1.SetToolTip(this.N, "Число изоцентров");
			this.N.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.N.ValueChanged += new System.EventHandler(this.Dose_Changed);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "N =";
			this.toolTip1.SetToolTip(this.label1, "Число изоцентров");
			// 
			// Dose_panel
			// 
			this.Dose_panel.Controls.Add(this.Dose_label2);
			this.Dose_panel.Controls.Add(this.D);
			this.Dose_panel.Controls.Add(this.Dose_label1);
			this.Dose_panel.Controls.Add(this.P);
			this.Dose_panel.Controls.Add(this.Dose_label0);
			this.Dose_panel.Dock = System.Windows.Forms.DockStyle.Top;
			this.Dose_panel.Location = new System.Drawing.Point(0, 87);
			this.Dose_panel.Name = "Dose_panel";
			this.Dose_panel.Size = new System.Drawing.Size(401, 20);
			this.Dose_panel.TabIndex = 1;
			// 
			// Dose_label2
			// 
			this.Dose_label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Dose_label2.AutoSize = true;
			this.Dose_label2.Location = new System.Drawing.Point(379, 3);
			this.Dose_label2.Name = "Dose_label2";
			this.Dose_label2.Size = new System.Drawing.Size(19, 13);
			this.Dose_label2.TabIndex = 4;
			this.Dose_label2.Text = "Гр";
			// 
			// D
			// 
			this.D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.D.BackColor = System.Drawing.SystemColors.Window;
			this.D.CanBeNegative = false;
			this.D.Correct_tooltip = "Разовая доза";
			this.D.Location = new System.Drawing.Point(96, 0);
			this.D.Name = "D";
			this.D.regex = "";
			this.D.Size = new System.Drawing.Size(277, 20);
			this.D.TabIndex = 3;
			this.D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.D.Value = null;
			this.D.Wrong_tooltip = null;
			this.D.Leave += new System.EventHandler(this.Dose_Changed);
			// 
			// Dose_label1
			// 
			this.Dose_label1.AutoSize = true;
			this.Dose_label1.Location = new System.Drawing.Point(60, 3);
			this.Dose_label1.Name = "Dose_label1";
			this.Dose_label1.Size = new System.Drawing.Size(30, 13);
			this.Dose_label1.TabIndex = 2;
			this.Dose_label1.Text = "% ) =";
			// 
			// P
			// 
			this.P.BackColor = System.Drawing.SystemColors.Window;
			this.P.CanBeNegative = false;
			this.P.Correct_tooltip = "Процентная разовая доза";
			this.P.Location = new System.Drawing.Point(30, 0);
			this.P.MaxLength = 3;
			this.P.Name = "P";
			this.P.regex = "";
			this.P.Size = new System.Drawing.Size(24, 20);
			this.P.TabIndex = 1;
			this.P.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.P.Value = null;
			this.P.Wrong_tooltip = null;
			this.P.Leave += new System.EventHandler(this.Dose_Changed);
			// 
			// Dose_label0
			// 
			this.Dose_label0.AutoSize = true;
			this.Dose_label0.Location = new System.Drawing.Point(3, 3);
			this.Dose_label0.Name = "Dose_label0";
			this.Dose_label0.Size = new System.Drawing.Size(21, 13);
			this.Dose_label0.TabIndex = 0;
			this.Dose_label0.Text = "D (";
			// 
			// Devices
			// 
			this.Devices.Dock = System.Windows.Forms.DockStyle.Top;
			this.Devices.FileName = "";
			this.Devices.Location = new System.Drawing.Point(0, 0);
			this.Devices.Name = "Devices";
			this.Devices.SCD = null;
			this.Devices.Size = new System.Drawing.Size(401, 87);
			this.Devices.TabIndex = 0;
			// 
			// AllFields
			// 
			this.AllFields.AutoScroll = true;
			this.AllFields.Dock = System.Windows.Forms.DockStyle.Fill;
			this.AllFields.Location = new System.Drawing.Point(0, 0);
			this.AllFields.Name = "AllFields";
			this.AllFields.Size = new System.Drawing.Size(679, 461);
			this.AllFields.TabIndex = 0;
			// 
			// toolTip1
			// 
			this.toolTip1.IsBalloon = true;
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(1084, 461);
			this.Controls.Add(this.splitContainer1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1100, 500);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1100, 190);
			this.Name = "Form1";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.A)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FieldsCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.N)).EndInit();
			this.Dose_panel.ResumeLayout(false);
			this.Dose_panel.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private SplitContainer splitContainer1;
		private CalculatorComponents.Device Devices;
		private FlowLayoutPanel AllFields;
		private Panel Dose_panel;
		private Label Dose_label2;
		private BaseComponents.DoubleTextBox D;
		private Label Dose_label1;
		private BaseComponents.IntTextBox P;
		private Label Dose_label0;
		private Panel panel1;
		private NumericUpDown FieldsCount;
		private Label label2;
		private NumericUpDown N;
		private Label label1;
		private Panel panel2;
		private NumericUpDown B;
		private Label B_label;
		private NumericUpDown A;
		private Label A_label;
		private ToolTip toolTip1;
	}
}

