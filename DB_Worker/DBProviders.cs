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
namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
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
		[DefaultValue ( -2 )]
		private static int selectedPrivider = -2;
		/// <summary>
		/// Свойства для получения строки с провайдером для подключения к БД
		/// </summary>
		[DefaultValue ( "" )]
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
			var tmp = providers.AsParallel ( ).
				Select ( ( provider, index ) => (provider, index) ).
				OrderByDescending ( p => regex.Match ( p.provider ).Value.ToInt ( ) ).
				 Where ( p => names.Any ( pp => pp.Equals ( p.provider, StringComparison.InvariantCultureIgnoreCase ) ) );
			if ( tmp.IsEmpty ( ) )
			{
				return;
			}

			selectedPrivider = tmp.First ( ).index;
		}
	}
}
