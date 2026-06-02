namespace CityExplorer.Resources.Strings {
    using System;
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CityExplorer.Resources.Strings.AppResources", typeof(AppResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string AddToFavorites {
            get {
                return ResourceManager.GetString("AddToFavorites", resourceCulture);
            }
        }
        
        public static string AllCategories {
            get {
                return ResourceManager.GetString("AllCategories", resourceCulture);
            }
        }
        
        public static string ExploreTitle {
            get {
                return ResourceManager.GetString("ExploreTitle", resourceCulture);
            }
        }
        
        public static string FavoritesTitle {
            get {
                return ResourceManager.GetString("FavoritesTitle", resourceCulture);
            }
        }
        
        public static string Remove {
            get {
                return ResourceManager.GetString("Remove", resourceCulture);
            }
        }
        
        public static string SelectLanguage {
            get {
                return ResourceManager.GetString("SelectLanguage", resourceCulture);
            }
        }
        
        public static string SettingsTitle {
            get {
                return ResourceManager.GetString("SettingsTitle", resourceCulture);
            }
        }
    }
}
