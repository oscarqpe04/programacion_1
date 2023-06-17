using WebApplicationAPI.Models;

namespace WebApplicationAPI.Repository
{
    public interface IDetalleVentaRepository
    {
        DetalleVentaModel ObtenerPorID(int id);
        List<DetalleVentaModel> ObtenerTodos();
        void Crear(DetalleVentaModel venta);
        void Actualizar(DetalleVentaModel venta);
        void Eliminar(int id);
    }
}
