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
namespace BaseComponents
{
	using System.ComponentModel;
	using System.Text.RegularExpressions;

	public partial class IntTextBox : NumericTextBox
	{
		[DefaultValue ( null )]
		public new int? Value
		{
			get => ( int? ) base.Value;
			set => base.Value = value;
		}
		// Скрываем переменную
		private new NumericTextBoxTypes Type
		{
			get => base.Type;
			set => base.Type = value;
		}
		// Скрываем переменную
		private new int FractionalPlaces
		{
			get => base.FractionalPlaces;
			set => base.FractionalPlaces = value;
		}
		private new Regex empty
		{
			get; set;
		}
		public static implicit operator int? ( IntTextBox itb ) => itb.Value;
		public static implicit operator double? ( IntTextBox itb ) => itb.Value;
		public static implicit operator int ( IntTextBox itb ) => ( ( int? ) itb ).GetValueOrDefault ( 0 );
		public static implicit operator double ( IntTextBox itb ) => ( ( double? ) itb ).GetValueOrDefault ( 0D );
		public IntTextBox ( ) : base ( @"^-?$" ) => InitializeComponent ( );
	}
}
