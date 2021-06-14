
namespace DB_Worker
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.OleDb;
	using System.Linq;

	internal static class DBProviders
	{
		/// <summary>
		/// Список провайдеров для подключения к БД/Excel.
		/// </summary>
		private static readonly List<string> providers = new List<string> ( )
		{
			@"Microsoft.ACE.OLEDB.16.0",
			@"Microsoft.ACE.OLEDB.14.0",
			@"Microsoft.ACE.OLEDB.12.0",
			@"Microsoft.Jet.OLEDB.4.0"
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
				if ( selectedPrivider == -1 || selectedPrivider >= providers.Count ) // Не найден или какая-то ошибка
				{
					throw new Exception ( @"Не обнаружены провайдеры подключения к БД" );
				}

				return providers [ selectedPrivider ];
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
				providers.RemoveAt ( providers.Count - 1 );
			}
			//var enumerator = new OleDbEnumerator ( ); // Полная информация о зарегестрированных провайдерах (Lazy)
			var el = new OleDbEnumerator ( ).GetElements ( ); // Полная информация о зарегестрированных провайдерах
			var fl = 0; // Битовая маска. 1 - соответствующий провайдер установлен, 0 - его нет
			var ParProv = providers.AsParallel ( ); // Для более быстрого поиска
			foreach ( var r in el.AsEnumerable ( ) ) // Проверка по одному
			{
				var pp = r [ 0 ].ToString ( ).ToLower ( ); // Имя провайдера

				if ( ParProv.Any ( p => p.ToLower ( ).Equals ( pp ) ) ) // Если провайдер есть в списке
				{
					switch ( pp )
					{
						case string pr when pr.Equals ( providers [ 0 ].ToLower ( ) ):
							fl |= 0b1000;
							break;
						case string pr when pr.Equals ( providers [ 1 ].ToLower ( ) ):
							fl |= 0b100;
							break;
						case string pr when pr.Equals ( providers [ 2 ].ToLower ( ) ):
							fl |= 0b10;
							break;
						default:
							fl |= 0b1;
							break;
					}
				}
			}
			if ( ( fl & 0b1000 ) != 0 )
			{
				selectedPrivider = 0;
			}
			else if ( ( fl & 0b100 ) != 0 )
			{
				selectedPrivider = 1;
			}
			else if ( ( fl & 0b10 ) != 0 )
			{
				selectedPrivider = 2;
			}
			else if ( ( fl & 0b1 ) != 0 )
			{
				selectedPrivider = 3;
			}
		}
	}
}
