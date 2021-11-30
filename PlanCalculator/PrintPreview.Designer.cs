namespace PlanCalculator
{
	partial class PrintPreview
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
			this.close = new System.Windows.Forms.Button();
			this.print = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// close
			// 
			this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.close.Location = new System.Drawing.Point(713, 415);
			this.close.Name = "close";
			this.close.Size = new System.Drawing.Size(75, 23);
			this.close.TabIndex = 0;
			this.close.Text = "Закрыть";
			this.close.UseVisualStyleBackColor = true;
			this.close.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintPreview_KeyDown);
			// 
			// print
			// 
			this.print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.print.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.print.Location = new System.Drawing.Point(632, 415);
			this.print.Name = "print";
			this.print.Size = new System.Drawing.Size(75, 23);
			this.print.TabIndex = 1;
			this.print.Text = "Печать";
			this.print.UseVisualStyleBackColor = true;
			this.print.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintPreview_KeyDown);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 12);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(776, 397);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintPreview_KeyDown);
			// 
			// PrintPreview
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.print);
			this.Controls.Add(this.close);
			this.Name = "PrintPreview";
			this.Text = "PrintPreview";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintPreview_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button close;
		private System.Windows.Forms.Button print;
		private System.Windows.Forms.RichTextBox richTextBox1;
	}
}