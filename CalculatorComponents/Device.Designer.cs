﻿namespace CalculatorComponents
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
			this.Power_label1 = new System.Windows.Forms.Label();
			this.Power = new BaseComponents.DoubleTextBox();
			this.Power_label0 = new System.Windows.Forms.Label();
			this.SCD_label1 = new System.Windows.Forms.Label();
			this.SCD_value = new BaseComponents.IntTextBox();
			this.SCD_label0 = new System.Windows.Forms.Label();
			this.DeviceList = new System.Windows.Forms.ComboBox();
			this.Devices_label = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Power_label1
			// 
			this.Power_label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Power_label1.AutoSize = true;
			this.Power_label1.Location = new System.Drawing.Point(323, 59);
			this.Power_label1.Name = "Power_label1";
			this.Power_label1.Size = new System.Drawing.Size(36, 13);
			this.Power_label1.TabIndex = 15;
			this.Power_label1.Text = "сГр/с";
			// 
			// Power
			// 
			this.Power.AlwaysPositive = true;
			this.Power.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Power.Correct_tooltip = "Мощность";
			this.Power.FractionalPlaces = 4;
			this.Power.Location = new System.Drawing.Point(67, 56);
			this.Power.MaxLength = 8;
			this.Power.Name = "Power";
			this.Power.PlaceHolder = "Мощность аппарата";
			this.Power.ReadOnly = true;
			this.Power.Size = new System.Drawing.Size(250, 20);
			this.Power.TabIndex = 14;
			this.Power.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.Power.Type = BaseComponents.NumericTextBoxTypes.DOUBLE;
			// 
			// Power_label0
			// 
			this.Power_label0.AutoSize = true;
			this.Power_label0.Location = new System.Drawing.Point(1, 59);
			this.Power_label0.Name = "Power_label0";
			this.Power_label0.Size = new System.Drawing.Size(60, 13);
			this.Power_label0.TabIndex = 13;
			this.Power_label0.Text = "Мощность";
			// 
			// SCD_label1
			// 
			this.SCD_label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SCD_label1.AutoSize = true;
			this.SCD_label1.Location = new System.Drawing.Point(323, 33);
			this.SCD_label1.Name = "SCD_label1";
			this.SCD_label1.Size = new System.Drawing.Size(21, 13);
			this.SCD_label1.TabIndex = 12;
			this.SCD_label1.Text = "см";
			// 
			// SCD_value
			// 
			this.SCD_value.AlwaysPositive = true;
			this.SCD_value.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SCD_value.Correct_tooltip = "Расстояние источник-центр вращения аппарата";
			this.SCD_value.FractionalPlaces = 0;
			this.SCD_value.Location = new System.Drawing.Point(67, 30);
			this.SCD_value.Name = "SCD_value";
			this.SCD_value.PlaceHolder = "";
			this.SCD_value.ReadOnly = true;
			this.SCD_value.Size = new System.Drawing.Size(250, 20);
			this.SCD_value.TabIndex = 11;
			this.SCD_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.SCD_value.Type = BaseComponents.NumericTextBoxTypes.INT;
			// 
			// SCD_label0
			// 
			this.SCD_label0.AutoSize = true;
			this.SCD_label0.Location = new System.Drawing.Point(31, 33);
			this.SCD_label0.Name = "SCD_label0";
			this.SCD_label0.Size = new System.Drawing.Size(30, 13);
			this.SCD_label0.TabIndex = 10;
			this.SCD_label0.Text = "РИЦ";
			// 
			// DeviceList
			// 
			this.DeviceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DeviceList.FormattingEnabled = true;
			this.DeviceList.Location = new System.Drawing.Point(67, 3);
			this.DeviceList.Name = "DeviceList";
			this.DeviceList.Size = new System.Drawing.Size(250, 21);
			this.DeviceList.TabIndex = 9;
			this.DeviceList.SelectedIndexChanged += new System.EventHandler(this.DeviceList_SelectedIndexChanged);
			// 
			// Devices_label
			// 
			this.Devices_label.AutoSize = true;
			this.Devices_label.Location = new System.Drawing.Point(12, 6);
			this.Devices_label.Name = "Devices_label";
			this.Devices_label.Size = new System.Drawing.Size(49, 13);
			this.Devices_label.TabIndex = 8;
			this.Devices_label.Text = "Аппарат";
			// 
			// Device
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Power_label1);
			this.Controls.Add(this.Power);
			this.Controls.Add(this.Power_label0);
			this.Controls.Add(this.SCD_label1);
			this.Controls.Add(this.SCD_value);
			this.Controls.Add(this.SCD_label0);
			this.Controls.Add(this.DeviceList);
			this.Controls.Add(this.Devices_label);
			this.Name = "Device";
			this.Size = new System.Drawing.Size(363, 87);
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
