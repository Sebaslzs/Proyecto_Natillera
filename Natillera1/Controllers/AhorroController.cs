using Natillera1.Clases;
using Natillera1.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:55005", headers: "*", methods: "*")]
    [RoutePrefix("api/Ahorros")]
    public class AhorrosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXID")]
        public Ahorro ConsultarXID(int id)
        {
            clsAhorro ahorro = new clsAhorro();
            return ahorro.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTablaAhorros")]
        public IQueryable LlenarTablaAhorros()
        {
            clsAhorro ahorro = new clsAhorro();
            return ahorro.LlenarTablaAhorros();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Ahorro ahorro)
        {
            clsAhorro clsAhorro = new clsAhorro();
            clsAhorro.ahorro = ahorro;
            return clsAhorro.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Ahorro ahorro)
        {
            clsAhorro clsAhorro = new clsAhorro();
            clsAhorro.ahorro = ahorro;
            return clsAhorro.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Ahorro ahorro)
        {
            clsAhorro clsAhorro = new clsAhorro();
            clsAhorro.ahorro = ahorro;
            return clsAhorro.Eliminar();
        }
    }
}
