﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirtualRadar.Plugin.SqlServer {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SqlServerStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlServerStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VirtualRadar.Plugin.SqlServer.SqlServerStrings", typeof(SqlServerStrings).Assembly);
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
        ///   Looks up a localized string similar to Cannot connect to database: {0}.
        /// </summary>
        public static string CannotConnectToDatabase {
            get {
                return ResourceManager.GetString("CannotConnectToDatabase", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command timeout.
        /// </summary>
        public static string CommandTimeout {
            get {
                return ResourceManager.GetString("CommandTimeout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connection string.
        /// </summary>
        public static string ConnectionString {
            get {
                return ResourceManager.GetString("ConnectionString", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A connection can be made with this connection string.
        /// </summary>
        public static string ConnectionStringOK {
            get {
                return ResourceManager.GetString("ConnectionStringOK", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Disabled.
        /// </summary>
        public static string Disabled {
            get {
                return ResourceManager.GetString("Disabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enabled.
        /// </summary>
        public static string Enabled {
            get {
                return ResourceManager.GetString("Enabled", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enabled, using {0}.
        /// </summary>
        public static string EnabledFullDescription {
            get {
                return ResourceManager.GetString("EnabledFullDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SQL Server.
        /// </summary>
        public static string FakeDatabaseFileName {
            get {
                return ResourceManager.GetString("FakeDatabaseFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open UpdateSchema.sql.
        /// </summary>
        public static string OpenUpdateSchemaFile {
            get {
                return ResourceManager.GetString("OpenUpdateSchemaFile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Changes to these settings will not take effect until the next time you start Virtual Radar Server.
        /// </summary>
        public static string OptionChangesNeedARestart {
            get {
                return ResourceManager.GetString("OptionChangesNeedARestart", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SQL Server.
        /// </summary>
        public static string PluginName {
            get {
                return ResourceManager.GetString("PluginName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Schema updated.
        /// </summary>
        public static string SchemaUpdated {
            get {
                return ResourceManager.GetString("SchemaUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Schema Updated.
        /// </summary>
        public static string SchemaUpdatedTitle {
            get {
                return ResourceManager.GetString("SchemaUpdatedTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (seconds).
        /// </summary>
        public static string SecondsParenthesis {
            get {
                return ResourceManager.GetString("SecondsParenthesis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Test Connection.
        /// </summary>
        public static string TestConnection {
            get {
                return ResourceManager.GetString("TestConnection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unspecified error.
        /// </summary>
        public static string UnspecifiedError {
            get {
                return ResourceManager.GetString("UnspecifiedError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Update Schema.
        /// </summary>
        public static string UpdateSchema {
            get {
                return ResourceManager.GetString("UpdateSchema", resourceCulture);
            }
        }
    }
}
