﻿namespace CalculatorComponents
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using BaseComponents;
	using Resource.Properties;

	using DB_Worker;

	public partial class OTV : UserControl
	{
		public void Recalculate ( ) => OnLeave ( new EventArgs ( ) );

		private readonly Kb_Control Kb = new Kb_Control ( );
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}
		public int? A
		{
			get => Kb.A;
			set => Kb.A = value;
		}
		public int? B
		{
			get => Kb.B;
			set => Kb.B = value;
		}
		public double? D
		{
			get => Depth.Value;
			set => Depth.Value = value;
		}
		public double? Value
		{
			get
			{
				return A != null && B != null && D != null ? OTV_value.Value : null;
			}
			private set => OTV_value.Value = value;
		}
		private void AB_Depth_Changed_Leave ( object sender, EventArgs e ) => Recalculate ( );
		private void OTV_Leave ( object sender, EventArgs e ) => UpdateOTV ( );
		private void UpdateOTV ( )
		{
			if ( Parent == null ) // Не размещен на форме/компоненте
				return;
			OTV_value.ResetText ( );
			if ( !Visible )
			{
				return;
			}

			var AA = A;
			var BB = B;
			var DD = D;
			if ( AA == null || BB == null || DD == null || FileName.IsEmpty ( ) )
			{
				return;
			}
			var prop = new Dictionary<string, object>
			{
				[ SQL.OTV_A ] = AA,
				[ SQL.OTV_B ] = BB,
				[ SQL.OTV_Depth ] = Depth.Value
			};
			Value = ( double? ) sql.GetValue ( SQL.OTV, prop );
		}
		public OTV ( )
		{
			Kb.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			InitializeComponent ( );
		}
	}
}
