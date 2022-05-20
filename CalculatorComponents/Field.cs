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
	public partial class Field : UserControl
	{
		public event EventHandler RecalculationNeed;
		protected virtual void OnRecalculationNeed ( EventArgs e ) => RecalculationNeed?.Invoke ( this, e );
		public event EventHandler TotalRecalculationNeed;
		protected virtual void OnTotalRecalculationNeed ( EventArgs e ) => TotalRecalculationNeed?.Invoke ( this, e );
		[DefaultValue ( "" )]
		public new string Text
		{
			get => FieldPanel.Text;
			set => FieldPanel.Text = value;
		}
		public double? Weight
		{
			get => WeightValue;
			set => WeightValue.Value = value;
		}
		public bool IsLung => L_value;
		[DefaultValue ( true )]
		public bool IsInSeconds
		{
			get => Time_value.IsInSeconds;
			set => Time_value.IsInSeconds = value;
		}
		public int? Degree
		{
			get => FieldDegree;
			set => FieldDegree.Value = value;
		}
		[DefaultValue ( false )]
		public bool IsInMinutes
		{
			get => Time_value.IsInMinutes;
			set => Time_value.IsInMinutes = value;
		}
		public double? Kb => Kb_value;
		public double? OTV => OTV_value;
		public double? L => L_value;
		[DefaultValue ( null )]
		public double? Time
		{
			get => Time_value;
			set => Time_value.Value = value;
		}
		[DefaultValue ( "" )]
		public string FileName
		{
			get => OTV_value.FileName;
			set => OTV_value.FileName = L_value.FileName = value;
		}
		[DefaultValue ( 0 )]
		public int SCD
		{
			get => OTV_value.SCD;
			set => OTV_value.SCD = value;
		}
		[DefaultValue ( null )]
		public int? A
		{
			get => OTV_value.A;
			set => OTV_value.A = value;
		}
		[DefaultValue ( null )]
		public int? B
		{
			get => OTV_value.B;
			set => OTV_value.B = value;
		}
		public double? Depth => OTV_value.D;
		public Field ( ) : base ( )
		{
			InitializeComponent ( );
			FieldPanel.SuspendLayout ( );
			SuspendLayout ( );
			FieldPanel.Controls.Add ( Kb_value );
			OTV_value.Kb.FileName = null;
			Kb_value.Location = new System.Drawing.Point ( 6, 19 );
			Kb_value.MinimumSize = new System.Drawing.Size ( 184, 20 );
			Kb_value.Name = "Kb_value";
			Kb_value.Size = new System.Drawing.Size ( 184, 20 );
			Kb_value.TabIndex = 0;
			Kb_value.ValueChanged += new EventHandler ( Any_ValueChanged );
			FieldPanel.ResumeLayout ( false );
			FieldPanel.PerformLayout ( );
			ResumeLayout ( false );
		}
		private Kb_Control Kb_value => OTV_value.Kb;
		private void UpdateOTV_AB ( object sender, EventArgs e )
		{
			OTV_value.B = null;
			OTV_value.A = Kb_value.A;
			OTV_value.B = Kb_value.B;
		}

		private void Any_ValueChanged ( object sender, EventArgs e ) => OnRecalculationNeed ( EventArgs.Empty );
		private void AllRecalculate ( object sender, EventArgs e ) => OnTotalRecalculationNeed ( EventArgs.Empty );

	}
}
