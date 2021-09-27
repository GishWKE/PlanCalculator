namespace PlanCalculator
{
	using System.Windows.Forms;

	public partial class PrintPreview : Form
	{
		public PrintPreview ( ) : this ( string.Empty )
		{
		}
		public PrintPreview ( string tb )
		{
			InitializeComponent ( );
			richTextBox1.Text = tb;
		}
	}
}
