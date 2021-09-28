namespace CalculatorComponents
{
	using System;
using System.ComponentModel;
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
		public string FileName
		{
			get => sql.FileName;
			set => sql.FileName = value;
		}
		[DefaultValue ( null )]
		public int? D
		{
			get => Distance.Value;
			set => Distance.Value = value;
		}
		[DefaultValue ( null )]
		public double? T
		{
			get => Thickness.Value;
			set => Thickness.Value = value;
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => D != null && T != null ? L.Value : null;
			private set => L.Value = value;
		}
		[DefaultValue ( false )]
		public new bool Visible
		{
			get => IsLung.Checked;
			set => IsLung.Checked = value;
		}
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
			if ( TT == null || DD == null || FileName.IsEmpty ( ) )
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
