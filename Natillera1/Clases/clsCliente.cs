using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> b75059d0e021cfb3f75381ac1de5be2ca23a7722

namespace Natillera1.Clases
{
    public class clsCliente
    {
        private DBSuperEntities db = new DBSuperEntities();
        public Cliente cliente { get; set; }

        // Método para llenar el combo de clientes
        public List<Cliente> LlenarCombo()
        {
            return db.Clientes
                .OrderBy(c => c.nombre)
                .ToList();
        }

        // Método para insertar un cliente
        public string Insertar()
        {
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return "Cliente insertado correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al insertar el cliente: {ex.Message}";
            }
        }

        // Método para actualizar un cliente
        public string Actualizar()
        {
            try
            {
                var clienteExistente = db.Clientes.Find(cliente.clienteID);
                if (clienteExistente != null)
                {
                    clienteExistente.nombre = cliente.nombre;
                    clienteExistente.direccion = cliente.direccion;
                    clienteExistente.telefono = cliente.telefono;
                    db.SaveChanges();
                    return "Cliente actualizado correctamente.";
                }
                return "Cliente no encontrado.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el cliente: {ex.Message}";
            }

        // Método para consultar un cliente por su ID
        public Cliente Consultar(int id)
        {
            return db.Clientes.FirstOrDefault(c => c.clienteID == id);
        }

        // Método para eliminar un cliente
        public string Eliminar()
        {
            try
            {
                var clienteExistente = db.Clientes.Find(cliente.clienteID);
                if (clienteExistente != null)
                {
                    db.Clientes.Remove(clienteExistente);
                    db.SaveChanges();
                    return "Cliente eliminado correctamente.";
                }
                return "Cliente no encontrado.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el cliente: {ex.Message}";
            }
        }

        // Método para llenar la tabla de clientes
        public IQueryable LlenarTablaClientes()
        {
            return from c in db.Clientes
                   orderby c.nombre
                   select new
                   {
                       ClienteID = c.clienteID,
                       Nombre = c.nombre,
                       Apellido =c.apellido,
                       Identificacion = c.identificacion,
                       Direccion = c.direccion,
                       Telefono = c.telefono
                   };
        }
    }
}
=======
    }
}
>>>>>>> b75059d0e021cfb3f75381ac1de5be2ca23a7722
