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
    using System.Text.Json.Serialization; // Asegúrate de incluir esto para JsonIgnore

    public partial class DetalleLiquidacion
    {
        public int detalleID { get; set; }
        public Nullable<int> liquidacionID { get; set; }
        public string descripcion { get; set; }
        public decimal monto { get; set; }

        [JsonIgnore] // Ignora esta propiedad en la serialización JSON
        public virtual Liquidacione Liquidacione { get; set; }
    }
}
