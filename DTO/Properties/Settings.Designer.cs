//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTO.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QL_SanBongDaMini;User ID=sa;Password" +
            "=tanhai123")]
        public string QL_SanBongDaMiniConnectionString {
            get {
                return ((string)(this["QL_SanBongDaMiniConnectionString"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=QL_SanBongDaMini;User ID=sa;Password" +
            "=tanhai")]
        public string Conn {
            get {
                return ((string)(this["Conn"]));
            }
            set {
                this["Conn"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=DESKTOP-4MGR8RB\\SQLEXPRESS;Initial Catalog=QL_SanBongDaMini;User ID=s" +
            "a;Password=tanhai123")]
        public string QL_SanBongDaMiniConnectionString1 {
            get {
                return ((string)(this["QL_SanBongDaMiniConnectionString1"]));
            }
        }
    }
}
