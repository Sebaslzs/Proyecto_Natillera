using Natillera1.Models;
using System;

namespace Natillera1.Clases
{
    public class ProcesoRealizarDeposito
    {
        private readonly clsDeposito clsDeposito = new clsDeposito();
        private readonly clsMulta clsMulta = new clsMulta();
        private readonly clsAhorro clsAhorro = new clsAhorro();
        private readonly clsProgresoAhorro clsProgreso = new clsProgresoAhorro();

        public string RealizarDeposito(int clienteID, int ahorroID, decimal monto, DateTime fechaDeposito)
        {
            using (var db = new DBSuperEntities())
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    string mensaje = "Depósito registrado correctamente.";

                    // Registrar el depósito
                    clsDeposito.deposito = new Deposito
                    {
                        clienteID = clienteID,
                        ahorroID = ahorroID,
                        monto = monto,
                        fecha = fechaDeposito
                    };
                    string resultadoDeposito = clsDeposito.Insertar();
                    if (!resultadoDeposito.StartsWith("Se insertó"))
                        throw new Exception(resultadoDeposito);

                    // Validar el ahorro
                    clsAhorro.ahorro = clsAhorro.Consultar(ahorroID);
                    if (clsAhorro.ahorro == null)
                        throw new Exception("El ahorro especificado no existe.");

                    // Verificar multas por depósito fuera de fecha
                    DateTime fechaLimite = new DateTime(fechaDeposito.Year, fechaDeposito.Month, 5);
                    if (fechaDeposito > fechaLimite)
                    {
                        int diasRetraso = (fechaDeposito - fechaLimite).Days;
                        decimal montoMulta = clsAhorro.ahorro.montoMensual * 0.04m * diasRetraso;

                        clsMulta.multa = new Multa
                        {
                            clienteID = clienteID,
                            descripcion = $"Depósito fuera de fecha, {diasRetraso} días de retraso.",
                            monto = montoMulta,
                            fecha = fechaDeposito
                        };
                        string resultadoMulta = clsMulta.Insertar();
                        if (!resultadoMulta.StartsWith("Se insertó"))
                            throw new Exception(resultadoMulta);

                        mensaje += $"\nMulta registrada: Depósito fuera de fecha ({diasRetraso} días). Monto: {montoMulta:C}.";
                    }

                    // Verificar multas por monto insuficiente
                    if (monto < clsAhorro.ahorro.montoMensual)
                    {
                        decimal montoMulta = clsAhorro.ahorro.montoMensual * 0.20m;

                        clsMulta.multa = new Multa
                        {
                            clienteID = clienteID,
                            descripcion = "Depósito incompleto. El monto es menor al requerido.",
                            monto = montoMulta,
                            fecha = fechaDeposito
                        };
                        string resultadoMulta = clsMulta.Insertar();
                        if (!resultadoMulta.StartsWith("Se insertó"))
                            throw new Exception(resultadoMulta);

                        mensaje += $"\nMulta registrada: Monto insuficiente. Monto: {montoMulta:C}.";
                    }

                    // Actualizar progreso del ahorro
                    clsProgreso.progresoAhorro = clsProgreso.Consultar(ahorroID);
                    if (clsProgreso.progresoAhorro != null)
                    {
                        clsProgreso.progresoAhorro.totalMonto += monto;
                        clsProgreso.progresoAhorro.numeroPagos += 1;
                        string resultadoProgreso = clsProgreso.Actualizar();
                        if (!resultadoProgreso.StartsWith("Se actualizó"))
                            throw new Exception(resultadoProgreso);
                    }
                    else
                    {
                        clsProgreso.progresoAhorro = new ProgresoAhorro
                        {
                            clienteID = clienteID,
                            ahorroID = ahorroID,
                            totalMonto = monto,
                            numeroPagos = 1
                        };
                        string resultadoProgreso = clsProgreso.Insertar();
                        if (!resultadoProgreso.StartsWith("Se insertó"))
                            throw new Exception(resultadoProgreso);
                    }

                    transaction.Commit();
                    return mensaje;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return $"Error al realizar el depósito: {ex.Message}";
                }
            }
        }
    }
}
