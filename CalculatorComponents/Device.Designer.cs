namespace CalculatorComponents
{
	using System;
	using System.Drawing;
	using System.Collections.Generic;
	using System.Windows.Forms;
	using System.ComponentModel;

	using BaseComponents;
	using Resource;
	using Resource.Properties;
	partial class Device
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
			this.Power_label1 = new Label();
			this.Power = new DoubleTextBox();
			this.Power_label0 = new Label();
			this.SCD_label1 = new Label();
			this.SCD_value = new IntTextBox();
			this.SCD_label0 = new Label();
			this.DeviceList = new ComboBox();
			this.Devices_label = new Label();
			this.SuspendLayout();
			// 
			// Power_label1
			// 
			this.Power_label1.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.Power_label1.AutoSize = true;
			this.Power_label1.Location = new Point(323, 59);
			this.Power_label1.Name = "Power_label1";
			this.Power_label1.Size = new Size(36, 13);
			this.Power_label1.TabIndex = 15;
			this.Power_label1.Text = "сГр/с";
			// 
			// Power
			// 
			this.Power.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.Power.CanBeNegative = false;
			this.Power.Correct_tooltip = ToolTips.Device_Power;
			this.Power.FractionalPlaces = 4;
			this.Power.Location = new Point(67, 56);
			this.Power.MaxLength = 8;
			this.Power.Name = "Power";
			this.Power.ReadOnly = true;
			this.Power.Regex = "";
			this.Power.Size = new Size(250, 20);
			this.Power.TabIndex = 14;
			this.Power.TextAlign = HorizontalAlignment.Right;
			this.Power.Value = null;
			this.Power.Wrong_tooltip = null;
			// 
			// Power_label0
			// 
			this.Power_label0.AutoSize = true;
			this.Power_label0.Location = new Point(1, 59);
			this.Power_label0.Name = "Power_label0";
			this.Power_label0.Size = new Size(60, 13);
			this.Power_label0.TabIndex = 13;
			this.Power_label0.Text = "Мощность";
			// 
			// SCD_label1
			// 
			this.SCD_label1.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.SCD_label1.AutoSize = true;
			this.SCD_label1.Location = new Point(323, 33);
			this.SCD_label1.Name = "SCD_label1";
			this.SCD_label1.Size = new Size(21, 13);
			this.SCD_label1.TabIndex = 12;
			this.SCD_label1.Text = "см";
			// 
			// SCD_value
			// 
			this.SCD_value.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.SCD_value.CanBeNegative = false;
			this.SCD_value.Correct_tooltip = ToolTips.Device_SCD;
			this.SCD_value.Location = new Point(67, 30);
			this.SCD_value.Name = "SCD_value";
			this.SCD_value.ReadOnly = true;
			this.SCD_value.Regex = "";
			this.SCD_value.Size = new Size(250, 20);
			this.SCD_value.TabIndex = 11;
			this.SCD_value.TextAlign = HorizontalAlignment.Right;
			this.SCD_value.Value = null;
			this.SCD_value.Wrong_tooltip = null;
			// 
			// SCD_label0
			// 
			this.SCD_label0.AutoSize = true;
			this.SCD_label0.Location = new Point(31, 33);
			this.SCD_label0.Name = "SCD_label0";
			this.SCD_label0.Size = new Size(30, 13);
			this.SCD_label0.TabIndex = 10;
			this.SCD_label0.Text = "РИЦ";
			// 
			// DeviceList
			// 
			this.DeviceList.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.DeviceList.FormattingEnabled = true;
			this.DeviceList.Location = new Point(67, 3);
			this.DeviceList.Name = "DeviceList";
			this.DeviceList.Size = new Size(250, 21);
			this.DeviceList.TabIndex = 9;
			this.DeviceList.SelectedIndexChanged += new EventHandler(this.DeviceList_SelectedIndexChanged);
			// 
			// Devices_label
			// 
			this.Devices_label.AutoSize = true;
			this.Devices_label.Location = new Point(12, 6);
			this.Devices_label.Name = "Devices_label";
			this.Devices_label.Size = new Size(49, 13);
			this.Devices_label.TabIndex = 8;
			this.Devices_label.Text = "Аппарат";
			// 
			// Device
			// 
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.Controls.Add(this.Power_label1);
			this.Controls.Add(this.Power);
			this.Controls.Add(this.Power_label0);
			this.Controls.Add(this.SCD_label1);
			this.Controls.Add(this.SCD_value);
			this.Controls.Add(this.SCD_label0);
			this.Controls.Add(this.DeviceList);
			this.Controls.Add(this.Devices_label);
			this.Name = "Device";
			this.Size = new Size(363, 87);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Label Power_label1;
		public DoubleTextBox Power;
		private Label Power_label0;
		private Label SCD_label1;
		public IntTextBox SCD_value;
		private Label SCD_label0;
		private ComboBox DeviceList;
		private Label Devices_label;
	}
}
