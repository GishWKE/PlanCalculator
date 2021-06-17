namespace PlanCalculator
{

	partial class CreateDevice
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.OK = new System.Windows.Forms.Button();
			this.Cansel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.DeviceName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SCD = new BaseComponents.IntTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Power = new BaseComponents.DoubleTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.Seconds = new System.Windows.Forms.RadioButton();
			this.Minutes = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// OK
			// 
			this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OK.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.OK.Location = new System.Drawing.Point(256, 171);
			this.OK.Name = "OK";
			this.OK.Size = new System.Drawing.Size(75, 23);
			this.OK.TabIndex = 0;
			this.OK.Text = "ОК";
			this.OK.UseVisualStyleBackColor = true;
			// 
			// Cansel
			// 
			this.Cansel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cansel.DialogResult = System.Windows.Forms.DialogResult.No;
			this.Cansel.Location = new System.Drawing.Point(337, 171);
			this.Cansel.Name = "Cansel";
			this.Cansel.Size = new System.Drawing.Size(75, 23);
			this.Cansel.TabIndex = 1;
			this.Cansel.Text = "Отмена";
			this.Cansel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(35, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Название аппарата";
			// 
			// DeviceName
			// 
			this.DeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DeviceName.Location = new System.Drawing.Point(148, 10);
			this.DeviceName.Name = "DeviceName";
			this.DeviceName.Size = new System.Drawing.Size(222, 20);
			this.DeviceName.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "РИЦ";
			// 
			// SCD
			// 
			this.SCD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SCD.BackColor = System.Drawing.SystemColors.Window;
			this.SCD.CanBeNegative = false;
			this.SCD.Correct_tooltip = "Расстояние источник-центр";
			this.SCD.Location = new System.Drawing.Point(148, 36);
			this.SCD.Name = "SCD";
			this.SCD.Regex = "";
			this.SCD.Size = new System.Drawing.Size(222, 20);
			this.SCD.TabIndex = 5;
			this.SCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SCD.Value = null;
			this.SCD.Wrong_tooltip = null;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(376, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(21, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "см";
			// 
			// Power
			// 
			this.Power.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Power.BackColor = System.Drawing.SystemColors.Window;
			this.Power.CanBeNegative = false;
			this.Power.Correct_tooltip = "Мощность аппарата";
			this.Power.FractionalPlaces = -1;
			this.Power.Location = new System.Drawing.Point(148, 62);
			this.Power.Name = "Power";
			this.Power.Regex = "";
			this.Power.Size = new System.Drawing.Size(222, 20);
			this.Power.TabIndex = 7;
			this.Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Power.Value = null;
			this.Power.Wrong_tooltip = null;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(376, 65);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "сГр/с";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(82, 65);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(60, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Мощность";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 91);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 13);
			this.label6.TabIndex = 10;
			this.label6.Text = "Дата замера мощности";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dateTimePicker1.Location = new System.Drawing.Point(148, 85);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(222, 20);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(23, 114);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(119, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Требуемый результат";
			// 
			// Seconds
			// 
			this.Seconds.AutoSize = true;
			this.Seconds.Checked = true;
			this.Seconds.Location = new System.Drawing.Point(148, 112);
			this.Seconds.Name = "Seconds";
			this.Seconds.Size = new System.Drawing.Size(81, 17);
			this.Seconds.TabIndex = 13;
			this.Seconds.TabStop = true;
			this.Seconds.Text = "В секундах";
			this.Seconds.UseVisualStyleBackColor = true;
			// 
			// Minutes
			// 
			this.Minutes.AutoSize = true;
			this.Minutes.Location = new System.Drawing.Point(235, 112);
			this.Minutes.Name = "Minutes";
			this.Minutes.Size = new System.Drawing.Size(81, 17);
			this.Minutes.TabIndex = 14;
			this.Minutes.Text = "В минтутах";
			this.Minutes.UseVisualStyleBackColor = true;
			// 
			// CreateDevice
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(424, 206);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(440, 245);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(440, 245);
			this.Name = "CreateDevice";
			this.Text = "CreateDevice";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateDevice_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cansel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox DeviceName;
		private System.Windows.Forms.Label label2;
		private BaseComponents.IntTextBox SCD;
		private System.Windows.Forms.Label label3;
		private BaseComponents.DoubleTextBox Power;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton Seconds;
		private System.Windows.Forms.RadioButton Minutes;
	}
}