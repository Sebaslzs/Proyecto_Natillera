﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Natillera1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NatilleraDBEntities : DbContext
    {
        public NatilleraDBEntities()
            : base("name=NatilleraDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ahorro> Ahorros { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<CuentasBancaria> CuentasBancarias { get; set; }
        public virtual DbSet<Deposito> Depositoes { get; set; }
        public virtual DbSet<EstadoPrestamo> EstadoPrestamoes { get; set; }
        public virtual DbSet<HistorialCambio> HistorialCambios { get; set; }
        public virtual DbSet<Movimiento> Movimientos { get; set; }
        public virtual DbSet<Notificacione> Notificaciones { get; set; }
        public virtual DbSet<PagoPrestamo> PagoPrestamos { get; set; }
        public virtual DbSet<Prestamo> Prestamos { get; set; }
        public virtual DbSet<ProgresoAhorro> ProgresoAhorroes { get; set; }
        public virtual DbSet<ProgresoPrestamo> ProgresoPrestamos { get; set; }
        public virtual DbSet<RolesUsuario> RolesUsuarios { get; set; }
        public virtual DbSet<TasaIntere> TasaInteres { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}
