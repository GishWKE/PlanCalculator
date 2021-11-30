/*
  Copyright © 2021 Antipov Roman (https://github.com/GishWKE), Tsys' Alexandr (https://github.com/AlexTsys256)


   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
namespace PlanCalculator
{
	using System.Windows.Forms;

	public partial class PrintPreview : Form
	{
		public PrintPreview() : this(string.Empty)
		{
		}
		public PrintPreview(string tb)
		{
			InitializeComponent();
			richTextBox1.Text = tb;
		}

		private void PrintPreview_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					close.PerformClick();
					break;
				case Keys.P:
					if (e.Control)
						print.PerformClick();
					break;
			}
		}
	}
}
