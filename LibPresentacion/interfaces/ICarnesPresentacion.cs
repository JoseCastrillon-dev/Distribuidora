using LibDominio.entidades;

namespace LibPresentacion.interfaces
{
    public interface ICarnesPresentacion
    {
        Carnes Insertar(Carnes entidad);
        Carnes Actualizar(Carnes entidad);
        List<Carnes> Consultar();
        List<Carnes> Buscar(Carnes entidad);
        Carnes Borrar(Carnes entidad);
    }
}