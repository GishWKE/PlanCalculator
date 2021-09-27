namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	public partial class PrintPreview : Form
	{
		public PrintPreview ( ) :this(string.Empty)
		{
		}
		public PrintPreview ( string tb )
		{
			InitializeComponent ( );
			richTextBox1.Text = tb;
		}
	}
}
