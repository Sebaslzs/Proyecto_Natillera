<<<<<<< HEAD
﻿using Natillera1.Clases;
using Natillera1.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Natillera1.Controllers
{
    [EnableCors(origins: "http://localhost:55005", headers: "*", methods: "*")]
    [RoutePrefix("api/Clientes")]
    public class ClientesController : ApiController
    {
        // Consultar cliente por ID
        [HttpGet]
        [Route("ConsultarXID")]
        public Cliente ConsultarXID(int id)
        {
            clsCliente cliente = new clsCliente();
            return cliente.Consultar(id);
        }

        // Llenar la tabla de clientes
        [HttpGet]
        [Route("LlenarTablaClientes")]
        public IQueryable LlenarTablaClientes()
        {
            clsCliente cliente = new clsCliente();
            return cliente.LlenarTablaClientes();
        }

        // Insertar un nuevo cliente
        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Cliente cliente)
        {
            clsCliente clsCliente = new clsCliente();
            clsCliente.cliente = cliente;
            return clsCliente.Insertar();
        }

        // Actualizar un cliente existente
        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Cliente cliente)
        {
            clsCliente clsCliente = new clsCliente();
            clsCliente.cliente = cliente;
            return clsCliente.Actualizar();
        }

        // Eliminar un cliente
        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Cliente cliente)
        {
            clsCliente clsCliente = new clsCliente();
            clsCliente.cliente = cliente;
            return clsCliente.Eliminar();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Natillera1.Controllers
{
    public class ClienteController
    {
    }
}
>>>>>>> b75059d0e021cfb3f75381ac1de5be2ca23a7722
