using WebApplicationAPI.Models;

namespace WebApplicationAPI.Repository
{
    public interface IProductoRepository
    {
        ProductoModel ObtenerPorID(int id);
        List<ProductoModel> ObtenerTodos();
        void Crear(ProductoModel venta);
        void Actualizar(ProductoModel venta);
        void Eliminar(int id);
        bool EstaDisponible(int id);
    }
}
