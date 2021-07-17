namespace PlanCalculator
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	using BaseComponents;

	using CalculatorComponents;

	using Melanchall.DryWetMidi.Core;
	using Melanchall.DryWetMidi.Devices;

	using Resource.Properties;

	public partial class Form1 : Form
	{
		private readonly string FileName;
		private readonly List<Field> fields;
		public Form1 ( )
		{
			FileName = @".\Resources\DB.accdb";
			fields = new List<Field> ( );
			InitializeComponent ( );
			Devices.Add ( new EventHandler ( DeviceChanged ) );
			Devices.FileName = FileName;
			Text = DateTime.Today.ToString ( "d" );
			//DB_test ( );
		}
		private void DB_test ( )
		{
			var sb = new StringBuilder ( );
			var _KB = new Kb_Control ( );
			var _L = new Lung ( );
			var _OTV = new OTV ( );
			_KB.FileName = FileName;
			_L.FileName = FileName;
			_L.Visible = true;
			_OTV.FileName = FileName;
			for ( var dst = 1; dst <= 14; dst++ )
			{
				_L.D = dst;
				for ( var t = 0.5; t <= 12; t += 0.1 )
				{
					_L.T = t;
					if ( _L.Value == null )
					{
						sb.AppendLine ( $@"L - D: {dst}; T: {t}" );
					}
				}
			}
			for ( var a = 4; a <= 20; a++ )
			{
				_KB.SCD = 75;
				_OTV.SCD = 75;
				_KB.A = a;
				_OTV.A = a;
				for ( var b = 4; b <= 20; b++ )
				{
					_KB.B = b;
					_OTV.B = b;
					if ( _KB.Value == null )
					{
						sb.AppendLine ( $@"KB - A: {a}; B: {b}" );
					}
					for ( var d = 0.5; d <= 30; d += 0.1 )
					{
						_OTV.D = d;
						if ( _OTV.Value == null )
						{
							sb.AppendLine ( $@"ОТВ - A: {a}; B: {b}; Глубина: {d}" );
						}
					}
				}
			}
			if ( !sb.IsEmpty ( ) )
			{
				MessageBox.Show ( sb.ToString ( ) );
			}
		}

		private static readonly string regex_fmt = $"{RegEx.Begin}({RegEx.Values_0__9_9}|{{0}})?{RegEx.End}";

		private void DeviceChanged ( object sender, EventArgs e )
		{
			var sel = Devices.Selected;
			var scd = ( int ) sel [ "РИЦ" ];
			var sec = ( bool ) sel [ "Время в минутах" ];
			var regex_str = string.Empty;
			switch ( scd )
			{
				case var _ when scd >= 40 && scd <= 100 && scd % 10 == 0: // 40,50,60,70,80,90,100
					{
						regex_str = RegEx.Format_end0;
						break;
					}
				case var _ when scd >= 45 && scd <= 95 && scd % 10 == 5: // 45,55,65,75,85,95
					{
						regex_str = RegEx.Format_end5;
						break;
					}
				default:
					Distance.Regex.Clear ( );
					break;
			}
			if ( !regex_str.IsEmpty ( ) )
			{
				var tmp = scd / 10;
				var temp = string.Format ( regex_str, tmp - 1, tmp );
				Distance.Regex = string.Format ( regex_fmt, temp );
			}
			CalcSSD ( );
			foreach ( var f in fields )
			{
				f.IsInMinutes = sec;
				f.SCD = scd;
			}
		}
		private void Dose_Changed ( object sender, EventArgs e ) => Calculate ( );
		private void Calculate ( )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			foreach ( var f in fields )
			{
				Calculate ( f );
			}
			Cursor = tmp;
		}
		private void Calculate ( object fld )
		{
			if ( !( fld is Field ) )
			{
				return;
			}

			var f = fld as Field;
			f.Time = null;

			if ( new [ ] { D.Value, P.Value, f.Kb, f.OTV }.Any ( v => v == null ) || ( f.IsLung && f.L == null ) )
			{
				return;
			}

			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			var mult = new double [ ] { ( double ) D.Value, 100, 100, ( double ) N.Value };
			var div = new List<double> { ( double ) P.Value, ( double ) Devices.Selected [ "Мощность" ], ( double ) FieldsCount.Value, ( double ) f.Kb, ( double ) f.OTV };
			if ( f.IsLung )
			{
				div.Add ( ( double ) f.L );
			}

			if ( f.IsInMinutes )
			{
				div.Add ( 60 );
			}

			var Numerator = mult.AsParallel ( ).Aggregate ( 1D, ( aggregator, current ) => aggregator * current );
			var Divisor = div.AsParallel ( ).Aggregate ( 1D, ( aggregator, current ) => aggregator * current );
			f.Time = Numerator / Divisor;
			Cursor = tmp;
		}

		private void FieldCount_ValueChanged ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			var cnt = ( int ) FieldsCount.Value;
			if ( cnt == 0 )
			{
				AllFields.SuspendLayout ( );
				AllFields.Controls.Clear ( );
				fields.Clear ( );
				AllFields.ResumeLayout ( );
			}
			else if ( cnt < fields.Count )
			{
				AllFields.SuspendLayout ( );
				for ( var i = fields.Count - 1; i >= cnt; i-- )
				{
					AllFields.Controls.Remove ( fields [ i ] );
					fields.RemoveAt ( i );
				}
				AllFields.ResumeLayout ( );
				Calculate ( );
			}
			else
			{
				AllFields.SuspendLayout ( );
				var fld = new List<Field> ( );
				for ( var i = fields.Count; i < cnt; i++ )
				{
					var f = new Field
					{
						Text = $@"№{i + 1}:",
						Dock = DockStyle.Top,
						FileName = FileName,
						SCD = ( int ) Devices.SCD,
						A = ( int ) A.Value,
						B = ( int ) B.Value,
						IsInMinutes = ( bool ) Devices.Selected [ "Время в минутах" ]
					};
					f.RecalculationNeed += RecalculationNeed;
					fld.Add ( f );
				}
				fields.AddRange ( fld );
				AllFields.Controls.AddRange ( fld.ToArray ( ) );
				AllFields.ResumeLayout ( );
				Calculate ( );
			}
			Cursor = tmp;
		}

		private void RecalculationNeed ( object sender, EventArgs e ) => Calculate ( sender );

		private void AB_ValueChanged ( object sender, EventArgs e )
		{
			var obj = sender as NumericUpDown;
			var isA = obj.Name == "A";
			foreach ( var f in fields )
			{
				if ( isA )
				{
					f.A = ( int ) obj.Value;
				}
				else
				{
					f.B = ( int ) obj.Value;
				}
			}
		}
		private void Exit_Button_Click ( object sender, EventArgs e ) => Application.Exit ( );

		private void EditDevices_Click ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			if ( new EditDevices { FileName = FileName }.ShowDialog ( ) == DialogResult.OK )
			{
				Devices.FileName = FileName;
				Calculate ( );
			}
			Cursor = tmp;
		}
		private void Distance_Leave ( object sender, EventArgs e ) => CalcSSD ( );
		private void CalcSSD ( )
		{
			var DST = Distance.Value;
			var SCD = Devices.SCD;
			SSD.Clear ( );
			if ( SSD == null || DST > SCD )
			{
				return;
			}
			SSD.Value = SCD - DST;
		}

		private void добавлениеАппаратовToolStripMenuItem_Click ( object sender, EventArgs e )
		{
			var tmp = Cursor;
			Cursor = Cursors.WaitCursor;
			if ( new CreateDevice { FileName = FileName }.ShowDialog ( ) == DialogResult.Yes )
			{
				Devices.FileName = FileName;
				Calculate ( );
			}
			Cursor = tmp;
		}

		private void toolStripMenuItem1_Click ( object sender, EventArgs e )
		{
			if ( toolStripMenuItem1.Checked )
			{
				audio.RunWorkerAsync ( );
				toolStripMenuItem1.BackColor = ( ( SolidBrush ) Brushes.LightGreen ).Color;
			}
			else
			{
				audio.CancelAsync ( );
				toolStripMenuItem1.BackColor = выходToolStripMenuItem.BackColor;
			}
		}
		/*private class LoopStream : WaveStream
		{
			WaveStream sourceStream;
			public LoopStream ( WaveStream sourceStream )
			{
				this.sourceStream = sourceStream;
				this.EnableLooping = true;
			}
			public bool EnableLooping;
			public override WaveFormat WaveFormat=>sourceStream.WaveFormat;
			public override long Length=>sourceStream.Length;
			public override long Position
			{
				get=>sourceStream.Position;
				set=>sourceStream.Position = value;
			}
			public override int Read ( byte [ ] buffer, int offset, int count )
			{
				var totalBytesRead = 0;
				while ( totalBytesRead < count )
				{
					var bytesRead = sourceStream.Read ( buffer, offset + totalBytesRead, count - totalBytesRead );
					if ( bytesRead == 0 )
					{
						if ( sourceStream.Position == 0 || !EnableLooping )
						{
							// something wrong with the source stream
							break;
						}
						// loop
						sourceStream.Position = 0;
					}
					totalBytesRead += bytesRead;
				}
				return totalBytesRead;
			}
		}*/
		private void audio_DoWork ( object sender, System.ComponentModel.DoWorkEventArgs e )
		{
			var outputDevices = OutputDevice.GetAll ( );
			using ( var outputDevice = outputDevices.First ( ) )
			{
				var midiFile = MidiFile.Read ( @".\Resources\0.mid" );

				using ( var playback = midiFile.GetPlayback ( outputDevice ) )
				{
					playback.Loop = true;
					playback.Start ( );
					while ( !audio.CancellationPending )
					{
					}
					playback.Stop ( );
				}
			}
			//var bytes = Resources._0;
			//using ( var provider = new RawSourceWaveStream ( new MemoryStream ( bytes ), new WaveFormat ( 48000, 16, 1 ) ) )
			/*var file = new MidiFile ( @".\Resources\0.mid" );
			using ( var provider = new RawSourceWaveStream ( new MemoryStream ( Resources._0 ), new WaveFormat ( 48000, 16, 1 ) ) )
			{
				using ( var loopStream = new LoopStream ( provider ) )
				{
					using ( var _waveOut = new WaveOut ( ) )
					{
						_waveOut.Init ( loopStream );
						_waveOut.Play ( );
						while ( !audio.CancellationPending )
						{
						}
						_waveOut.Stop ( );
					}
				}
			}*/
		}
	}
}
