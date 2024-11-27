using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Natillera1.Clases
{
    public class clsProgresoAhorro
    {
        private DBSuperEntities db = new DBSuperEntities();
        public ProgresoAhorro progresoAhorro { get; set; }

        public string Insertar()
        {
            try
            {
                db.ProgresoAhorroes.Add(progresoAhorro);
                db.SaveChanges();
                return "Se insertó el progreso de ahorro con ID de ahorro: " + progresoAhorro.ahorroID;
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
                ProgresoAhorro _progreso = Consultar(progresoAhorro.ahorroID);
                if (_progreso != null)
                {
                    db.ProgresoAhorroes.AddOrUpdate(progresoAhorro);
                    db.SaveChanges();
                    return "Se actualizó el progreso de ahorro con ID de ahorro: " + progresoAhorro.ahorroID;
                }
                else
                {
                    return "El progreso de ahorro no existe, por lo tanto no se puede actualizar";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public ProgresoAhorro Consultar(int id)
        {
            return db.ProgresoAhorroes.FirstOrDefault(p => p.ahorroID == id);
        }

        public string Eliminar()
        {
            try
            {
                ProgresoAhorro _progreso = Consultar(progresoAhorro.ahorroID);
                if (_progreso != null)
                {
                    db.ProgresoAhorroes.Remove(_progreso);
                    db.SaveChanges();
                    return "Se eliminó el progreso de ahorro con ID de ahorro: " + _progreso.ahorroID;
                }
                else
                {
                    return "El progreso de ahorro no existe";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IQueryable LlenarTablaProgresoAhorros()
        {
            return from p in db.ProgresoAhorroes
                   join c in db.Clientes on p.clienteID equals c.clienteID
                   orderby p.ahorroID
                   select new
                   {
                       AhorroID = p.ahorroID,
                       Cliente = c.nombre,
                       NumeroPagos = p.numeroPagos,
                       TotalMonto = p.totalMonto
                   };
        }

        public List<ProgresoAhorro> LlenarCombo(int clienteID)
        {
            return db.ProgresoAhorroes
                .Where(p => p.clienteID == clienteID)
                .ToList();
        }
    }
}
