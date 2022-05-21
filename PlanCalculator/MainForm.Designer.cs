﻿namespace PlanCalculator
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Drawing;

	using BaseComponents;
	using Resource;
	using Resource.Properties;

	using CalculatorComponents;
using System.Linq;

	partial class MainForm
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
			ClearFields ( );
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.dateTitle = new System.ComponentModel.BackgroundWorker();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.B = new System.Windows.Forms.NumericUpDown();
			this.B_label = new System.Windows.Forms.Label();
			this.A = new System.Windows.Forms.NumericUpDown();
			this.A_label = new System.Windows.Forms.Label();
			this.FieldsCount = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.N = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.распечататьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.предварителоьныйПросмотрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.мощностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ежедневнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.среднемесячнаяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
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
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.printDialog1 = new System.Windows.Forms.PrintDialog();
			this.аппаратыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.редактироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clock = new System.Windows.Forms.Label();
			this.Watch = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.B)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.A)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.FieldsCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.N)).BeginInit();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.P1.SuspendLayout();
			this.P0.SuspendLayout();
			this.SuspendLayout();
			// 
			// dateTitle
			// 
			this.dateTitle.WorkerReportsProgress = true;
			this.dateTitle.WorkerSupportsCancellation = true;
			this.dateTitle.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DateTitle_DoWork);
			this.dateTitle.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DateTitle_ProgressChanged);
			this.dateTitle.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DateTitle_RunWorkerCompleted);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 5000;
			this.toolTip1.InitialDelay = 200;
			this.toolTip1.IsBalloon = true;
			this.toolTip1.ReshowDelay = 100;
			this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.toolTip1.ToolTipTitle = "Информация о поле ввода";
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
			this.B.Size = new System.Drawing.Size(173, 20);
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
			// FieldsCount
			// 
			this.FieldsCount.Location = new System.Drawing.Point(226, 0);
			this.FieldsCount.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
			this.FieldsCount.Name = "FieldsCount";
			this.FieldsCount.Size = new System.Drawing.Size(173, 20);
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
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.печатьToolStripMenuItem,
            this.аппаратыToolStripMenuItem,
            this.мощностьToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem,
            this.очиститьToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1084, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// печатьToolStripMenuItem
			// 
			this.печатьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.распечататьToolStripMenuItem,
            this.предварителоьныйПросмотрToolStripMenuItem});
			this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
			this.печатьToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.печатьToolStripMenuItem.Text = "Печать";
			// 
			// распечататьToolStripMenuItem
			// 
			this.распечататьToolStripMenuItem.Name = "распечататьToolStripMenuItem";
			this.распечататьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.распечататьToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
			this.распечататьToolStripMenuItem.Text = "Распечатать";
			this.распечататьToolStripMenuItem.Click += new System.EventHandler(this.печататьToolStripMenuItem_Click);
			// 
			// предварителоьныйПросмотрToolStripMenuItem
			// 
			this.предварителоьныйПросмотрToolStripMenuItem.Name = "предварителоьныйПросмотрToolStripMenuItem";
			this.предварителоьныйПросмотрToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.P)));
			this.предварителоьныйПросмотрToolStripMenuItem.Size = new System.Drawing.Size(320, 22);
			this.предварителоьныйПросмотрToolStripMenuItem.Text = "Предварительный просмотр";
			this.предварителоьныйПросмотрToolStripMenuItem.Click += new System.EventHandler(this.предварителоьныйПросмотрToolStripMenuItem_Click);
			// 
			// оПрограммеToolStripMenuItem
			// 
			this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
			this.оПрограммеToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
			this.оПрограммеToolStripMenuItem.Text = "О программе";
			this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
			// 
			// мощностьToolStripMenuItem
			// 
			this.мощностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ежедневнаяToolStripMenuItem,
            this.среднемесячнаяToolStripMenuItem});
			this.мощностьToolStripMenuItem.Name = "мощностьToolStripMenuItem";
			this.мощностьToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.мощностьToolStripMenuItem.Text = "Мощность";
			// 
			// ежедневнаяToolStripMenuItem
			// 
			this.ежедневнаяToolStripMenuItem.Name = "ежедневнаяToolStripMenuItem";
			this.ежедневнаяToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ежедневнаяToolStripMenuItem.Text = "Ежедневная";
			this.ежедневнаяToolStripMenuItem.Click += new System.EventHandler(this.просмотрМощностейToolStripMenuItem_Click);
			// 
			// среднемесячнаяToolStripMenuItem
			// 
			this.среднемесячнаяToolStripMenuItem.Name = "среднемесячнаяToolStripMenuItem";
			this.среднемесячнаяToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.среднемесячнаяToolStripMenuItem.Text = "Среднемесячная";
			this.среднемесячнаяToolStripMenuItem.Click += new System.EventHandler(this.среднемесячнаяToolStripMenuItem_Click);
			// 
			// очиститьToolStripMenuItem
			// 
			this.очиститьToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
			this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.очиститьToolStripMenuItem.Text = "Очистить";
			this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.Exit_Button_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.clock);
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
			this.D.AlwaysPositive = true;
			this.D.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.D.BackColor = System.Drawing.SystemColors.Window;
			this.D.Correct_tooltip = "Разовая доза";
			this.D.FractionalPlaces = 2;
			this.D.Location = new System.Drawing.Point(112, 0);
			this.D.Name = "D";
			this.D.PlaceHolder = "Разовая доза";
			this.D.Size = new System.Drawing.Size(261, 20);
			this.D.TabIndex = 3;
			this.D.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.D.Type = BaseComponents.NumericTextBoxTypes.DOUBLE;
			this.D.Leave += new System.EventHandler(this.Dose_Changed);
			// 
			// Dose_label1
			// 
			this.Dose_label1.AutoSize = true;
			this.Dose_label1.Location = new System.Drawing.Point(84, 3);
			this.Dose_label1.Name = "Dose_label1";
			this.Dose_label1.Size = new System.Drawing.Size(30, 13);
			this.Dose_label1.TabIndex = 2;
			this.Dose_label1.Text = "% ) =";
			// 
			// P
			// 
			this.P.AlwaysPositive = true;
			this.P.Correct_tooltip = "Процентная разовая доза";
			this.P.FractionalPlaces = 0;
			this.P.Location = new System.Drawing.Point(45, 0);
			this.P.MaxLength = 3;
			this.P.Name = "P";
			this.P.PlaceHolder = "";
			this.P.Regex = "^([8-9]\\d|100)?$";
			this.P.Size = new System.Drawing.Size(36, 20);
			this.P.TabIndex = 1;
			this.P.Text = "90";
			this.P.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.P.Type = BaseComponents.NumericTextBoxTypes.INT;
			this.P.Value = 90;
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
			this.SSD.AlwaysPositive = true;
			this.SSD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SSD.BackColor = System.Drawing.SystemColors.Window;
			this.SSD.Correct_tooltip = "Расстояние источник-поверхность";
			this.SSD.FractionalPlaces = 1;
			this.SSD.Location = new System.Drawing.Point(112, 0);
			this.SSD.MaxLength = 5;
			this.SSD.Name = "SSD";
			this.SSD.PlaceHolder = "";
			this.SSD.ReadOnly = true;
			this.SSD.Size = new System.Drawing.Size(261, 20);
			this.SSD.TabIndex = 3;
			this.SSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SSD.Type = BaseComponents.NumericTextBoxTypes.DOUBLE;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(81, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(33, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "см) =";
			// 
			// Distance
			// 
			this.Distance.AlwaysPositive = true;
			this.Distance.BackColor = System.Drawing.SystemColors.Window;
			this.Distance.Correct_tooltip = "Расстояние от точки входа в тело до изоцентра";
			this.Distance.FractionalPlaces = 1;
			this.Distance.Location = new System.Drawing.Point(45, 0);
			this.Distance.MaxLength = 4;
			this.Distance.Name = "Distance";
			this.Distance.PlaceHolder = "";
			this.Distance.Size = new System.Drawing.Size(36, 20);
			this.Distance.TabIndex = 1;
			this.Distance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Distance.Type = BaseComponents.NumericTextBoxTypes.DOUBLE;
			this.Distance.ValueChanged += new System.EventHandler(this.Distance_Leave);
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
			this.Devices.FileName = null;
			this.Devices.Location = new System.Drawing.Point(0, 0);
			this.Devices.Name = "Devices";
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
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
			// 
			// printDialog1
			// 
			this.printDialog1.AllowPrintToFile = false;
			this.printDialog1.Document = this.printDocument1;
			this.printDialog1.ShowHelp = true;
			// 
			// аппаратыToolStripMenuItem
			// 
			this.аппаратыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактироватьToolStripMenuItem});
			this.аппаратыToolStripMenuItem.Name = "аппаратыToolStripMenuItem";
			this.аппаратыToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
			this.аппаратыToolStripMenuItem.Text = "Аппараты";
			// 
			// редактироватьToolStripMenuItem
			// 
			this.редактироватьToolStripMenuItem.Name = "редактироватьToolStripMenuItem";
			this.редактироватьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.редактироватьToolStripMenuItem.Text = "Редактировать";
			this.редактироватьToolStripMenuItem.Click += new System.EventHandler(this.EditDevices_Click);
			// 
			// добавитьToolStripMenuItem
			// 
			this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
			this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.добавитьToolStripMenuItem.Text = "Добавить";
			this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавлениеАппаратовToolStripMenuItem_Click);
			// 
			// clock
			// 
			this.clock.AutoSize = true;
			this.clock.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.clock.Location = new System.Drawing.Point(0, 424);
			this.clock.Name = "clock";
			this.clock.Size = new System.Drawing.Size(35, 13);
			this.clock.TabIndex = 5;
			this.clock.Text = "label5";
			// 
			// Watch
			// 
			this.Watch.WorkerReportsProgress = true;
			this.Watch.WorkerSupportsCancellation = true;
			this.Watch.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Watch_DoWork);
			this.Watch.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Watch_ProgressChanged);
			this.Watch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Watch_RunWorkerCompleted);
			// 
			// MainForm
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
			this.Name = "MainForm";
			((System.ComponentModel.ISupportInitialize)(this.B)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.A)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.FieldsCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.N)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.P1.ResumeLayout(false);
			this.P1.PerformLayout();
			this.P0.ResumeLayout(false);
			this.P0.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private SplitContainer splitContainer1;
		private Device Devices;
		private FlowLayoutPanel AllFields;
		private Panel P1;
		private Label Dose_label2;
		private DoubleTextBox D;
		private Label Dose_label1;
		private IntTextBox P;
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
		private ToolStripMenuItem выходToolStripMenuItem;
		private Panel P0;
		private DoubleTextBox Distance;
		private Label DST;
		private Label label4;
		private DoubleTextBox SSD;
		private Label label3;
		private BackgroundWorker dateTitle;
		private ToolStripMenuItem оПрограммеToolStripMenuItem;
		private ToolStripMenuItem очиститьToolStripMenuItem;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private PrintDialog printDialog1;
		private ToolStripMenuItem печатьToolStripMenuItem;
		private ToolStripMenuItem распечататьToolStripMenuItem;
		private ToolStripMenuItem предварителоьныйПросмотрToolStripMenuItem;
		private ToolStripMenuItem мощностьToolStripMenuItem;
		private ToolStripMenuItem ежедневнаяToolStripMenuItem;
		private ToolStripMenuItem среднемесячнаяToolStripMenuItem;
		private ToolStripMenuItem аппаратыToolStripMenuItem;
		private ToolStripMenuItem добавитьToolStripMenuItem;
		private ToolStripMenuItem редактироватьToolStripMenuItem;
		private Label clock;
		private BackgroundWorker Watch;
	}
}

