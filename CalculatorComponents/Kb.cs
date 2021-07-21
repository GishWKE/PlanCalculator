﻿namespace CalculatorComponents
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
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		[DefaultValue ( "" )]
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
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
		[DefaultValue ( null )]
		public int? A
		{
			get => A_size.Value;
			set => A_size.Value = value;
		}
		[DefaultValue ( null )]
		public int? B
		{
			get => B_size.Value;
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
