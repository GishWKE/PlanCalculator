namespace CalculatorComponents
{
	using System;
	using System.Collections;
	using System.Data;
	using System.Linq;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class Device : UserControl, IEnumerable
	{
		/// <summary>
		/// Период полураспада кобальта-60 в днях
		/// </summary>
		private static readonly double Cobalt60 = 5.271388888888888888888888888888D * 365.2425D;
		/// <summary>
		/// 1/период полураспада кобальта-60
		/// </summary>
		private static readonly double Cobalt60_1 = 1D / Cobalt60;
		public double? PreviousPower = null;
		private int PreviousIndex = -1, CurrentIndex = -1;
		/// <summary>
		/// Выбранный для отображения аппарат
		/// </summary>
		public DataRowView Selected => DeviceList.SelectedItem as DataRowView;
		public DataRowView Previous
		{
			get
			{
				if ( PreviousIndex != -1 )
				{
					//return DeviceList.Items [ PreviousIndex ] as DataRowView;
					return this [ PreviousIndex ];
				}

				return null;
			}
		}
		/// <summary>
		/// Данные по аппарату
		/// </summary>
		/// <param name="index">Порядковый номер аппарата</param>
		/// <returns></returns>
		public DataRowView this [ int index ] => DeviceList.Items [ index ] as DataRowView;
		/// <summary>
		/// Число аппаратов
		/// </summary>
		public int Count => DeviceList.Items.Count;
		/// <summary>
		/// Дабаить обработчик при измении выбранного элемента 
		/// </summary>
		/// <param name="add">Обработчик</param>
		public void Add ( EventHandler add ) => DeviceList.SelectedIndexChanged += add;
		/// <summary>
		/// Удалить обработчик при измении выбранного элемента 
		/// </summary>
		/// <param name="add">Обработчик</param>
		public void Del ( EventHandler del ) => DeviceList.SelectedIndexChanged -= del;
		/// <summary>
		/// Обработчик запросов к БД
		/// </summary>
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		/// <summary>
		/// Путь к файлу, в котором собержится БД
		/// </summary>
		public string FileName
		{
			get => sql.DataSource;
			set
			{
				sql.DataSource = value;
				UpdateData ( );
				PreviousIndex = -1;
				PreviousPower = null;
			}
		}
		private void FillDevicesList ( )
		{
			if ( FileName.IsEmpty ( ) )
			{
				return;
			}

			UpdateDeviesList ( sql.GetTable ( SQL.Device ) );
		}
		public bool Editable
		{
			get => Power.ReadOnly;
			set => Power.ReadOnly = !value;
		}
		private void UpdateDeviesList ( DataTable dt )
		{
			if ( !dt.IsEmpty ( ) )
			{
				RecalculatePower ( dt );
				DeviceList.DataSource = dt;
				DeviceList.DisplayMember = "Аппарат";
				DeviceList.SelectedIndex = 0;
			}
		}

		private void RecalculatePower ( DataTable dt )
		{
			foreach ( var r in dt.AsEnumerable ( ) )
			{
				var pow = ( double ) r [ "Мощность" ];
				var date = ( DateTime ) r [ "Дата замера мощности" ];
				double diff = ( DateTime.Now - date ).Days;
				r [ "Мощность" ] = pow / Math.Pow ( 2, diff * Cobalt60_1 );
			}
		}
		private void DeviceList_SelectedIndexChanged ( object sender, EventArgs e )
		{
			PreviousIndex = CurrentIndex;
			PreviousPower = Power.Value;
			CurrentIndex = DeviceList.SelectedIndex;
			var sel = Selected;
			SCD = ( int ) sel [ "РИЦ" ];
			Power.Value = ( double ) sel [ "Мощность" ];
		}
		public int? SCD
		{
			get => SCD_value.Value;
			set => SCD_value.Value = value;
		}
		public Device ( ) => InitializeComponent ( );
		public void UpdateData ( ) => FillDevicesList ( );
		IEnumerator IEnumerable.GetEnumerator ( ) => DeviceList.Items.GetEnumerator ( );
	}
}
