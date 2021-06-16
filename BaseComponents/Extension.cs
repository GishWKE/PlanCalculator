namespace BaseComponents
{
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Windows.Forms;
	public static class Extension
	{
		public static readonly char DblDot = char.Parse ( CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator );
		public static void Clear ( this string s ) => s = string.Empty;
		public static double ToDouble ( this string tb ) => double.Parse ( tb );
		public static double ToDouble ( this TextBox tb ) => tb.Text.ToDouble ( );

		public static int ToInt ( this string tb ) => int.Parse ( tb );

		public static int ToInt ( this TextBox tb ) => tb.Text.ToInt ( );

		public static bool IsEmpty ( this TextBox tb ) => tb.Text.IsEmpty ( );

		public static bool IsEmpty ( this string tb ) => string.IsNullOrWhiteSpace ( tb );

		public static bool IsEmpty ( this DataTable dt ) => dt.Rows.Count == 0;

		public static bool IsEmpty<T> ( this List<T> l ) => l.Count == 0;
	}
}
