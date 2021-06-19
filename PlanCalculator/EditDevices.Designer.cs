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

	partial class EditDevices
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
			sql.Dispose ( );
			base.Dispose ( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ( )
		{
			this.buttonOk = new Button();
			this.Devices = new Device();
			this.buttonCancel = new Button();
			this.SuspendLayout();
			// 
			// buttonOk
			// 
			this.buttonOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.buttonOk.DialogResult = DialogResult.OK;
			this.buttonOk.Location = new Point(216, 101);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new Size(75, 23);
			this.buttonOk.TabIndex = 0;
			this.buttonOk.Text = "Применить";
			this.buttonOk.UseVisualStyleBackColor = true;
			this.buttonOk.Click += new EventHandler(this.Button_Click);
			// 
			// Devices
			// 
			this.Devices.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
            | AnchorStyles.Right)));
			this.Devices.Editable = true;
			this.Devices.FileName = "";
			this.Devices.Location = new Point(12, 12);
			this.Devices.Name = "Devices";
			this.Devices.SCD = null;
			this.Devices.Size = new Size(360, 87);
			this.Devices.TabIndex = 2;
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.buttonCancel.DialogResult = DialogResult.Abort;
			this.buttonCancel.Location = new Point(297, 101);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "Отменить";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new EventHandler(this.Button_Click );
			// 
			// EditDevices
			// 
			this.AutoScaleDimensions = new SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new Size(384, 136);
			this.Controls.Add(this.Devices);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOk);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MaximumSize = new Size(400, 175);
			this.MinimizeBox = false;
			this.MinimumSize = new Size(400, 175);
			this.Name = "EditDevices";
			this.Text = "Редактирование аппаратов";
			this.FormClosing += new FormClosingEventHandler(this.EditDevices_FormClosing);
			this.ResumeLayout(false);

		}

		#endregion

		private Button buttonOk;
		private Device Devices;
		private Button buttonCancel;
	}
}