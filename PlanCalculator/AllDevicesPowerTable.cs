namespace PlanCalculator
{
	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Drawing;
	using System.Linq;
	using System.Windows.Forms;

	using CalculatorComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class AllDevicesPowerTable : Form
	{
		private static readonly DB_Worker sql = DB_Worker.Instance;
		private static readonly string DevName = @"Аппарат";
		private static readonly string Pow = @"Мощность";
		private static readonly string DevPow0 = @"Замеренная мощность, сГр/с";
		private static readonly string DevTim0 = @"Дата замера мощности";
		private static readonly string DevPow1 = @"Средняя мощность на указанный месяц, сГр/с";
		private static readonly string DevPow2 = @"Мощность на указанную дату, сГр/с";
		private static readonly string DevTim1 = @"Дата";
		private static readonly string DevTim2 = @"Дата установления мощности 0.2сГр/с";
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.FileName;
			set
			{
				sql.FileName = value;
				disp.Rows.Clear ( );
				var dt = sql.GetTable ( SQL.Device );
				dateTimePicker1.MinDate = DateTime.Now.AddDays ( -1 );
				dateTimePicker1.MaxDate = DateTime.Now.AddDays ( 1 );
				foreach ( var dr in dt.AsEnumerable ( ) )
				{
					var r = disp.NewRow ( );
					r [ DevName ] = dr [ DevName ].ToString ( );
					r [ DevPow0 ] = ( double ) dr [ Pow ];
					r [ DevPow1 ] = double.NaN;
					r [ DevPow2 ] = double.NaN;
					r [ DevTim0 ] = ( DateTime ) dr [ DevTim0 ];
					r [ DevTim1 ] = dateTimePicker1.Value.Date;
					r [ DevTim2 ] = Device.GetEndLifePower ( ( double ) r [ DevPow0 ], ( DateTime ) r [ DevTim0 ], 0.2 );
					dateTimePicker1.MinDate = new [ ] { dateTimePicker1.MinDate, ( DateTime ) r [ DevTim0 ] }.Min ( );
					dateTimePicker1.MaxDate = new [ ] { dateTimePicker1.MaxDate, ( DateTime ) r [ DevTim2 ] }.Max ( );
					disp.Rows.Add ( r );
				}
				Calc ( );
			}
		}
		private readonly DataTable disp = new DataTable ( );
		public AllDevicesPowerTable ( )
		{
			InitializeComponent ( );
			_ = disp.Columns.Add ( DevName, typeof ( string ) );
			_ = disp.Columns.Add ( DevTim0, typeof ( DateTime ) );
			_ = disp.Columns.Add ( DevPow0, typeof ( double ) );
			_ = disp.Columns.Add ( DevTim1, typeof ( DateTime ) );
			_ = disp.Columns.Add ( DevPow2, typeof ( double ) );
			_ = disp.Columns.Add ( DevPow1, typeof ( double ) );
			_ = disp.Columns.Add ( DevTim2, typeof ( DateTime ) );
			dataGridView1.DataSource = disp;
			dateTimePicker1.Value = DateTime.Now;
		}
		private void Calc ( )
		{
			dataGridView1.SuspendLayout ( );
			foreach ( DataRow r in disp.Rows )
			{
				var pow0 = ( double ) r [ DevPow0 ];
				var dt0 = ( DateTime ) r [ DevTim0 ];
				var dt00 = ( DateTime ) r [ DevTim1 ];
				var calcNeed = double.IsNaN ( ( double ) r [ DevPow1 ] ) || dt00.Year != dateTimePicker1.Value.Year || dt00.Month != dateTimePicker1.Value.Month;
				r [ DevTim1 ] = dateTimePicker1.Value.Date;
				if ( ( DateTime ) r [ DevTim1 ] < dt0 )
				{
					r [ DevPow1 ] = double.NaN;
					r [ DevPow2 ] = double.NaN;
					var dt1 = ( DateTime ) r [ DevTim1 ];
					if ( calcNeed && dt1.Year == dt0.Year && dt1.Month == dt0.Month )
					{
						var date0 = dt0;
						var pow = pow0;
						var date1 = date0.AddDays ( 1 );
						while ( date1.Month == date0.Month )
						{
							pow += Device.GetPower ( pow0, dt0, date1 );
							date1 = date1.AddDays ( 1 );
						}
						var diff = ( date1 - date0 ).Days;
						r [ DevPow1 ] = pow / diff;
					}
				}
				else
				{
					r [ DevPow2 ] = Device.GetPower ( pow0, dt0, ( DateTime ) r [ DevTim1 ] );
					if ( calcNeed )
					{
						var date1 = ( DateTime ) r [ DevTim1 ];
						var date0 = new DateTime ( date1.Year, date1.Month, 1 );
						var pow = Device.GetPower ( pow0, dt0, date0 );
						date1 = date0.AddDays ( 1 );
						while ( date1.Month == date0.Month )
						{
							pow += Device.GetPower ( pow0, dt0, date1 );
							date1 = date1.AddDays ( 1 );
						}
						var diff = ( date1 - date0 ).Days;
						r [ DevPow1 ] = pow / diff;
					}
				}
			}
			dataGridView1.Columns [ DevTim0 ].DefaultCellStyle.Format = Resources.DateFormat;
			dataGridView1.Columns [ DevTim1 ].DefaultCellStyle.Format = Resources.DateFormat;
			dataGridView1.Columns [ DevTim2 ].DefaultCellStyle.Format = Resources.DateFormat;

			dataGridView1.ResumeLayout ( );
			dataGridView1.Update ( );
			CheckValues ( );
			UpdateDispPow ( );
		}
		private void dateTimePicker1_ValueChanged ( object sender, EventArgs e ) => Calc ( );

		private void numericUpDown1_ValueChanged ( object sender, EventArgs e ) => UpdateDispPow ( );
		private void CheckValues ( )
		{
			foreach ( DataGridViewRow r in dataGridView1.Rows )
			{
				r.DefaultCellStyle.BackColor = Color.Empty;
				if ( double.IsNaN ( ( double ) r.Cells [ DevPow1 ].Value ) || double.IsNaN ( ( double ) r.Cells [ DevPow2 ].Value ) )
				{
					r.DefaultCellStyle.BackColor = Color.Green;
				}
				if ( ( DateTime ) r.Cells [ DevTim1 ].Value > ( DateTime ) r.Cells [ DevTim2 ].Value )
				{
					r.DefaultCellStyle.BackColor = Color.Red;
				}
			}
			dataGridView1.Update ( );
		}
		private void UpdateDispPow ( )
		{
			dataGridView1.Columns [ DevPow0 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
			dataGridView1.Columns [ DevPow1 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
			dataGridView1.Columns [ DevPow2 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
			dataGridView1.Update ( );
		}

		private void AllDevicesPowerTable_Shown ( object sender, EventArgs e ) => CheckValues ( );

		private void dataGridView1_SelectionChanged ( object sender, EventArgs e ) => dataGridView1.ClearSelection ( );
	}
}
