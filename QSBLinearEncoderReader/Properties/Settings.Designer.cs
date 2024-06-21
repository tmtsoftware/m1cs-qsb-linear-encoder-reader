﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QSBLinearEncoderReader.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.5.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PortName {
            get {
                return ((string)(this["PortName"]));
            }
            set {
                this["PortName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("X4")]
        public global::QSBLinearEncoderReader.QuadratureMode QuadratureMode {
            get {
                return ((global::QSBLinearEncoderReader.QuadratureMode)(this["QuadratureMode"]));
            }
            set {
                this["QuadratureMode"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5.00")]
        public decimal Resolution_nm {
            get {
                return ((decimal)(this["Resolution_nm"]));
            }
            set {
                this["Resolution_nm"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ZeroPositionCount {
            get {
                return ((int)(this["ZeroPositionCount"]));
            }
            set {
                this["ZeroPositionCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CountUp")]
        public global::QSBLinearEncoderReader.EncoderDirection Direction {
            get {
                return ((global::QSBLinearEncoderReader.EncoderDirection)(this["Direction"]));
            }
            set {
                this["Direction"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("230400")]
        public int BaudRate {
            get {
                return ((int)(this["BaudRate"]));
            }
            set {
                this["BaudRate"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("%APPDATA%\\QSBLinearEncoderReader")]
        public string OutputDirectory {
            get {
                return ((string)(this["OutputDirectory"]));
            }
            set {
                this["OutputDirectory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Encoder_%N_%Y%m%d_%H%M%S.csv")]
        public string CSVFilename {
            get {
                return ((string)(this["CSVFilename"]));
            }
            set {
                this["CSVFilename"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("512")]
        public uint RecordingInterval {
            get {
                return ((uint)(this["RecordingInterval"]));
            }
            set {
                this["RecordingInterval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("86400")]
        public uint MaxRecordsPerFile {
            get {
                return ((uint)(this["MaxRecordsPerFile"]));
            }
            set {
                this["MaxRecordsPerFile"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("128")]
        public ulong DisplayUpdateInterval {
            get {
                return ((ulong)(this["DisplayUpdateInterval"]));
            }
            set {
                this["DisplayUpdateInterval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExpandConnectionStatus {
            get {
                return ((bool)(this["ExpandConnectionStatus"]));
            }
            set {
                this["ExpandConnectionStatus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExpandRecording {
            get {
                return ((bool)(this["ExpandRecording"]));
            }
            set {
                this["ExpandRecording"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExpandStatistics {
            get {
                return ((bool)(this["ExpandStatistics"]));
            }
            set {
                this["ExpandStatistics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool ExpandStatus {
            get {
                return ((bool)(this["ExpandStatus"]));
            }
            set {
                this["ExpandStatus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("125")]
        public int TextBoxStatusHeight {
            get {
                return ((int)(this["TextBoxStatusHeight"]));
            }
            set {
                this["TextBoxStatusHeight"] = value;
            }
        }
    }
}
