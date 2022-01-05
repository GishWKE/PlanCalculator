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
namespace CalculatorComponents
{
	using System;
	using System.ComponentModel;
	using System.IO;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;
	public partial class Lung : UserControl
	{
		private event EventHandler RecalculationNeed;
		protected virtual void OnRecalculationNeed ( EventArgs e ) => RecalculationNeed?.Invoke ( this, e );
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue ( "" )]
		public FileInfo FileName
		{
			get => sql.FileName;
			set => sql.FileName = value;
		}
		[DefaultValue ( null )]
		public int? D
		{
			get => Distance;
			set => Distance.Value = value;
		}
		[DefaultValue ( null )]
		public double? T
		{
			get => Thickness;
			set => Thickness.Value = value;
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => D != null && T != null ? L.Value : null;
			private set => L.Value = value;
		}
		public static implicit operator double? (Lung l)=>l.Value;
		[DefaultValue ( false )]
		public new bool Visible
		{
			get => IsLung.Checked;
			set => IsLung.Checked = value;
		}
		public static implicit operator bool ( Lung l ) => l.Visible;
		public Lung ( ) => InitializeComponent ( );
		private void L_ValueChanged ( object sender, EventArgs e ) => OnValueChanged ( EventArgs.Empty );
		private void Lung_RecalculationNeed ( object sender, EventArgs e )
		{
			L.ResetText ( );
			if ( !Visible )
			{
				return;
			}
			var TT = T;
			var DD = D;
			if ( TT == null || DD == null || !FileName.Exists )
			{
				return;
			}
			sql.AddParameter ( SQL.Lung_Thickness, TT );
			sql.AddParameter ( SQL.Lung_Distance, DD );
			Value = ( double? ) sql.GetValue ( SQL.Lung );
		}
		private void IsLung_CheckedChanged ( object sender, EventArgs e )
		{
			Lung_parameters.Visible = Visible;
			OnValueChanged ( EventArgs.Empty );
		}
	}
}
