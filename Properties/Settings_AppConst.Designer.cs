﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OLKI.Programme.ReFiDa.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.8.0.0")]
    internal sealed partial class Settings_AppConst : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings_AppConst defaultInstance = ((Settings_AppConst)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings_AppConst())));
        
        public static Settings_AppConst Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Changelog.txt")]
        public string AppUpdate_ChangeLog {
            get {
                return ((string)(this["AppUpdate_ChangeLog"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OLKI.Programme.ReFiDa")]
        public string AppUpdate_Name {
            get {
                return ((string)(this["AppUpdate_Name"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("OliverKind")]
        public string AppUpdate_Owner {
            get {
                return ((string)(this["AppUpdate_Owner"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ReFiDa__v{0}__Setup.exe")]
        public string AppUpdate_SetupSearchPattern {
            get {
                return ((string)(this["AppUpdate_SetupSearchPattern"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DefaultDate_Format {
            get {
                return ((string)(this["DefaultDate_Format"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int DefaultDate_Position {
            get {
                return ((int)(this["DefaultDate_Position"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DefaultDate_Seperatur {
            get {
                return ((string)(this["DefaultDate_Seperatur"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192, 192, 255")]
        public global::System.Drawing.Color FormatColor_ToRename {
            get {
                return ((global::System.Drawing.Color)(this["FormatColor_ToRename"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192, 255, 192")]
        public global::System.Drawing.Color FormatColor_Renamed {
            get {
                return ((global::System.Drawing.Color)(this["FormatColor_Renamed"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 192, 192")]
        public global::System.Drawing.Color FormatColor_Exception {
            get {
                return ((global::System.Drawing.Color)(this["FormatColor_Exception"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RaMaDe\\")]
        public string TempDirectoryName {
            get {
                return ((string)(this["TempDirectoryName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://learn.microsoft.com/de-de/dotnet/standard/base-types/custom-date-and-time" +
            "-format-strings")]
        public string FormatHelpLink {
            get {
                return ((string)(this["FormatHelpLink"]));
            }
        }
    }
}