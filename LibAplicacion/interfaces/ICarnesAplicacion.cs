using LibDominio.entidades;

namespace LibAplicacion.interfaces
{
    public interface ICarnesAplicacion
    {
        Carnes Insertar(Carnes entidad);
        Carnes Actualizar(Carnes entidad);
        List<Carnes> Consultar();
        List<Carnes> Buscar(Carnes entidad);
        Carnes Borrar(Carnes entidad);
    }
}