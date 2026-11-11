using LibDominio.entidades;
using LibAplicacion.interfaces;
using LibAplicacion.nucleo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LibAplicacion.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Carnes>? Carnes { get; set; }
        public DbSet<Auditoria>? Auditoria { get; set; }
        public DbSet<Tipos>? Tipos { get; set; }

    }
}
