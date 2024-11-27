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

        public string Insertar()
        {
            try
            {
                db.Multas.Add(multa);
                db.SaveChanges();
                return "Se insertó la multa con ID: " + multa.multaID;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Multa _multa = Consultar(multa.multaID);
                if (_multa != null)
                {
                    db.Multas.AddOrUpdate(multa);
                    db.SaveChanges();
                    return "Se actualizó la multa con ID: " + multa.multaID;
                }
                else
                {
                    return "La multa no existe, por lo tanto no se puede actualizar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Multa Consultar(int id)
        {
            return db.Multas.FirstOrDefault(m => m.multaID == id);
        }

        public string Eliminar()
        {
            try
            {
                Multa _multa = Consultar(multa.multaID);
                if (_multa != null)
                {
                    db.Multas.Remove(_multa);
                    db.SaveChanges();
                    return "Se eliminó la multa con ID: " + _multa.multaID;
                }
                else
                {
                    return "La multa no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

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

        public List<Multa> LlenarCombo(int clienteID)
        {
            return db.Multas
                .Where(m => m.clienteID == clienteID)
                .ToList();
        }
    }
}
