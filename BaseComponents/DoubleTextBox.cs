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
	public partial class DoubleTextBox : NumericTextBox
	{
		[DefaultValue ( null )]
		public new double? Value
		{
			get => ( double? ) base.Value;
			set => base.Value = ( decimal? ) value;
		}
		// Скрываем переменную
		private new NumericTextBoxTypes Type
		{
			get => base.Type;
			set => base.Type = value;
		}
		public static implicit operator double? ( DoubleTextBox dtb ) => dtb.Value;
		public static implicit operator double ( DoubleTextBox dtb ) => dtb.Value.GetValueOrDefault ( 0D );
		public DoubleTextBox ( ) : base ( ) => InitializeComponent ( );
	}
}
