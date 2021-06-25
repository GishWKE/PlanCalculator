namespace PlanCalculator
{
	using System;
	using System.ComponentModel;
	using System.Windows.Forms;
	using System.Drawing;
	using Resource;
	using Resource.Properties;
	using BaseComponents;

	using CalculatorComponents;

	partial class CreateDevice
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose ( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose ( );
			}
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDevice));
			this.OK = new Button();
			this.Cansel = new Button();
			this.label1 = new Label();
			this.DeviceName = new TextBox();
			this.label2 = new Label();
			this.SCD = new IntTextBox();
			this.label3 = new Label();
			this.Power = new DoubleTextBox();
			this.label4 = new Label();
			this.label5 = new Label();
			this.label6 = new Label();
			this.dateTimePicker1 = new DateTimePicker();
			this.label7 = new Label();
			this.Seconds = new RadioButton();
			this.Minutes = new RadioButton();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.OK.DialogResult = DialogResult.Yes;
			this.OK.Location = new Point(256, 171);
			this.OK.Name = "OK";
			this.OK.Size = new Size(75, 23);
			this.OK.TabIndex = 0;
			this.OK.Text = "ОК";
			this.OK.UseVisualStyleBackColor = true;
			// 
			// Cansel
			// 
			this.Cansel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.Cansel.DialogResult = DialogResult.No;
			this.Cansel.Location = new Point(337, 171);
			this.Cansel.Name = "Cansel";
			this.Cansel.Size = new Size(75, 23);
			this.Cansel.TabIndex = 1;
			this.Cansel.Text = "Отмена";
			this.Cansel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new Point(35, 13);
			this.label1.Name = "label1";
			this.label1.Size = new Size(107, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Название аппарата";
			// 
			// DeviceName
			// 
			this.DeviceName.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.DeviceName.Location = new Point(148, 10);
			this.DeviceName.Name = "DeviceName";
			this.DeviceName.Size = new Size(222, 20);
			this.DeviceName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new Point(112, 39);
			this.label2.Name = "label2";
			this.label2.Size = new Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "РИЦ";
			// 
			// SCD
			// 
			this.SCD.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.SCD.BackColor = SystemColors.Window;
			this.SCD.CanBeNegative = false;
			this.SCD.Correct_tooltip = "Расстояние источник-центр";
			this.SCD.Location = new Point(148, 36);
			this.SCD.Name = "SCD";
			this.SCD.Regex = "";
			this.SCD.Size = new Size(222, 20);
			this.SCD.TabIndex = 5;
			this.SCD.TextAlign = HorizontalAlignment.Right;
			this.SCD.Value = null;
			this.SCD.Wrong_tooltip = null;
			// 
			// label3
			// 
			this.label3.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new Point(376, 39);
			this.label3.Name = "label3";
			this.label3.Size = new Size(21, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "см";
			// 
			// Power
			// 
			this.Power.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.Power.BackColor = SystemColors.Window;
			this.Power.CanBeNegative = false;
			this.Power.Correct_tooltip = "Мощность аппарата";
			this.Power.Location = new Point(148, 62);
			this.Power.Name = "Power";
			this.Power.Regex = "";
			this.Power.Size = new Size(222, 20);
			this.Power.TabIndex = 7;
			this.Power.TextAlign = HorizontalAlignment.Right;
			this.Power.Value = null;
			this.Power.Wrong_tooltip = null;
			// 
			// label4
			// 
			this.label4.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new Point(376, 65);
			this.label4.Name = "label4";
			this.label4.Size = new Size(36, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "сГр/с";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new Point(82, 65);
			this.label5.Name = "label5";
			this.label5.Size = new Size(60, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Мощность";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new Point(13, 91);
			this.label6.Name = "label6";
			this.label6.Size = new Size(129, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Дата замера мощности";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.dateTimePicker1.ImeMode = ImeMode.NoControl;
			this.dateTimePicker1.Location = new Point(148, 85);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new Size(222, 20);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new Point(23, 114);
			this.label7.Name = "label7";
			this.label7.Size = new Size(119, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Требуемый результат";
			// 
			// Seconds
			// 
			this.Seconds.AutoSize = true;
			this.Seconds.Checked = true;
			this.Seconds.Location = new Point(148, 112);
			this.Seconds.Name = "Seconds";
			this.Seconds.Size = new Size(81, 17);
			this.Seconds.TabIndex = 13;
			this.Seconds.TabStop = true;
			this.Seconds.Text = "В секундах";
			this.Seconds.UseVisualStyleBackColor = true;
			// 
			// Minutes
			// 
			this.Minutes.AutoSize = true;
			this.Minutes.Location = new Point(235, 112);
			this.Minutes.Name = "Minutes";
			this.Minutes.Size = new Size(81, 17);
			this.Minutes.TabIndex = 14;
			this.Minutes.Text = "В минтутах";
			this.Minutes.UseVisualStyleBackColor = true;
			// 
			// CreateDevice
			// 
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(424, 206);
			this.Controls.Add(this.Minutes);
			this.Controls.Add(this.Seconds);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.Power);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SCD);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.DeviceName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Cansel);
			this.Controls.Add(this.OK);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Icon = Resources.icon;
			this.MaximizeBox = false;
			this.MaximumSize = new Size(440, 245);
			this.MinimizeBox = false;
			this.MinimumSize = new Size(440, 245);
			this.Name = "CreateDevice";
			this.Text = "CreateDevice";
			this.FormClosing += new FormClosingEventHandler(this.CreateDevice_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Button OK;
		private Button Cansel;
		private Label label1;
		private TextBox DeviceName;
		private Label label2;
		private IntTextBox SCD;
		private Label label3;
		private DoubleTextBox Power;
		private Label label4;
		private Label label5;
		private Label label6;
		private DateTimePicker dateTimePicker1;
		private Label label7;
		private RadioButton Seconds;
		private RadioButton Minutes;
	}
}