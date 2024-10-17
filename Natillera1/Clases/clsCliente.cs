<<<<<<< HEAD
﻿using Natillera1.Models;
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
<<<<<<< HEAD
        private NatilleraDBEntities db = new NatilleraDBEntities();
        public Cliente cliente { get; set; }

        // Método para insertar un cliente
        public string Insertar()
        {
            try
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return "Se insertó el cliente con ID: " + cliente.clienteID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Método para actualizar un cliente existente
        public string Actualizar()
        {
            try
            {
                Cliente _cliente = Consultar(cliente.clienteID);
                if (_cliente != null)
                {
                    db.Clientes.AddOrUpdate(cliente);
                    db.SaveChanges();
                    return "Se actualizó el cliente con ID: " + cliente.clienteID;
                }
                else
                {
                    return "El cliente no existe, por lo tanto no se puede actualizar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
                Cliente _cliente = Consultar(cliente.clienteID);
                if (_cliente != null)
                {
                    db.Clientes.Remove(_cliente);
                    db.SaveChanges();
                    return "Se eliminó el cliente con ID: " + _cliente.clienteID;
                }
                else
                {
                    return "El cliente no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
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
                       Apellido = c.apellido,
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
