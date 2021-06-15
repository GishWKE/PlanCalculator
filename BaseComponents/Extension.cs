namespace BaseComponents
{
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Windows.Forms;
	public static class Extension
	{
		public static readonly char DblDot = char.Parse ( CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator );
		public static double ToDouble ( this string tb )
		{
			return double.Parse ( tb );
		}
		public static double ToDouble ( this TextBox tb )
		{
			return tb.Text.ToDouble();
		}

		public static int ToInt ( this string tb )
		{
			return int.Parse ( tb );
		}

		public static int ToInt ( this TextBox tb )
		{
			return tb.Text.ToInt ( );
		}

		public static bool IsEmpty ( this TextBox tb )
		{
			return tb.Text.IsEmpty ( );
		}

		public static bool IsEmpty ( this string tb )
		{
			return string.IsNullOrWhiteSpace ( tb );
		}

		public static bool IsEmpty ( this DataTable dt )
		{
			return dt.Rows.Count == 0;
		}

		public static bool IsEmpty<T> ( this List<T> l )
		{
			return l.Count == 0;
		}
	}
}
