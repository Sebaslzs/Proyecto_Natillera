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
    
    public partial class PagoPrestamo
    {
        public int pagoID { get; set; }
        public Nullable<int> prestamoID { get; set; }
        public Nullable<int> clienteID { get; set; }
        public System.DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    
        public virtual Cliente Cliente { get; set; }
        public virtual Prestamo Prestamo { get; set; }
    }
}
