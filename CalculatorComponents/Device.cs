﻿namespace CalculatorComponents
{
	using System;
	using System.Data;
	using System.Linq;
	using System.Windows.Forms;


	using BaseComponents;

	using DB_Worker;

	public partial class Device : UserControl
	{
		/// <summary>
		/// Период полураспада кобальта-60 в днях
		/// </summary>
		private readonly double Cobalt60 = 5.27138888888889D * 365.25D;
		/// <summary>
		/// Выбранный для отображения аппарат
		/// </summary>
		public DataRowView Selected => DeviceList.SelectedItem as DataRowView;
		/// <summary>
		/// Дабаить обработчик при измении выбранного элемента 
		/// </summary>
		/// <param name="add">Обработчик</param>
		public void Add ( EventHandler add )
		{
			DeviceList.SelectedIndexChanged += add;
		}
		/// <summary>
		/// Удалить обработчик при измении выбранного элемента 
		/// </summary>
		/// <param name="add">Обработчик</param>
		public void Del ( EventHandler del )
		{
			DeviceList.SelectedIndexChanged -= del;
		}
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
			}
		}
		private void FillDevicesList ( )
		{
			if ( FileName.IsEmpty ( ) )
			{
				return;
			}

			var SQLstr = "SELECT * FROM [Аппараты];";
			UpdateDeviesList ( sql.GetTable ( SQLstr ) );
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
				var diff = ( double ) ( DateTime.Now - date ).Days;
				r [ "Мощность" ] = pow / Math.Pow ( 2, diff / Cobalt60 );
			}
		}
		private void DeviceList_SelectedIndexChanged ( object sender, EventArgs e )
		{
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
		public void UpdateData ( )
		{
			FillDevicesList ( );
		}
	}
}
