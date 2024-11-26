using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Natillera1.Clases
{
    public class clsMulta
    {
        private DBSuperEntities db = new DBSuperEntities();
        public Multa multa { get; set; }

        // Método para llenar el combo de multas
        public List<Multa> LlenarCombo()
        {
            return db.Multas
                .OrderBy(m => m.descripcion)
                .ToList();
        }

        // Método para insertar una multa
        public string Insertar()
        {
            try
            {
                db.Multas.Add(multa);
                db.SaveChanges();
                return "Multa insertada correctamente.";
            }
            catch (Exception ex)
            {
                return $"Error al insertar la multa: {ex.Message}";
            }
        }

        // Método para actualizar una multa
        public string Actualizar()
        {
            try
            {
                var multaExistente = db.Multas.Find(multa.multaID);
                if (multaExistente != null)
                {
                    multaExistente.clienteID = multa.clienteID;
                    multaExistente.descripcion = multa.descripcion;
                    multaExistente.monto = multa.monto;
                    multaExistente.fecha = multa.fecha;
                    db.SaveChanges();
                    return "Multa actualizada correctamente.";
                }
                return "Multa no encontrada.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar la multa: {ex.Message}";
            }
        }

        // Método para eliminar una multa
        public string Eliminar()
        {
            try
            {
                var multaExistente = db.Multas.Find(multa.multaID);
                if (multaExistente != null)
                {
                    db.Multas.Remove(multaExistente);
                    db.SaveChanges();
                    return "Multa eliminada correctamente.";
                }
                return "Multa no encontrada.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la multa: {ex.Message}";
            }
        }

        // Método para llenar la tabla de multas
        public IQueryable LlenarTablaMultas()
        {
            return from m in db.Multas
                   orderby m.descripcion
                   select new
                   {
                       MultaID = m.multaID,
                       ClienteID = m.clienteID,
                       Descripcion = m.descripcion,
                       Monto = m.monto,
                       Fecha = m.fecha
                   };
        }
    }
}
