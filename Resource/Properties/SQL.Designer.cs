﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Resource.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
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
        ///   Returns the cached ResourceManager instance used by this class.
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
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to INSERT INTO [Аппараты] (Аппараты.Аппарат,Аппараты.Мощность,Аппараты.РИЦ,Аппараты.[Время в минутах],Аппараты.[Дата замера мощности]) VALUES(?,?,?,?,?);.
        /// </summary>
        public static string CreateDevice {
            get {
                return ResourceManager.GetString("CreateDevice", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT * FROM [Аппараты];.
        /// </summary>
        public static string Device {
            get {
                return ResourceManager.GetString("Device", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Аппараты.[Дата замера мощности].
        /// </summary>
        public static string DeviceCheckPower_Table {
            get {
                return ResourceManager.GetString("DeviceCheckPower_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Аппараты.Аппарат.
        /// </summary>
        public static string DeviceName_Table {
            get {
                return ResourceManager.GetString("DeviceName_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Аппараты.Мощность.
        /// </summary>
        public static string DevicePower_Table {
            get {
                return ResourceManager.GetString("DevicePower_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Аппараты.РИЦ.
        /// </summary>
        public static string DeviceSCD_Table {
            get {
                return ResourceManager.GetString("DeviceSCD_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Аппараты.[Время в минутах].
        /// </summary>
        public static string DeviceTime_Table {
            get {
                return ResourceManager.GetString("DeviceTime_Table", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT Кб.Кб FROM Кб WHERE Кб.РИЦ=? AND Кб.A=? AND Кб.B=?;.
        /// </summary>
        public static string Kb {
            get {
                return ResourceManager.GetString("Kb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кб.A.
        /// </summary>
        public static string Kb_A {
            get {
                return ResourceManager.GetString("Kb_A", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кб.B.
        /// </summary>
        public static string Kb_B {
            get {
                return ResourceManager.GetString("Kb_B", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Кб.РИЦ.
        /// </summary>
        public static string Kb_SCD {
            get {
                return ResourceManager.GetString("Kb_SCD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT [Легочная ткань].L FROM [Легочная ткань] WHERE [Легочная ткань].[Толщина легкого]=? AND [Легочная ткань].[Расстояние от точки расчета до легкого (не более)]=?;.
        /// </summary>
        public static string Lung {
            get {
                return ResourceManager.GetString("Lung", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Легочная ткань].[Расстояние от точки расчета до легкого (не более)].
        /// </summary>
        public static string Lung_Distance {
            get {
                return ResourceManager.GetString("Lung_Distance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [Легочная ткань].[Толщина легкого].
        /// </summary>
        public static string Lung_Thickness {
            get {
                return ResourceManager.GetString("Lung_Thickness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT ОТВ.ОТВ FROM ОТВ WHERE ОТВ.Глубина=? AND ОТВ.B=? AND ОТВ.A=?;.
        /// </summary>
        public static string OTV {
            get {
                return ResourceManager.GetString("OTV", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ОТВ.A.
        /// </summary>
        public static string OTV_A {
            get {
                return ResourceManager.GetString("OTV_A", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ОТВ.B.
        /// </summary>
        public static string OTV_B {
            get {
                return ResourceManager.GetString("OTV_B", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ОТВ.Глубина.
        /// </summary>
        public static string OTV_Depth {
            get {
                return ResourceManager.GetString("OTV_Depth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [Аппараты] SET [Аппараты].[Мощность]=?, [Аппараты].[Дата замера мощности]=? WHERE [Аппараты].[Аппарат]=?;.
        /// </summary>
        public static string UpdateDevice {
            get {
                return ResourceManager.GetString("UpdateDevice", resourceCulture);
            }
        }
    }
}
