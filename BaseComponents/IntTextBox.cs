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
	public partial class IntTextBox : NumericTextBox
	{
		[DefaultValue ( null )]
		[Description ( "Переменная, отображаемая в поле" )]
		[Browsable ( true )]
		public new int? Value
		{
			get => ( int? ) base.Value;
			set => base.Value = value;
		}

		private new int FractionalPlaces
		{
			get => base.FractionalPlaces;
			set => base.FractionalPlaces = value;
		}
		private new TextBoxType Type
		{
			get => base.Type;
			set => base.Type = value;
		}
		public static implicit operator int? ( IntTextBox itb ) => itb.Value;
		public static implicit operator int ( IntTextBox itb ) => ( ( int? ) itb ).GetValueOrDefault ( );
		public static implicit operator double? ( IntTextBox itb ) => ( int? ) itb;
		public static implicit operator double ( IntTextBox itb ) => ( int ) itb;
		public IntTextBox ( ) : base ( ) => InitializeComponent ( );
	}
}
