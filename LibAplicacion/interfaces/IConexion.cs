using LibDominio.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LibAplicacion.interfaces
{
    public interface IConexion
    {
        DbSet<Carnes>? Carnes { get; set; }
        DbSet<Auditoria>? Auditoria { get; set; }
        DbSet<Tipos>? Tipos { get; set; }


        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
