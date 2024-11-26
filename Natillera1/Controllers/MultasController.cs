using Natillera1.Clases;
using Natillera1.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Linq;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/Multas")]
    public class MultasController : ApiController
    {
        [HttpGet]
        [Route("LlenarCombo")]
        public IEnumerable<Multa> LlenarComboMultas()
        {
            clsMulta multa = new clsMulta();
            return multa.LlenarCombo();
        }

        [HttpGet]
        [Route("LlenarTablaMultas")]
        public IQueryable<Multa> LlenarTablaMultas()
        {
            clsMulta multa = new clsMulta();
            return multa.LlenarCombo().AsQueryable();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Multa multa)
        {
            clsMulta multaClase = new clsMulta();
            multaClase.multa = multa;
            return multaClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Multa multa)
        {
            clsMulta multaClase = new clsMulta();
            multaClase.multa = multa;
            return multaClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Multa multa)
        {
            clsMulta multaClase = new clsMulta();
            multaClase.multa = multa;
            return multaClase.Eliminar();
        }
    }
}
