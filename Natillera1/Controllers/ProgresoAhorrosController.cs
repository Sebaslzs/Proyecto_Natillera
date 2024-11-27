using Natillera1.Clases;
using Natillera1.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/ProgresoAhorros")]
    public class ProgresoAhorrosController : ApiController
    {
        [HttpGet]
        [Route("ConsultarXID")]
        public ProgresoAhorro ConsultarXID(int id)
        {
            clsProgresoAhorro progresoAhorro = new clsProgresoAhorro();
            return progresoAhorro.Consultar(id);
        }

        [HttpGet]
        [Route("LlenarTablaProgresoAhorros")]
        public IQueryable LlenarTablaProgresoAhorros()
        {
            clsProgresoAhorro progresoAhorro = new clsProgresoAhorro();
            return progresoAhorro.LlenarTablaProgresoAhorros();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] ProgresoAhorro progresoAhorro)
        {
            clsProgresoAhorro clsProgresoAhorro = new clsProgresoAhorro();
            clsProgresoAhorro.progresoAhorro = progresoAhorro;
            return clsProgresoAhorro.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] ProgresoAhorro progresoAhorro)
        {
            clsProgresoAhorro clsProgresoAhorro = new clsProgresoAhorro();
            clsProgresoAhorro.progresoAhorro = progresoAhorro;
            return clsProgresoAhorro.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] ProgresoAhorro progresoAhorro)
        {
            clsProgresoAhorro clsProgresoAhorro = new clsProgresoAhorro();
            clsProgresoAhorro.progresoAhorro = progresoAhorro;
            return clsProgresoAhorro.Eliminar();
        }
    }
}
