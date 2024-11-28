using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Natillera1.Clases
{
    public class clsMulta
    {
        private DBSuperEntities db = new DBSuperEntities();
        public Multa multa { get; set; }

        // Método para insertar una multa
        public string Insertar()
        {
            try
            {
                db.Multas.Add(multa); // Se agrega la multa a la base de datos
                db.SaveChanges(); // Guardamos los cambios
                return "Se insertó la multa con ID: " + multa.multaID; // Mensaje de éxito
            }
            catch (Exception ex)
            {
                return ex.Message; // En caso de error, se devuelve el mensaje de la excepción
            }
        }

        // Método para actualizar una multa
        public string Actualizar()
        {
            try
            {
                // Consultamos si la multa existe
                Multa _multa = Consultar(multa.multaID);
                if (_multa != null)
                {
                    db.Multas.AddOrUpdate(multa); // Si existe, se actualiza
                    db.SaveChanges(); // Guardamos los cambios
                    return "Se actualizó la multa con ID: " + multa.multaID;
                }
                else
                {
                    return "La multa no existe, por lo tanto no se puede actualizar"; // Si no existe, mensaje de error
                }
            }
            catch (Exception ex)
            {
                return ex.Message; // En caso de error, se devuelve el mensaje de la excepción
            }
        }

        // Método para consultar una multa por ID
        public Multa Consultar(int id)
        {
            return db.Multas.FirstOrDefault(m => m.multaID == id); // Retorna la primera multa que coincida con el ID
        }

        // Método para eliminar una multa
        public string Eliminar()
        {
            try
            {
                // Consultamos si la multa existe
                Multa _multa = Consultar(multa.multaID);
                if (_multa != null)
                {
                    db.Multas.Remove(_multa); // Si existe, se elimina
                    db.SaveChanges(); // Guardamos los cambios
                    return "Se eliminó la multa con ID: " + _multa.multaID;
                }
                else
                {
                    return "La multa no existe"; // Si no existe, mensaje de error
                }
            }
            catch (Exception ex)
            {
                return ex.Message; // En caso de error, se devuelve el mensaje de la excepción
            }
        }

        // Método para llenar la tabla de multas
        public IQueryable LlenarTablaMultas()
        {
            return from m in db.Multas
                   join c in db.Clientes on m.clienteID equals c.clienteID
                   orderby m.fecha
                   select new
                   {
                       MultaID = m.multaID,
                       Cliente = c.nombre,
                       Descripcion = m.descripcion,
                       Monto = m.monto,
                       Fecha = m.fecha
                   };
        }

        // Método para llenar un combo de multas según un cliente específico
        public List<Multa> LlenarCombo(int clienteID)
        {
            return db.Multas
                .Where(m => m.clienteID == clienteID) // Filtramos las multas por clienteID
                .ToList();
        }
        public string PagarMulta(int multaID, decimal montoPago)
        {
            try
            {
                // Consultamos la multa por ID
                Multa _multa = Consultar(multaID);

                if (_multa != null)
                {
                    // Validamos que el monto de la multa sea suficiente
                    if (_multa.monto >= montoPago)
                    {
                        _multa.monto -= montoPago; // Restamos el pago al monto de la multa
                        db.SaveChanges(); // Guardamos los cambios en la base de datos
                        return $"El pago de {montoPago:C} fue aplicado. Monto restante: {_multa.monto:C}.";
                    }
                    else
                    {
                        return "El monto del pago excede el saldo de la multa.";
                    }
                }
                else
                {
                    return "La multa no existe.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message; // Retorna el mensaje de error si ocurre una excepción
            }
        }

    }
}
