using Natillera1.Clases;
using Natillera1.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera1.Controllers
{
    // Permite habilitar CORS para este controlador, configurando los orígenes, encabezados y métodos permitidos
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/Multas")]
    public class MultasController : ApiController
    {
        // Método para consultar una multa por su ID
        [HttpGet]
        [Route("ConsultarXID")]
        public Multa ConsultarXID(int id)
        {
            clsMulta clsMulta = new clsMulta();
            return clsMulta.Consultar(id); // Llama al método Consultar de la clase clsMulta
        }

        // Método para llenar la tabla de multas
        [HttpGet]
        [Route("LlenarTablaMultas")]
        public IQueryable LlenarTablaMultas()
        {
            clsMulta clsMulta = new clsMulta();
            return clsMulta.LlenarTablaMultas(); // Llama al método LlenarTablaMultas de la clase clsMulta
        }

        // Método para insertar una nueva multa
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa; // Asigna la multa al objeto clsMulta
            return clsMulta.Insertar(); // Llama al método Insertar de la clase clsMulta
        }

        // Método para actualizar una multa existente
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa; // Asigna la multa al objeto clsMulta
            return clsMulta.Actualizar(); // Llama al método Actualizar de la clase clsMulta
        }

        // Método para eliminar una multa
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Multa multa)
        {
            clsMulta clsMulta = new clsMulta();
            clsMulta.multa = multa; // Asigna la multa al objeto clsMulta
            return clsMulta.Eliminar(); // Llama al método Eliminar de la clase clsMulta
        }
        [HttpPost]
        [Route("PagarMulta")]
        public string PagarMulta(int multaID, decimal montoPago)
        {
            clsMulta clsMulta = new clsMulta();
            return clsMulta.PagarMulta(multaID, montoPago); // Llama al método PagarMulta de clsMulta
        }
    }
}
