using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;

namespace Natillera1.Clases
{
    public class clsAhorro
    {
        private NatilleraDBEntities db = new NatilleraDBEntities();
        public Ahorro ahorro { get; set; }

        public string Insertar()
        {
            try
            {
                db.Ahorros.Add(ahorro);
                db.SaveChanges();
                return "Se insertó el ahorro con ID: " + ahorro.ahorroID;
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
                Ahorro _ahorro = Consultar(ahorro.ahorroID);
                if (_ahorro != null)
                {
                    // El ahorro existe, y se puede actualizar
                    db.Ahorros.AddOrUpdate(ahorro);
                    db.SaveChanges();
                    return "Se actualizó el ahorro con ID: " + ahorro.ahorroID;
                }
                else
                {
                    return "El ahorro no existe, por lo tanto no se puede actualizar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Ahorro Consultar(int id)
        {
            return db.Ahorros.FirstOrDefault(a => a.ahorroID == id);
        }

        public string Eliminar()
        {
            try
            {
                Ahorro _ahorro = Consultar(ahorro.ahorroID);
                if (_ahorro != null)
                {
                    db.Ahorros.Remove(_ahorro);
                    db.SaveChanges();
                    return "Se eliminó el ahorro con ID: " + _ahorro.ahorroID;
                }
                else
                {
                    return "El ahorro no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaAhorros()
        {
            return from a in db.Ahorros
                   join c in db.Clientes on a.clienteID equals c.clienteID
                   orderby a.fechaInicial
                   select new
                   {
                       AhorroID = a.ahorroID,
                       Cliente = c.nombre,
                       MontoMensual = a.montoMensual,
                       FechaInicial = a.fechaInicial
                   };
        }
    }
}