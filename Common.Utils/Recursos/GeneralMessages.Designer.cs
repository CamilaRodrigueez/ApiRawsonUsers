﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Utils.Recursos {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class GeneralMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GeneralMessages() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Common.Utils.Recursos.GeneralMessages", typeof(GeneralMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
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
        ///   Busca una cadena traducida similar a Ya existe un usuario con esta identificacion: {0}.
        /// </summary>
        public static string ExistUserIdentificacion {
            get {
                return ResourceManager.GetString("ExistUserIdentificacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro Exitoso!.
        /// </summary>
        public static string ItemInsert {
            get {
                return ResourceManager.GetString("ItemInsert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Registro de Contacto exitoso!.
        /// </summary>
        public static string ItemInsertContactoPersona {
            get {
                return ResourceManager.GetString("ItemInsertContactoPersona", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a Señor usuario ya tiene un contacto registrado con este Id de TipoContacto: {0} , Por favor intente con otro tipo de contacto que no haya agregado.
        /// </summary>
        public static string ItemNoInsertContactoPersona {
            get {
                return ResourceManager.GetString("ItemNoInsertContactoPersona", resourceCulture);
            }
        }
    }
}
