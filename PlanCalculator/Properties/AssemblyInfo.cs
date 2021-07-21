using System.Resources;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Общие сведения об этой сборке предоставляются следующим набором
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных со сборкой.
[assembly: AssemblyTitle ( "PlanCalculator" )]
[assembly: AssemblyDescription ( "Дозиметрическое планирование для гамма-аппаратов для дистанционной терапии (2D – планирование).\n\nКоэффициенты для расчетов взяты из:\nРатнер Т.Г., Фадеева М.А. ТЕХНИЧЕСКОЕ И ДОЗИМЕТРИЧЕСКОЕ ОБЕСПЕЧЕНИЕ ДИСТАНЦИОННОЙ ГАММА-ТЕРАПИИ. - М.: Медицина, 1982, 176 с., ил." )]
#if DEBUG
[assembly: AssemblyConfiguration ( "Отладочная версия" )]
#else
[assembly: AssemblyConfiguration ( "Финальная версия" )]
#endif
[assembly: AssemblyCompany ( "\nCreated by\n\tAntipov Roman (https://github.com/GishWKE)\n\tTsys' Alexandr (https://github.com/AlexTsys256)" )]
[assembly: AssemblyProduct ( "PlanCalculator" )]
[assembly: AssemblyCopyright ( "Copyright © 2021\n\tAntipov Roman (https://github.com/GishWKE)\n\tTsys' Alexandr (https://github.com/AlexTsys256)\n\nLicensed under the Apache License, Version 2.0 ( the \"License\" );\nyou may not use this file except in compliance with the License.\nYou may obtain a copy of the License at\n\n\thttp://www.apache.org/licenses/LICENSE-2.0 \n\nUnless required by applicable law or agreed to in writing, software\ndistributed under the License is distributed on an \"AS IS\" BASIS,\nWITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.\nSee the License for the specific language governing permissions and\nlimitations under the License." )]

[assembly: AssemblyTrademark ( "" )]
[assembly: AssemblyCulture ( "" )]

// Установка значения False для параметра ComVisible делает типы в этой сборке невидимыми
// для компонентов COM. Если необходимо обратиться к типу в этой сборке через
// COM, следует установить атрибут ComVisible в TRUE для этого типа.
[assembly: ComVisible ( false )]

// Следующий GUID служит для идентификации библиотеки типов, если этот проект будет видимым для COM
[assembly: Guid ( "30afbb25-adde-4f33-9eb1-73a9f0ab1f48" )]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      Основной номер версии
//      Дополнительный номер версии
//      Номер сборки
//      Редакция
//
// Можно задать все значения или принять номера сборки и редакции по умолчанию 
// используя "*", как показано ниже:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion ( "1.0.0.0" )]
[assembly: AssemblyFileVersion ( "1.0.0.0" )]
[assembly: NeutralResourcesLanguage ( "ru" )]
