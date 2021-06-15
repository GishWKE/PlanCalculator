namespace CalculatorComponents
{
	using System;
	using System.Windows.Forms;

	using BaseComponents;

	using DB_Worker;

	public partial class OTV : UserControl
	{
		public void Recalculate ( )
		{
			OnLeave ( new EventArgs ( ) );
		}
		private readonly IntTextBox A_size = new IntTextBox
		{
			Regex = @"^$|^([4-9]|1\d|20)$"
		};
		private readonly IntTextBox B_size = new IntTextBox
		{
			Regex = @"^$|^([4-9]|1\d|20)$",
		};
		private readonly OleDB_Worker sql = new OleDB_Worker ( );
		public string FileName
		{
			get => sql.DataSource;
			set => sql.DataSource = value;
		}
		public int? A
		{
			get => A_size.Value;
			set => A_size.Value = value;
		}
		public int? B
		{
			get => B_size.Value;
			set => B_size.Value = value;
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
			private set
			{
				OTV_value.ResetText ( );
				if ( value != null )
				{
					OTV_value.Text = $"{( double ) value:F3}";
				}
			}
		}
		private void AB_Depth_Changed_Leave ( object sender, EventArgs e )
		{
			Recalculate ( );
		}
		private void OTV_Leave ( object sender, EventArgs e )
		{
			UpdateOTV ( );
		}
		private void UpdateOTV ( )
		{
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
			var SQL_string = $@"SELECT ОТВ.ОТВ FROM ОТВ WHERE ОТВ.Глубина = {Depth.Value} AND ОТВ.B = {B} AND ОТВ.A = {A};".Replace ( Extension.DblDot, '.' );
			Value = ( double? ) sql.GetValue ( SQL_string );
		}
		public OTV ( )
		{
			A_size.TextChanged += new EventHandler ( AB_Depth_Changed_Leave );
			A_size.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			B_size.TextChanged += new EventHandler ( AB_Depth_Changed_Leave );
			B_size.Leave += new EventHandler ( AB_Depth_Changed_Leave );
			InitializeComponent ( );
		}
	}
}
