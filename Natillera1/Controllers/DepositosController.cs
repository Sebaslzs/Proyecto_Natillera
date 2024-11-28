using Natillera1.Clases;
using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http.Cors;
using System.Web.Http;
using System.Net;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/Depositos")]
    public class DepositosController : ApiController
    {
        private readonly ProcesoRealizarDeposito proceso = new ProcesoRealizarDeposito();

        [HttpGet]
        [Route("ConsultarXCodigo")]
        public Deposito ConsultarXCodigo(int depositoID)
        {
            clsDeposito deposito = new clsDeposito();
            return deposito.Consultar(depositoID);
        }

        [HttpGet]
        [Route("LlenarTablaDepositos")]
        public IQueryable LlenarTablaDepositos()
        {
            clsDeposito deposito = new clsDeposito();
            return deposito.LlenarTablaDepositos();
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Deposito deposito)
        {
            clsDeposito depositoClase = new clsDeposito();
            depositoClase.deposito = deposito;
            return depositoClase.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Deposito deposito)
        {
            clsDeposito depositoClase = new clsDeposito();
            depositoClase.deposito = deposito;
            return depositoClase.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Deposito deposito)
        {
            clsDeposito depositoClase = new clsDeposito();
            depositoClase.deposito = deposito;
            return depositoClase.Eliminar();
        }

        [HttpPost]
        [Route("Realizar")]
        public IHttpActionResult RealizarDeposito([FromBody] DepositoRequest request)
        {
            if (request == null)
                return Content(HttpStatusCode.BadRequest, "La información enviada no es válida.");

            ProcesoRealizarDeposito proceso = new ProcesoRealizarDeposito();
            string resultado;

            try
            {
                resultado = proceso.RealizarDeposito(request.ClienteID, request.AhorroID, request.Monto, request.FechaDeposito);
                return Ok(new { mensaje = resultado });
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }
    }

    public class DepositoRequest
    {
        public int ClienteID { get; set; }
        public int AhorroID { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaDeposito { get; set; }
    }
}