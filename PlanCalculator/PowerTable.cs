namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using System.Windows.Forms;

	using BaseComponents;

	using CalculatorComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class PowerTable : Form
	{
		private readonly List<int> selectedDate = new List<int> ( );
		private readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.FileName;
			set
			{
				sql.FileName = value;
				tabControl1.TabPages.Clear ( );
				var dt = sql.GetTable ( SQL.Device );
				foreach ( var dr in dt.AsEnumerable ( ) )
				{
					var name = dr [ "Аппарат" ].ToString ( );
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
					var dt0 = new DataTable ( name );
					dt0.Columns.Add ( new DataColumn ( "Дата", typeof ( DateTime ) ) );
					dt0.Columns.Add ( new DataColumn ( "Мощность", typeof ( string ) ) );
					var pow0 = ( double ) dr [ "Мощность" ];
					var power = pow0;
					var pow = power.ToStringWithDecimalPlaces ( 2 );
					var date0 = ( DateTime ) dr [ "Дата замера мощности" ];
					var date = date0;
					var ind = ( DateTime.Today - date ).Days;
					selectedDate.Add ( ind );
					var lim = 0D.ToStringWithDecimalPlaces ( 2 );
					while ( pow != lim )
					{
						var r = dt0.NewRow ( );
						r [ "Дата" ] = date;
						r [ "Мощность" ] = power.ToStringWithDecimalPlaces ( 2 );
						dt0.Rows.Add ( r );
						date = date.AddDays ( 1 );
						power = Device.GetPower ( pow0, date0, date );
						pow = power.ToStringWithDecimalPlaces ( 2 );
					}
					dgv.DataSource = dt0.Copy ( );
					var tp = new TabPage ( name );
					tp.CreateControl ( );
					tp.Controls.Add ( dgv );
					tabControl1.TabPages.Add ( tp );
				}
			}
		}
		private static void EnsureVisibleRow ( DataGridView view, int rowToShow )
		{
			if ( rowToShow >= 0 && rowToShow < view.RowCount )
			{
				var countVisible = view.DisplayedRowCount ( false );
				var firstVisible = view.FirstDisplayedScrollingRowIndex;
				if ( rowToShow < firstVisible )
				{
					view.FirstDisplayedScrollingRowIndex = rowToShow;
				}
				else if ( rowToShow >= firstVisible + countVisible )
				{
					view.FirstDisplayedScrollingRowIndex = rowToShow - countVisible + 1;
				}
			}
		}
		public PowerTable ( )
		{
			InitializeComponent ( );
		}

		private void tabControl1_Selecting ( object sender, TabControlCancelEventArgs e )
		{
			UpdateDisplayingDate ( );
		}
		private void UpdateDisplayingDate ( )
		{
			var tab = tabControl1.SelectedTab;
			var tabInd = tabControl1.SelectedIndex;
			var v = ( DataGridView ) tab.Controls [ 0 ];
			var row = selectedDate [ tabInd ];
			v.ClearSelection ( );
			v.Rows [ row ].Selected = true;
			EnsureVisibleRow ( v, row );
		}

		private void PowerTable_Shown ( object sender, EventArgs e )
		{
			UpdateDisplayingDate ( );
		}
	}
}
