﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VtrFramework {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ExceptionMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("VtrFramework.ExceptionMessages", typeof(ExceptionMessages).Assembly);
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
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connection String.
        /// </summary>
        internal static string ConnectionStringParameter {
            get {
                return ResourceManager.GetString("ConnectionStringParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to connStrProvider.
        /// </summary>
        internal static string ConnectionStringProviderParameter {
            get {
                return ResourceManager.GetString("ConnectionStringProviderParameter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command type inválido!.
        /// </summary>
        internal static string InvalidCommandType {
            get {
                return ResourceManager.GetString("InvalidCommandType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Propriedade Comando não definida!.
        /// </summary>
        internal static string NullCommand {
            get {
                return ResourceManager.GetString("NullCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Connection String não pode ser nula.
        /// </summary>
        internal static string NullConnectionStringExceptionMessage {
            get {
                return ResourceManager.GetString("NullConnectionStringExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Provedor de Connection String não pode ser nulo.
        /// </summary>
        internal static string NullConnectionsTringProviderExceptionMessage {
            get {
                return ResourceManager.GetString("NullConnectionsTringProviderExceptionMessage", resourceCulture);
            }
        }
    }
}
