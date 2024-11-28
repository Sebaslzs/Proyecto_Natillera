using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Natillera1.Clases
{
    public class clsCliente
    {
        private readonly DBSuperEntities db = new DBSuperEntities();
        public Cliente cliente { get; set; }

        // Método para insertar un cliente
        public string Insertar()
        {
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return $"Cliente insertado correctamente con ID: {cliente.clienteID}";
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
                var clienteExistente = Consultar(cliente.clienteID);
                if (clienteExistente != null)
                {
                    clienteExistente.nombre = cliente.nombre;
                    clienteExistente.direccion = cliente.direccion;
                    clienteExistente.telefono = cliente.telefono;
                    db.SaveChanges();
                    return $"Cliente con ID {cliente.clienteID} actualizado correctamente.";
                }
                else
                {
                    return "El cliente no existe, por lo tanto no se puede actualizar.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el cliente: {ex.Message}";
            }
        }

        // Método para consultar un cliente por ID
        public Cliente Consultar(int clienteID)
        {
            return db.Clientes.FirstOrDefault(c => c.clienteID == clienteID);
        }

        // Método para eliminar un cliente
        public string Eliminar()
        {
            try
            {
                var clienteExistente = Consultar(cliente.clienteID);
                if (clienteExistente != null)
                {
                    db.Clientes.Remove(clienteExistente);
                    db.SaveChanges();
                    return $"Cliente con ID {cliente.clienteID} eliminado correctamente.";
                }
                else
                {
                    return "El cliente no existe.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el cliente: {ex.Message}";
            }
        }

        // Método para llenar el combo de clientes
        public List<Cliente> LlenarCombo()
        {
            return db.Clientes
                .OrderBy(c => c.nombre)
                .ToList();
        }

        // Método para llenar la tabla de clientes
        public IQueryable LlenarTablaClientes()
        {
            return from c in db.Clientes
                   orderby c.nombre
                   select new
                   {
                       c.clienteID,
                       c.nombre,
                       c.apellido,
                       c.identificacion,
                       c.direccion,
                       c.telefono
                   };
        }
    }
}
