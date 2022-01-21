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
	using BaseComponents;

	using CalculatorComponents;

	using DB_Worker;

	using Resource.Properties;

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Windows.Forms;

	public partial class MonthPowerTable : Form
	{
		private readonly int DecimalPlaces = 2;
		private readonly string Limit;
		private readonly List<int> selectedDate = new List<int>();
		private readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue("")]
		public string FileName
		{
			get => sql.FileName;
			set
			{
				sql.FileName = value;
				tabControl1.TabPages.Clear();
				var dt = sql.GetTable(SQL.Device);
				foreach (var dr in dt.AsEnumerable())
				{
					var name = dr["Аппарат"].ToString();
					var dgv = new DataGridView
					{
						Dock = DockStyle.Fill,
						MultiSelect = false,
						Name = name,
						AllowUserToAddRows = false,
						AllowUserToDeleteRows = false,
						AllowUserToOrderColumns = false,
						AllowUserToResizeColumns = false,
						AllowUserToResizeRows = false,
						SelectionMode = DataGridViewSelectionMode.FullRowSelect
					};
					var dt0 = new DataTable(name);
					dt0.Columns.Add(new DataColumn("Дата", typeof(DateTime)));
					dt0.Columns.Add(new DataColumn("Мощность", typeof(string)));
					var pow0 = (double)dr["Мощность"];
					var power = pow0;
					var pow = power.ToStringWithDecimalPlaces( DecimalPlaces );
					var date0 = (DateTime)dr["Дата замера мощности"];
					var date = date0;
					//var ind = ( DateTime.Today - date ).Days;
					//selectedDate.Add ( ind );

					while (pow != Limit)
					{
						var r = dt0.NewRow();
						var date1 = date;
						var powCalc = power;
						var cnt = 1;
						date = date.AddDays(1);
						while (date.Month == date1.Month)
						{
							cnt++;
							powCalc += Device.GetPower(pow0, date0, date);
							date = date.AddDays(1);
						}
						r["Дата"] = date1;
						r["Мощность"] = (powCalc / cnt).ToStringWithDecimalPlaces( DecimalPlaces );
						dt0.Rows.Add(r);
						if (date1.Month == DateTime.Today.Month && date1.Year == DateTime.Today.Year)
						{
							selectedDate.Add(dt0.Rows.Count);
						}
						//date = date.AddDays ( 1 );
						power = Device.GetPower(pow0, date0, date);
						pow = power.ToStringWithDecimalPlaces( DecimalPlaces );
					}

					dgv.DataSource = dt0.Copy();
					var tp = new TabPage(name);
					tp.CreateControl();
					tp.Controls.Add(dgv);
					tabControl1.TabPages.Add(tp);
				}
			}
		}
		private static void EnsureVisibleRow(DataGridView view, int rowToShow)
		{
			if (rowToShow >= 0 && rowToShow < view.RowCount)
			{
				var countVisible = view.DisplayedRowCount(false);
				var firstVisible = view.FirstDisplayedScrollingRowIndex;
				if (rowToShow < firstVisible)
				{
					view.FirstDisplayedScrollingRowIndex = rowToShow;
				}
				else if (rowToShow >= firstVisible + countVisible)
				{
					view.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
				}
			}
		}
		public MonthPowerTable ( )
		{
			InitializeComponent ( );
			Limit = 0D.ToStringWithDecimalPlaces ( DecimalPlaces );
		}

		private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e) => UpdateDisplayingDate();
		private void UpdateDisplayingDate()
		{
			var tab = tabControl1.SelectedTab;
			var tabInd = tabControl1.SelectedIndex;
			var v = (DataGridView)tab.Controls[0];
			v.Columns["Дата"].DefaultCellStyle.Format = "MMMM yyyy";
			var row = selectedDate[tabInd];
			v.ClearSelection();
			v.Rows[row].Selected = true;
			EnsureVisibleRow(v, row);
		}

		private void PowerTable_Shown(object sender, EventArgs e) => UpdateDisplayingDate();
	}
}
