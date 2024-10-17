using Natillera1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;

namespace Natillera1.Clases
{
    public class clsDeposito
    {

        private NatilleraDBEntities db = new NatilleraDBEntities();
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
                return ex.Message;
            }
        }

        public string Actualizar()
        {
            try
            {
                Deposito _deposito = Consultar(deposito.depositoID);
                if (_deposito != null)
                {
                    // El depósito existe y se puede actualizar.
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
                return ex.Message;
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
                Deposito _deposito = Consultar(deposito.depositoID);
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
                return ex.Message;
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