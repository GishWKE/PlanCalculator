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
	using System.ComponentModel;
	using System.Windows.Forms;

	using Resource.Properties;

	public partial class Time : UserControl
	{
		private bool is_sec = true;
		[DefaultValue ( false )]
		public bool IsInMinutes
		{
			get => !IsInSeconds;
			set => IsInSeconds = !value;
		}
		[DefaultValue ( true )]
		public bool IsInSeconds
		{
			get => is_sec;
			set
			{
				is_sec = value;
				Time_label1.Text = value ? Resources.Time_seconds : Resources.Time_minutes;
				Time_value.FractionalPlaces = value ? 1 : 2;
				Value = Value;
			}
		}
		[DefaultValue ( null )]
		public double? Value
		{
			get => Time_value;
			set => Time_value.Value = value;
		}
		public static implicit operator double? ( Time t ) => t.Value;
		public Time ( )
		{
			InitializeComponent ( );
			IsInSeconds = true;
		}
	}
}
