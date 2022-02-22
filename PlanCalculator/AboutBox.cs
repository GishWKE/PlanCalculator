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
	using System.Diagnostics;
	using System.Reflection;
	using System.Windows.Forms;

	using BaseComponents;

	internal partial class AboutBox : Form
	{
		private readonly Assembly ass = Assembly.GetExecutingAssembly ( );
		public AboutBox ( )
		{
			InitializeComponent ( );
			Text = $@"О программе {AssemblyTitle}";
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = $@"Версия {AssemblyVersion}";
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
		}

		#region Методы доступа к атрибутам сборки

		public string AssemblyTitle
		{
			get
			{
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyTitleAttribute ), false );
				if ( attributes.Length > 0 )
				{
					var titleAttribute = ( AssemblyTitleAttribute ) attributes [ 0 ];
					if ( !titleAttribute.Title.IsEmpty ( ) )
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension ( ass.CodeBase );
			}
		}

		public string AssemblyVersion => ass.GetName ( ).Version.ToString ( );

		public string AssemblyDescription
		{
			get
			{
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyDescriptionAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyDescriptionAttribute ) attributes [ 0 ] ).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyProductAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyProductAttribute ) attributes [ 0 ] ).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyCopyrightAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyCopyrightAttribute ) attributes [ 0 ] ).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				var attributes = ass.GetCustomAttributes ( typeof ( AssemblyCompanyAttribute ), false );
				return ( attributes.Length == 0 ) ? string.Empty : ( ( AssemblyCompanyAttribute ) attributes [ 0 ] ).Company;
			}
		}
		#endregion

		private void RTB_LinkClicked ( object sender, LinkClickedEventArgs e ) => Process.Start ( e.LinkText );
	}
}
