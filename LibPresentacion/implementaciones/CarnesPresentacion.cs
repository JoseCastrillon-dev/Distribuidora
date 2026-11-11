using LibDominio.entidades;
using LibPresentacion.interfaces;

namespace LibPresentacion.interfaces
{
    public class CarnesPresentacion : ICarnesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CarnesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Carnes Actualizar(Carnes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Carnes>(
                "Carnes/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Carnes Borrar(Carnes entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Carnes>(
                "Carnes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Carnes> Buscar(Carnes entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Carnes>>(
                "Carnes/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Carnes> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Carnes>>(
                "Carnes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Carnes Insertar(Carnes entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Carnes>(
                "Carnes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Carnes entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                   string.IsNullOrEmpty(entidad.Nombre);
        }
    }
}