using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.IO;




namespace Natillera1.Clases
{
    public class clsDeposito
    {
        private readonly DBSuperEntities db = new DBSuperEntities();
        public Deposito deposito { get; set; }

        public string Insertar()
        {
            try
            {
                db.Depositoes.Add(deposito);
                db.SaveChanges();
                return $"Se insertó el depósito con ID: {deposito.depositoID}";
            }
            catch (Exception ex)
            {
                return $"Error al insertar el depósito: {ex.Message}";
            }
        }

        public string Actualizar()
        {
            try
            {
                var _deposito = Consultar(deposito.depositoID);
                if (_deposito != null)
                {
                    db.Depositoes.AddOrUpdate(deposito);
                    db.SaveChanges();
                    return $"Se actualizó el depósito con ID: {deposito.depositoID}";
                }
                else
                {
                    return "El depósito no existe, por lo tanto no se puede actualizar.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el depósito: {ex.Message}";
            }
        }

        public Deposito Consultar(int depositoID)
        {
            return db.Depositoes.FirstOrDefault(d => d.depositoID == depositoID);
        }

        public string Eliminar()
        {
            try
            {
                var _deposito = Consultar(deposito.depositoID);
                if (_deposito != null)
                {
                    db.Depositoes.Remove(_deposito);
                    db.SaveChanges();
                    return $"Se eliminó el depósito con ID: {deposito.depositoID}";
                }
                else
                {
                    return "El depósito no existe.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el depósito: {ex.Message}";
            }
        }

        public IQueryable LlenarTablaDepositos()
        {
            return from d in db.Depositoes
                   join c in db.Clientes on d.clienteID equals c.clienteID into clienteJoin
                   from cj in clienteJoin.DefaultIfEmpty()
                   join a in db.Ahorros on d.ahorroID equals a.ahorroID into ahorroJoin
                   from aj in ahorroJoin.DefaultIfEmpty()
                   orderby d.fecha descending
                   select new
                   {
                       d.depositoID,
                       d.monto,
                       d.fecha,
                       Cliente = cj != null ? cj.nombre : "N/A",
                       AhorroID = aj != null ? aj.ahorroID : (int?)null
                   };
        }
    }
}
