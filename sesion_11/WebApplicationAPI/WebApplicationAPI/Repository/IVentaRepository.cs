using WebApplicationAPI.Models;

namespace WebApplicationAPI.Repository
{
    public interface IVentaRepository
    {
        VentaModel ObtenerPorID(int id);
        List<VentaModel> ObtenerTodos();
        void CrearVenta(VentaModel venta);
        void ActualizarVenta(VentaModel venta);
        void EliminarVenta(int id);
    }
}
