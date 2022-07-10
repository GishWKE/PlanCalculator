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
namespace CalculatorComponents
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Data;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;

	public partial class Device : UserControl, IEnumerable
	{
		/// <summary>
		/// Период полураспада кобальта-60 в днях
		/// </summary>
		private static readonly double Cobalt60 = 5.2713D * 365.2425D;
		public double? PreviousPower = null;
		private int PreviousIndex = -1, CurrentIndex = -1;
		public static double GetPower ( double pow, DateTime First, DateTime rezult ) => GetPower ( Cobalt60, pow, First, rezult );
		public static double GetPower ( double hL, double pow, DateTime First, DateTime rezult ) => pow / Math.Pow ( 2, ( rezult - First ).Days / hL );
		public static DateTime GetEndLifePower ( double powStart, DateTime First, double powEnd ) => GetEndLifePower ( Cobalt60, powStart, First, powEnd );
		public static DateTime GetEndLifePower ( double hL, double powStart, DateTime First, double powEnd ) => First.AddDays ( hL * Math.Log ( powStart / powEnd, 2 ) );
		/// <summary>
		/// Выбранный для отображения аппарат
		/// </summary>
		public DataRowView Selected => DeviceList.SelectedItem as DataRowView;
		[DefaultValue ( null )]
		public DataRowView Previous => PreviousIndex != -1 ? this [ PreviousIndex ] : null;
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
		public event EventHandler DeviceChanged
		{
			add => DeviceList.SelectedIndexChanged += value;
			remove => DeviceList.SelectedIndexChanged -= value;
		}
		/// <summary>
		/// Обработчик запросов к БД
		/// </summary>
		private static readonly DB_Worker sql = DB_Worker.Instance;
		/// <summary>
		/// Путь к файлу, в котором собержится БД
		/// </summary>
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.FileName;
			set
			{
				sql.FileName = value;
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
		[DefaultValue ( false )]
		public bool Editable
		{
			get => !Power.ReadOnly;
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
			var now = DateTime.Now;
			_ = Parallel.ForEach ( dt.AsEnumerable ( ), ( r ) => { r [ "Мощность" ] = GetPower ( ( double ) r [ "Мощность" ], ( DateTime ) r [ "Дата замера мощности" ], now ); } );
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
		[DefaultValue ( null )]
		public int? SCD
		{
			get => SCD_value.Value;
			set => SCD_value.Value = value;
		}
		public Device ( ) : base ( ) => InitializeComponent ( );
		public void UpdateData ( ) => FillDevicesList ( );
		IEnumerator IEnumerable.GetEnumerator ( ) => DeviceList.Items.GetEnumerator ( );
	}
}
