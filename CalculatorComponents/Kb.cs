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
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	using Resource.Properties;
	public partial class Kb_Control : UserControl
	{
		private event EventHandler RecalculationNeed;
		protected virtual void OnRecalculationNeed ( EventArgs e ) => RecalculationNeed?.Invoke ( this, e );
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged ( EventArgs e ) => ValueChanged?.Invoke ( this, e );
		private int scd_val = 0;
		private static readonly DB_Worker sql = DB_Worker.Instance;
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.FileName;
			set => sql.FileName = value;
		}
		[DefaultValue ( 0 )]
		public int SCD
		{
			get => scd_val;
			set
			{
				scd_val = value;
				OnRecalculationNeed ( EventArgs.Empty );
			}
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => A != null && B != null ? Kb.Value : null;
			private set => Kb.Value = value;
		}
		public static implicit operator double? ( Kb_Control kb ) => kb.Value;
		[DefaultValue ( null )]
		public int? A
		{
			get => A_size;
			set => A_size.Value = value;
		}
		[DefaultValue ( null )]
		public int? B
		{
			get => B_size;
			set => B_size.Value = value;
		}
		public Kb_Control ( ) : base ( ) => InitializeComponent ( );
		private void Kb_ValueChanged ( object sender, EventArgs e ) => OnValueChanged ( EventArgs.Empty );
		private void Kb_RecalculationNeed ( object sender, EventArgs e )
		{
			Kb.ResetText ( );
			var AA = A;
			var BB = B;
			if ( AA == null || BB == null || SCD == 0 || FileName.IsEmpty ( ) )
			{
				return;
			}
			sql.AddParameter ( SQL.Kb_A, AA );
			sql.AddParameter ( SQL.Kb_B, BB );
			sql.AddParameter ( SQL.Kb_SCD, SCD );
			Value = ( double? ) sql.GetValue ( SQL.Kb );
		}
	}
}
