using Natillera1.Clases;
using Natillera1.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/Multas")]
    public class MultasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXID")]
        public Multa ConsultarXID(int id)
        {
            clsMulta multa = new clsMulta();
            return multa.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTablaMultas")]
        public IQueryable LlenarTablaMultas()
        {
            clsMulta multa = new clsMulta();
            return multa.LlenarTablaMultas();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa;
            return clsMulta.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa;
            return clsMulta.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa;
            return clsMulta.Eliminar();
        }
    }
}
