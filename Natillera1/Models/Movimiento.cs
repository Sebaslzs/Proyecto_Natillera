//------------------------------------------------------------------------------ 
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------ 

namespace Natillera1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public partial class Movimiento
    {
        public int movimientoID { get; set; }
        public Nullable<int> clienteID { get; set; }
        public string tipoMovimiento { get; set; }
        public System.DateTime fechaMovimiento { get; set; }
        public decimal monto { get; set; }

        [JsonIgnore] // Esta línea agrega el JsonIgnore
        public virtual Cliente Cliente { get; set; }
    }
}
