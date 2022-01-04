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
		public static NumberFormatInfo nfi = ( NumberFormatInfo ) NumberFormatInfo.CurrentInfo.Clone ( );
		public static readonly char DblDot = char.Parse ( nfi.NumberDecimalSeparator );
		public static bool IsPathEquals ( this FileInfo s, FileInfo other )
		{
			try
			{
				return s.FullName.Equals ( other.FullName, StringComparison.InvariantCultureIgnoreCase );
			}
			catch
			{
				throw;
			}
		}
		public static bool IsPathEquals ( this FileInfo s, string other )
		{
			try
			{
				return s.IsPathEquals ( new FileInfo ( other ) );
			}
			catch
			{
				throw;
			}
		}
		public static bool IsPathEquals ( this string s, FileInfo other )
		{
			try
			{
				return other.IsPathEquals ( s );
			}
			catch
			{
				throw;
			}
		}
		public static bool IsPathEquals ( this string s, string other )
		{
			try
			{
				return !s.IsEmpty ( ) && !other.IsEmpty ( ) && new FileInfo ( s ).IsPathEquals ( other );
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
		public static decimal ToDecimal ( this string s )
		{
			try
			{
				return decimal.Parse ( s );
			}
			catch { throw; }
		}
		public static decimal ToDecimal ( this TextBoxBase tb )
		{
			try
			{
				return tb.Text.ToDecimal ( );
			}
			catch { throw; }
		}

		public static double ToDouble ( this string s )
		{
			try
			{
				return double.Parse ( s );
			}
			catch { throw; }
		}
		public static double ToDouble ( this TextBoxBase tb )
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

		public static int ToInt ( this TextBoxBase tb )
		{
			try
			{
				return tb.Text.ToInt ( );
			}
			catch { throw; }
		}

		public static bool IsEmpty ( this TextBoxBase tb )
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
				return dt == null || dt.Columns == null  || dt.Columns.Count == 0 || dt.Rows == null|| dt.Rows.Count == 0;
			}
			catch { throw; }
		}

		public static bool IsEmpty<T> ( this IEnumerable<T> l )
		{
			try
			{
				return l == null || !l.Any ( );
			}
			catch { throw; }
		}
	}
}
