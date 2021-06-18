namespace PlanCalculator
{
	using System.Windows.Forms;

	using PlanCalculator.Properties;

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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
			this.P1 = new System.Windows.Forms.Panel();
			this.Dose_label2 = new System.Windows.Forms.Label();
			this.D = new BaseComponents.DoubleTextBox();
			this.Dose_label1 = new System.Windows.Forms.Label();
			this.P = new BaseComponents.IntTextBox();
			this.Dose_label0 = new System.Windows.Forms.Label();
			this.P0 = new System.Windows.Forms.Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.SSD = new BaseComponents.DoubleTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Distance = new BaseComponents.DoubleTextBox();
			this.DST = new System.Windows.Forms.Label();
			this.Devices = new CalculatorComponents.Device();
			this.AllFields = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.изменениеМощностиАппаратовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.добавлениеАппаратовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.P1.SuspendLayout();
			this.P0.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.panel2);
			this.splitContainer1.Panel1.Controls.Add(this.panel1);
			this.splitContainer1.Panel1.Controls.Add(this.P1);
			this.splitContainer1.Panel1.Controls.Add(this.P0);
			this.splitContainer1.Panel1.Controls.Add(this.Devices);
			this.splitContainer1.Panel1MinSize = 390;
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.AllFields);
			this.splitContainer1.Size = new System.Drawing.Size(1084, 437);
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
			this.panel2.Location = new System.Drawing.Point(0, 147);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(401, 20);
			this.panel2.TabIndex = 4;
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
			this.toolTip1.SetToolTip(this.B, Resources.ToolTip_B );
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
			this.toolTip1.SetToolTip(this.B_label, Resources.ToolTip_B );
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
			this.toolTip1.SetToolTip(this.A, Resources.ToolTip_A );
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
			this.toolTip1.SetToolTip(this.A_label, Resources.ToolTip_A );
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.FieldsCount);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.N);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 127);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(401, 20);
			this.panel1.TabIndex = 3;
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
			this.toolTip1.SetToolTip(this.FieldsCount, Resources.Fld_Num );
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
			this.toolTip1.SetToolTip(this.label2, Resources.Fld_Num );
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
			this.toolTip1.SetToolTip(this.N, Resources.Isc_Num );
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
			this.toolTip1.SetToolTip(this.label1, Resources.Isc_Num );
			// 
			// P1
			// 
			this.P1.Controls.Add(this.Dose_label2);
			this.P1.Controls.Add(this.D);
			this.P1.Controls.Add(this.Dose_label1);
			this.P1.Controls.Add(this.P);
			this.P1.Controls.Add(this.Dose_label0);
			this.P1.Dock = System.Windows.Forms.DockStyle.Top;
			this.P1.Location = new System.Drawing.Point(0, 107);
			this.P1.Name = "P1";
			this.P1.Size = new System.Drawing.Size(401, 20);
			this.P1.TabIndex = 2;
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
			this.D.FractionalPlaces = -1;
			this.D.Location = new System.Drawing.Point(112, 0);
			this.D.Name = "D";
			this.D.Regex = "";
			this.D.Size = new System.Drawing.Size(261, 20);
			this.D.TabIndex = 3;
			this.D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.D.Value = null;
			this.D.Wrong_tooltip = null;
			this.D.Leave += new System.EventHandler(this.Dose_Changed);
			// 
			// Dose_label1
			// 
			this.Dose_label1.AutoSize = true;
			this.Dose_label1.Location = new System.Drawing.Point(84, 3);
			this.Dose_label1.Name = "Dose_label1";
			this.Dose_label1.Size = new System.Drawing.Size(22, 13);
			this.Dose_label1.TabIndex = 2;
			this.Dose_label1.Text = " ) =";
			// 
			// P
			// 
			this.P.BackColor = System.Drawing.SystemColors.Window;
			this.P.CanBeNegative = false;
			this.P.Correct_tooltip = "Процентная разовая доза";
			this.P.Location = new System.Drawing.Point(45, 0);
			this.P.MaxLength = 3;
			this.P.Name = "P";
			this.P.Regex = "^$|^([1-9]|[1-9]\\d|100)$";
			this.P.Size = new System.Drawing.Size(36, 20);
			this.P.TabIndex = 1;
			this.P.Text = "90";
			this.P.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.P.Value = 90;
			this.P.Wrong_tooltip = "Введено неверное значение";
			this.P.Leave += new System.EventHandler(this.Dose_Changed);
			// 
			// Dose_label0
			// 
			this.Dose_label0.AutoSize = true;
			this.Dose_label0.Location = new System.Drawing.Point(18, 4);
			this.Dose_label0.Name = "Dose_label0";
			this.Dose_label0.Size = new System.Drawing.Size(21, 13);
			this.Dose_label0.TabIndex = 0;
			this.Dose_label0.Text = "D (";
			// 
			// P0
			// 
			this.P0.Controls.Add(this.label4);
			this.P0.Controls.Add(this.SSD);
			this.P0.Controls.Add(this.label3);
			this.P0.Controls.Add(this.Distance);
			this.P0.Controls.Add(this.DST);
			this.P0.Dock = System.Windows.Forms.DockStyle.Top;
			this.P0.Location = new System.Drawing.Point(0, 87);
			this.P0.Name = "P0";
			this.P0.Size = new System.Drawing.Size(401, 20);
			this.P0.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(380, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(21, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "см";
			// 
			// SSD
			// 
			this.SSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SSD.BackColor = System.Drawing.SystemColors.Window;
			this.SSD.CanBeNegative = false;
			this.SSD.Correct_tooltip = "Расстояние источник-поверхность";
			this.SSD.FractionalPlaces = 1;
			this.SSD.Location = new System.Drawing.Point(112, 0);
			this.SSD.MaxLength = 5;
			this.SSD.Name = "SSD";
			this.SSD.ReadOnly = true;
			this.SSD.Regex = "";
			this.SSD.Size = new System.Drawing.Size(261, 20);
			this.SSD.TabIndex = 3;
			this.SSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SSD.Value = null;
			this.SSD.Wrong_tooltip = null;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(87, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = ") =";
			// 
			// Distance
			// 
			this.Distance.BackColor = System.Drawing.SystemColors.Window;
			this.Distance.CanBeNegative = false;
			this.Distance.Correct_tooltip = "Расстояние от точки входа в тело до изоцентра";
			this.Distance.FractionalPlaces = 1;
			this.Distance.Location = new System.Drawing.Point(45, 0);
			this.Distance.MaxLength = 4;
			this.Distance.Name = "Distance";
			this.Distance.Regex = "";
			this.Distance.Size = new System.Drawing.Size(36, 20);
			this.Distance.TabIndex = 1;
			this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Distance.Value = null;
			this.Distance.Wrong_tooltip = "Введено неверное значение";
			this.Distance.TextChanged += new System.EventHandler(this.Distance_Leave);
			this.Distance.Leave += new System.EventHandler(this.Distance_Leave);
			// 
			// DST
			// 
			this.DST.AutoSize = true;
			this.DST.Location = new System.Drawing.Point(3, 3);
			this.DST.Name = "DST";
			this.DST.Size = new System.Drawing.Size(36, 13);
			this.DST.TabIndex = 0;
			this.DST.Text = "РИП (";
			// 
			// Devices
			// 
			this.Devices.Dock = System.Windows.Forms.DockStyle.Top;
			this.Devices.Editable = false;
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
			this.AllFields.Size = new System.Drawing.Size(679, 437);
			this.AllFields.TabIndex = 0;
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.изменениеМощностиАппаратовToolStripMenuItem,
            this.добавлениеАппаратовToolStripMenuItem,
            this.выходToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// изменениеМощностиАппаратовToolStripMenuItem
			// 
			this.изменениеМощностиАппаратовToolStripMenuItem.Name = "изменениеМощностиАппаратовToolStripMenuItem";
			this.изменениеМощностиАппаратовToolStripMenuItem.Size = new System.Drawing.Size(168, 20);
			this.изменениеМощностиАппаратовToolStripMenuItem.Text = "Редактирование аппаратов";
			this.изменениеМощностиАппаратовToolStripMenuItem.Click += new System.EventHandler(this.EditDevices_Click);
			// 
			// добавлениеАппаратовToolStripMenuItem
			// 
			this.добавлениеАппаратовToolStripMenuItem.Name = "добавлениеАппаратовToolStripMenuItem";
			this.добавлениеАппаратовToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
			this.добавлениеАппаратовToolStripMenuItem.Text = "Добавление аппаратов";
			this.добавлениеАппаратовToolStripMenuItem.Click += new System.EventHandler(this.добавлениеАппаратовToolStripMenuItem_Click);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.Exit_Button_Click);
			// 
			// Form1
			// 
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(1084, 461);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(1100, 500);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(1100, 215);
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
			this.P1.ResumeLayout(false);
			this.P1.PerformLayout();
			this.P0.ResumeLayout(false);
			this.P0.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private SplitContainer splitContainer1;
		private CalculatorComponents.Device Devices;
		private FlowLayoutPanel AllFields;
		private Panel P1;
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
		private MenuStrip menuStrip1;
		private ToolStripMenuItem изменениеМощностиАппаратовToolStripMenuItem;
		private ToolStripMenuItem добавлениеАппаратовToolStripMenuItem;
		private ToolStripMenuItem выходToolStripMenuItem;
		private Panel P0;
		private BaseComponents.DoubleTextBox Distance;
		private Label DST;
		private Label label4;
		private BaseComponents.DoubleTextBox SSD;
		private Label label3;
	}
}

