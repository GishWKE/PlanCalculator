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
namespace BaseComponents
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Globalization;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;
	public static class Extension
	{
		public static readonly char DblDot = char.Parse ( CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator );
		public static bool IsPathEquals ( this string s, string other )
		{
			try
			{
				return !s.IsEmpty ( ) && !other.IsEmpty ( ) && new FileInfo ( s ).FullName.Equals ( new FileInfo ( other ).FullName, StringComparison.InvariantCultureIgnoreCase );
			}
			catch
			{
				throw;
			}
		}
		public static string ToStringWithDecimalPlaces ( this double ? val, int dec )
		{
			if ( val == null )
				return 0D.ToStringWithDecimalPlaces ( dec );
			return val.Value.ToStringWithDecimalPlaces ( dec );
		}
		public static string ToStringWithDecimalPlaces ( this double val, int dec )
		{
			var nfi = ( NumberFormatInfo ) NumberFormatInfo.CurrentInfo.Clone ( );
			nfi.NumberDecimalDigits = dec;
			return val.ToString ( "F", nfi );
		}
		public static void CloseAndWait ( this BackgroundWorker bw )
		{
			bw.CancelAsync ( );
			while ( bw.IsBusy )
			{
				Application.DoEvents ( );
			}
		}
		public static void Clear ( this string s ) => s = string.Empty;
		public static double ToDouble ( this string s )
		{
			try
			{
				return double.Parse ( s );
			}
			catch { throw; }
		}
		public static double ToDouble ( this TextBox tb )
		{
			try
			{
				return tb.Text.ToDouble ( );
			}
			catch { throw; }
		}

		public static int ToInt ( this string s )
		{
			try
			{
				return int.Parse ( s );
			}
			catch { throw; }
		}

		public static int ToInt ( this TextBox tb )
		{
			try
			{
				return tb.Text.ToInt ( );
			}
			catch { throw; }
		}

		public static bool IsEmpty ( this TextBox tb )
		{
			try
			{
				return tb == null || tb.Text.IsEmpty ( );
			}
			catch { throw; }
		}

		public static bool IsEmpty ( this string s ) => string.IsNullOrWhiteSpace ( s );
		public static bool IsEmpty ( this StringBuilder sb ) => sb.ToString ( ).IsEmpty ( );

		public static bool IsEmpty ( this DataTable dt )
		{
			try
			{
				return dt == null || dt.Rows == null || dt.Rows.Count == 0;
			}
			catch { throw; }
		}

		public static bool IsEmpty<T> ( this IEnumerable<T> l )
		{
			try
			{
				return l == null || l.Count ( ) == 0;
			}
			catch { throw; }
		}
	}
}
