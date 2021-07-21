namespace PlanCalculator
{
	using System.Reflection;
	using System.Windows.Forms;

	internal partial class AboutBox1 : Form
	{
		public AboutBox1 ( )
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
