namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.Linq;
	using System.Text.RegularExpressions;

	using BaseComponents;

	using Resource.Properties;

	internal static class DBProviders
	{
		private static readonly Regex regex = new Regex ( RegEx.DigitInString );
		/// <summary>
		/// Список провайдеров для подключения к БД/Excel.
		/// </summary>
		private static readonly List<string> providers = new List<string> ( )
		{
			DB.Provider3,
			DB.Provider2,
			DB.Provider1,
			DB.Provider0
		};
		/// <summary>
		/// Индекс последнего (по дате создания) зарегестрированного в системе провайдера
		/// </summary>
		private static int selectedPrivider = -2;
		/// <summary>
		/// Свойства для получения строки с провайдером для подключения к БД
		/// </summary>
		public static string Provider
		{
			get
			{
				if ( selectedPrivider == -2 ) // Еще не сканировали
				{
					CheckProviders ( );
				}
				return selectedPrivider == -1 || selectedPrivider >= providers.Count
					? throw new Exception ( DB.Providers_error )
					: providers [ selectedPrivider ];
			}
		}
		/// <summary>
		/// Функция для поиска среди зарегестирированных провайдеров поддерживаемых
		/// </summary>
		private static void CheckProviders ( )
		{
			selectedPrivider = -1;
			if ( Environment.Is64BitOperatingSystem ) // Microsoft.Jet.OLEDB.4.0 - поддерживает только x86 ОС
			{
				providers.Remove ( DB.Provider0 );
			}
			var names = new OleDbEnumerator ( ).GetElements ( ).AsEnumerable ( ).AsParallel ( ).Select ( r => r [ 0 ].ToString ( ) );
			selectedPrivider = providers.AsParallel ( ).
				Select ( ( provider, index ) => (provider, index) ).
				OrderByDescending ( p => regex.Matches ( p.provider ).AsParallel ( ).Cast<Match> ( ).
				Select ( m => m.Value.ToInt ( ) ).Max ( ) ).
				 Where ( p => names.Any ( pp => pp.Equals ( p.provider, StringComparison.InvariantCultureIgnoreCase ) ) ).
				 First ( ).index;
		}
	}
}
