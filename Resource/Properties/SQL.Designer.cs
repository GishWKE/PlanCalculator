﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resource.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SQL {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SQL() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resource.Properties.SQL", typeof(SQL).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на INSERT INTO [Аппараты] VALUES (?,?,?,?,?);.
        /// </summary>
        public static string CreateDevice {
            get {
                return ResourceManager.GetString("CreateDevice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT Аппараты.* FROM Аппараты;.
        /// </summary>
        public static string Device {
            get {
                return ResourceManager.GetString("Device", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аппараты.[Дата замера мощности].
        /// </summary>
        public static string DeviceCheckPower_Table {
            get {
                return ResourceManager.GetString("DeviceCheckPower_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аппараты.Аппарат.
        /// </summary>
        public static string DeviceName_Table {
            get {
                return ResourceManager.GetString("DeviceName_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аппараты.Мощность.
        /// </summary>
        public static string DevicePower_Table {
            get {
                return ResourceManager.GetString("DevicePower_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аппараты.РИЦ.
        /// </summary>
        public static string DeviceSCD_Table {
            get {
                return ResourceManager.GetString("DeviceSCD_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Аппараты.[Время в минутах].
        /// </summary>
        public static string DeviceTime_Table {
            get {
                return ResourceManager.GetString("DeviceTime_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT Кб.Кб
        ///FROM Кб
        ///WHERE ((Кб.A=?) AND (Кб.B=?) AND (Кб.РИЦ=?));.
        /// </summary>
        public static string Kb {
            get {
                return ResourceManager.GetString("Kb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Кб.A.
        /// </summary>
        public static string Kb_A {
            get {
                return ResourceManager.GetString("Kb_A", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Кб.B.
        /// </summary>
        public static string Kb_B {
            get {
                return ResourceManager.GetString("Kb_B", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Кб.РИЦ.
        /// </summary>
        public static string Kb_SCD {
            get {
                return ResourceManager.GetString("Kb_SCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT Легочная_ткань.L
        ///FROM Легочная_ткань
        ///WHERE ((Легочная_ткань.[Толщина легкого]=?) AND (Легочная_ткань.[Расстояние от точки расчета до легкого (не более)]=?));.
        /// </summary>
        public static string Lung {
            get {
                return ResourceManager.GetString("Lung", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Легочная_ткань.[Расстояние от точки расчета до легкого (не более)].
        /// </summary>
        public static string Lung_Distance {
            get {
                return ResourceManager.GetString("Lung_Distance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Легочная_ткань.[Толщина легкого].
        /// </summary>
        public static string Lung_Thickness {
            get {
                return ResourceManager.GetString("Lung_Thickness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на SELECT ОТВ.ОТВ
        ///FROM ОТВ
        ///WHERE ((ОТВ.A=?) AND (ОТВ.B=?) AND (ОТВ.Глубина=?));.
        /// </summary>
        public static string OTV {
            get {
                return ResourceManager.GetString("OTV", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ОТВ.A.
        /// </summary>
        public static string OTV_A {
            get {
                return ResourceManager.GetString("OTV_A", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ОТВ.B.
        /// </summary>
        public static string OTV_B {
            get {
                return ResourceManager.GetString("OTV_B", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ОТВ.Глубина.
        /// </summary>
        public static string OTV_Depth {
            get {
                return ResourceManager.GetString("OTV_Depth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на UPDATE Аппараты
        ///SET Аппараты.Мощность=?, Аппараты.[Дата замера мощности]=Date()
        ///WHERE Аппараты.Аппарат=?;.
        /// </summary>
        public static string UpdateDevice {
            get {
                return ResourceManager.GetString("UpdateDevice", resourceCulture);
            }
        }
    }
}
