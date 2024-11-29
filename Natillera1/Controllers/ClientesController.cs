using Natillera1.Clases;
using Natillera1.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Linq;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:56174", headers: "*", methods: "*")]
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        // Método para llenar el combo de clientes
        [HttpGet]
        [Route("LlenarCombo")]
        public IEnumerable<Cliente> LlenarComboClientes()
        {
            clsCliente cliente = new clsCliente();
            return cliente.LlenarCombo();
        }

        // Método para obtener todos los clientes (llenar tabla)
        [HttpGet]
        [Route("LlenarTablaClientes")]
        public IQueryable<Cliente> LlenarTablaClientes()
        {
            clsCliente cliente = new clsCliente();
            return cliente.LlenarCombo().AsQueryable();
        }

        // Método para insertar un cliente
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            clsCliente clienteClase = new clsCliente();
            clienteClase.cliente = cliente;
            return clienteClase.Insertar();
        }

        // Método para actualizar un cliente
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente cliente)
        {
            clsCliente clienteClase = new clsCliente();
            clienteClase.cliente = cliente;
            return clienteClase.Actualizar();
        }

        // Método para eliminar un cliente
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cliente cliente)
        {
            clsCliente clienteClase = new clsCliente();
            clienteClase.cliente = cliente;
            return clienteClase.Eliminar();
        }
    }
}
