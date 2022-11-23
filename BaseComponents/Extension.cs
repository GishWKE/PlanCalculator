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
	using System.Runtime.InteropServices;
	using System.Text;
	using System.Windows.Forms;
	public static class Extension
	{
		public static readonly int NumberDecimalDigits = NumberFormatInfo.CurrentInfo.NumberDecimalDigits;
		public static readonly char NumberDecimalSeparator = char.Parse ( NumberFormatInfo.CurrentInfo.NumberDecimalSeparator );
		private const int EM_SETCUEBANNER = 0x1501;
		private const int EM_GETCUEBANNER = 0x1502;
		[DllImport ( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		[return: MarshalAs ( UnmanagedType.Bool )]
		private static extern bool SendMessage ( IntPtr hWnd, int msg, [MarshalAs ( UnmanagedType.Bool )] bool wParam, [MarshalAs ( UnmanagedType.LPWStr )] string lParam );
		[DllImport ( "user32.dll", CharSet = CharSet.Auto, SetLastError = true )]
		[return: MarshalAs ( UnmanagedType.Bool )]
		private static extern bool SendMessage ( IntPtr hWnd, int msg, [MarshalAs ( UnmanagedType.LPWStr )] string wParam, int lParam );
		public static void SetPlaceholder ( this Control c, string value )
		{
			if ( !SendMessage ( c.Handle, EM_SETCUEBANNER, false, value ?? string.Empty ) )
			{
				throw new Win32Exception ( Marshal.GetLastWin32Error ( ) );
			}
		}
		public static string GetPlaceholder ( this Control c )
		{
			var paceHolder = new string ( '\0', 1024 );
			return !SendMessage ( c.Handle, EM_GETCUEBANNER, paceHolder, 1024 )
				? throw new Win32Exception ( Marshal.GetLastWin32Error ( ) )
				: paceHolder.Replace ( "\0", string.Empty );
		}
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
		public static string ToStringWithDecimalPlaces ( this decimal? val, int dec ) => val.GetValueOrDefault ( decimal.Zero ).ToStringWithDecimalPlaces ( dec );
		public static string ToStringWithDecimalPlaces ( this double? val, int dec ) => ( ( decimal? ) val ).ToStringWithDecimalPlaces ( dec );
		public static string ToStringWithDecimalPlaces ( this double val, int dec ) => ( ( decimal ) val ).ToStringWithDecimalPlaces ( dec );
		public static string ToStringWithDecimalPlaces ( this decimal val, int dec )
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
		public static void Clear ( this string s ) => _ = string.Empty;
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

		public static bool IsFullEmpty ( this DataTable dt )
		{
			try
			{
				return dt == null || dt.Columns == null || dt.Columns.Count == 0 || dt.Rows == null || dt.Rows.Count == 0;
			}
			catch { throw; }
		}
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
				return l == null || !l.Any ( );
			}
			catch { throw; }
		}
	}
}
