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
    public class RegEx {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RegEx() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Resource.Properties.RegEx", typeof(RegEx).Assembly);
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
        ///   Ищет локализованную строку, похожую на ^([4-9]|1\d|20)?$.
        /// </summary>
        public static string AB {
            get {
                return ResourceManager.GetString("AB", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^.
        /// </summary>
        public static string Begin {
            get {
                return ResourceManager.GetString("Begin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^(0?[,.][5-9]|[1-9]([,.]\d?)?|[1-2]\d([,.]\d?)?|30([,.]0?)?)?$.
        /// </summary>
        public static string Depth {
            get {
                return ResourceManager.GetString("Depth", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на \d+.
        /// </summary>
        public static string DigitInString {
            get {
                return ResourceManager.GetString("DigitInString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^([1-9]|1[0-4])?$.
        /// </summary>
        public static string Distance {
            get {
                return ResourceManager.GetString("Distance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^$.
        /// </summary>
        public static string Empty {
            get {
                return ResourceManager.GetString("Empty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на $.
        /// </summary>
        public static string End {
            get {
                return ResourceManager.GetString("End", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^([1-{0}]\d([,.]\d?)?|{1}0([,.]0?)?)$.
        /// </summary>
        public static string Format_end0 {
            get {
                return ResourceManager.GetString("Format_end0", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^([1-{0}]\d([,.]\d?)?|{1}[0-4]([,.]\d?)?|{1}5([,.]0?)?)$.
        /// </summary>
        public static string Format_end5 {
            get {
                return ResourceManager.GetString("Format_end5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^(0?[,.][5-9]|[1-9]([,.]\d?)?|1[0-1]([,.]\d?)?|12([,.]0?)?)?$.
        /// </summary>
        public static string Thickness {
            get {
                return ResourceManager.GetString("Thickness", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^(\d([,.]\d?)?|[,.]\d)?$.
        /// </summary>
        public static string Values_0__9_9 {
            get {
                return ResourceManager.GetString("Values_0__9_9", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на ^([1-9]|[1-9]\d|100)?$.
        /// </summary>
        public static string Values_1_100 {
            get {
                return ResourceManager.GetString("Values_1_100", resourceCulture);
            }
        }
    }
}
