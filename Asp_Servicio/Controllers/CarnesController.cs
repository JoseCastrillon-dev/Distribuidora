using LibDominio.entidades;
using LibAplicacion.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Asp_Servicio.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CarnesController : ControllerBase
    {
        private ICarnesAplicacion ICarnesAplicacion;

        public CarnesController(ICarnesAplicacion ICarnesAplicacion)
        {
            this.ICarnesAplicacion = ICarnesAplicacion;
        }

        [HttpPost]
        public List<Carnes> Consultar()
        {
            return this.ICarnesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Carnes> Buscar(Carnes entidad)
        {
            return this.ICarnesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Carnes Insertar(Carnes entidad)
        {
            return this.ICarnesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Carnes Actualizar(Carnes entidad)
        {
            return this.ICarnesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Carnes Borrar(Carnes entidad)
        {
            return this.ICarnesAplicacion.Borrar(entidad);
        }
    }
}
