//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Natillera1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;


    public partial class Deposito
    {
        public int depositoID { get; set; }
        public Nullable<int> ahorroID { get; set; }
        public Nullable<int> clienteID { get; set; }
        public decimal monto { get; set; }
        public System.DateTime fecha { get; set; }

        [JsonIgnore]
        public virtual Ahorro Ahorro { get; set; }
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }
    }
}