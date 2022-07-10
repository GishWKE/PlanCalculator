namespace PlanCalculator
{
	using System;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Windows.Forms;

	using CalculatorComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class AllDevicesPowerTable : Form
	{
		private static readonly DB_Worker sql = DB_Worker.Instance;
		private static readonly string DevName = @"Аппарат";
		private static readonly string DevPow0 = @"Мощность при загрузке источника, сГр/с";
		private static readonly string DevTim0 = @"Дата загрузки источника";
		private static readonly string DevPow1 = @"Средняя мощность на указанный месяц, сГр/с";
		private static readonly string DevPow2 = @"Мощность на указанную дату, сГр/с";
		private static readonly string DevTim1 = @"Дата";
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
				foreach ( var dr in dt.AsEnumerable ( ) )
				{
					var r = disp.NewRow ( );
					r [ DevName ] = dr [ "Аппарат" ].ToString ( );
					r [ DevPow0 ] = ( double ) dr [ "Мощность" ];
					r [ DevPow1 ] = 0D;
					r [ DevPow2 ] = 0D;
					r [ DevTim0 ] = ( DateTime ) dr [ "Дата замера мощности" ];
					dateTimePicker1.MinDate = new [ ] { dateTimePicker1.MinDate, ( DateTime ) r [ DevTim0 ] }.Min ( );
					r [ DevTim1 ] = dateTimePicker1.Value.Date;
					disp.Rows.Add ( r );
				}
				Calc ( );
			}
		}
		private readonly DataTable disp = new DataTable ( );
		public AllDevicesPowerTable ( )
		{
			InitializeComponent ( );
			dateTimePicker1.Value = DateTime.Now;
			dateTimePicker1.ValueChanged += new EventHandler ( dateTimePicker1_ValueChanged );
			_ = disp.Columns.Add ( DevName, typeof ( string ) );
			_ = disp.Columns.Add ( DevTim0, typeof ( DateTime ) );
			_ = disp.Columns.Add ( DevPow0, typeof ( double ) );
			_ = disp.Columns.Add ( DevTim1, typeof ( DateTime ) );
			_ = disp.Columns.Add ( DevPow2, typeof ( double ) );
			_ = disp.Columns.Add ( DevPow1, typeof ( double ) );
			dataGridView1.DataSource = disp;
		}
		private void Calc ( )
		{
			dataGridView1.SuspendLayout ( );
			foreach ( DataRow r in disp.Rows )
			{
				var pow0 = ( double ) r [ DevPow0 ];
				var dt0 = ( DateTime ) r [ DevTim0 ];
				r [ DevTim1 ] = dateTimePicker1.Value.Date;
				if ( ( DateTime ) r [ DevTim1 ] < dt0 )
				{
					r [ DevPow1 ] = double.PositiveInfinity;
					r [ DevPow2 ] = double.PositiveInfinity;
					var dt1 = ( DateTime ) r [ DevTim1 ];
					if ( dt1.Year == dt0.Year && dt1.Month == dt0.Month )
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
			dataGridView1.ResumeLayout ( );
			dataGridView1.Update ( );
			UpdateDispPow ( );
		}
		private void dateTimePicker1_ValueChanged ( object sender, EventArgs e ) => Calc ( );

		private void numericUpDown1_ValueChanged ( object sender, EventArgs e ) => UpdateDispPow ( );
		private void UpdateDispPow ( )
		{
			dataGridView1.Columns [ DevPow0 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
			dataGridView1.Columns [ DevPow1 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
			dataGridView1.Columns [ DevPow2 ].DefaultCellStyle.Format = $@"F{numericUpDown1.Value}";
		}
	}
}
