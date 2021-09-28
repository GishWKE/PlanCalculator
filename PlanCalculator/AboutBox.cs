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
namespace PlanCalculator
{
	using System.Reflection;
	using System.Windows.Forms;

	internal partial class AboutBox : Form
	{
		public AboutBox ( )
		{
			InitializeComponent ( );
			Text = string.Format ( "О программе {0}", AssemblyTitle );
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = string.Format ( "Версия {0}", AssemblyVersion );
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
		}

		#region Методы доступа к атрибутам сборки

		public string AssemblyTitle
		{
			get
			{
				var ass = Assembly.GetExecutingAssembly ( );
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyTitleAttribute ), false );
				if ( attributes.Length > 0 )
				{
					var titleAttribute = ( AssemblyTitleAttribute ) attributes [ 0 ];
					if ( titleAttribute.Title != "" )
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension ( ass.CodeBase );
			}
		}

		public string AssemblyVersion => Assembly.GetExecutingAssembly ( ).GetName ( ).Version.ToString ( );

		public string AssemblyDescription
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes ( typeof ( AssemblyDescriptionAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyDescriptionAttribute ) attributes [ 0 ] ).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes ( typeof ( AssemblyProductAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyProductAttribute ) attributes [ 0 ] ).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes ( typeof ( AssemblyCopyrightAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyCopyrightAttribute ) attributes [ 0 ] ).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				var attributes = Assembly.GetExecutingAssembly ( ).GetCustomAttributes ( typeof ( AssemblyCompanyAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyCompanyAttribute ) attributes [ 0 ] ).Company;
			}
		}
		#endregion

		private void RTB_LinkClicked ( object sender, LinkClickedEventArgs e ) => System.Diagnostics.Process.Start ( e.LinkText );
	}
}
