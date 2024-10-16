using Natillera1.Clases;
using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Http.Cors;
using System.Web.Http;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Depositos")]
    public class DepositosController : ApiController
    {
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
    }
}