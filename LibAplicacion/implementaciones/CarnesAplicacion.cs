using LibAplicacion.interfaces;
using LibDominio.entidades;
using Microsoft.EntityFrameworkCore;

namespace LibAplicacion.interfaces
{
    public class CarnesAplicacion : ICarnesAplicacion
    {
        private IConexion IConexion;
        private Auditoria Auditoria;

        public CarnesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Carnes Actualizar(Carnes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            else
            {
                var entry = this.IConexion!.Entry<Carnes>(entidad);
                entry.State = EntityState.Modified;

                Auditoria = new Auditoria
                {
                    Descripcion = "Se Actualizo" + entidad.Codigo,
                    Fecha = DateTime.Now
                };
                this.IConexion.Auditoria!.Add(Auditoria!);


                this.IConexion!.SaveChanges();
            }
            return entidad;


        }

        public Carnes Borrar(Carnes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");


            Auditoria = new Auditoria
            {
                Descripcion = "Se Borro " + entidad.Codigo,
                Fecha = DateTime.Now
            };
            this.IConexion.Auditoria!.Add(Auditoria!);


            this.IConexion.Carnes!.Remove(entidad!);

            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Carnes> Buscar(Carnes entidad)
        {
            return this.IConexion.Carnes!
                .Include(x => x._tipo)
                .Where(x => x.Codigo!.Contains(entidad.Codigo!) ||
                            x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Carnes> Consultar()
        {
            return this.IConexion.Carnes!.ToList();
        }

        public Carnes Insertar(Carnes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            

            this.IConexion.Carnes!.Add(entidad!);


            Auditoria = new Auditoria
            {
                Descripcion = "Se Agrego " + entidad.Codigo,
                Fecha = DateTime.Now
            };
            this.IConexion.Auditoria!.Add(Auditoria!);


            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Carnes entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                   string.IsNullOrEmpty(entidad.Nombre);
        }
    }
}