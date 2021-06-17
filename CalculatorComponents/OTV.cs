namespace CalculatorComponents
{
	using System;
	using System.Collections.Generic;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	public partial class OTV : UserControl
	{
		public void Recalculate ( ) => OnLeave ( new EventArgs ( ) );

		private readonly Kb_Control Kb = new Kb_Control ( ); 
		/*
		private static readonly string AB_REGEX = @"^$|^([4-9]|1\d|20)$";
		private readonly IntTextBox A_size = new IntTextBox
		{
			Regex = AB_REGEX
		};
		private readonly IntTextBox B_size = new IntTextBox
		{
			Regex = AB_REGEX
		};*/
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
				if ( A != null && B != null && D != null )
				{
					return OTV_value.Value;
				}

				return null;
			}
			private set => OTV_value.Value = value;
		}
		private void AB_Depth_Changed_Leave ( object sender, EventArgs e ) => Recalculate ( );
		private void OTV_Leave ( object sender, EventArgs e ) => UpdateOTV ( );
		public static readonly string SQL_Query = "SELECT ОТВ.ОТВ FROM ОТВ WHERE ОТВ.Глубина=? AND ОТВ.B=? AND ОТВ.A=?;";
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
			Value = ( double? ) sql.GetValue ( SQL_Query, new List<(string name, object value)>
			{
				("ОТВ.Глубина",Depth.Value),
				("ОТВ.B",BB),
				("ОТВ.A",AA)
			} );
		}
		public OTV ( )
		{
			/*A_size.TextChanged += new EventHandler ( AB_Depth_Changed_Leave );
			A_size.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			B_size.TextChanged += new EventHandler ( AB_Depth_Changed_Leave );
			B_size.Leave += new EventHandler ( AB_Depth_Changed_Leave );*/
			Kb.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			InitializeComponent ( );
		}
	}
}
