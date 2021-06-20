namespace BaseComponents
{
	using System;
using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.IO;
	using System.Linq;
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

		public static bool IsEmpty ( this DataTable dt )
		{
			try
			{
				return dt == null || dt.Rows == null || dt.Rows.Count == 0;
			}
			catch { throw; }
		}

		public static bool IsEmpty <T> ( this IEnumerable<T> l )
		{
			try
			{
				return l == null || l.Count () == 0;
			}
			catch { throw; }
		}
	}
}
