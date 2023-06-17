using WebApplicationAPI.Models;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel ObtenerPorID(int id);
        UsuarioModel ObtenerPorNombreUsuario(string nombre_usuario);
        List<UsuarioModel> ObtenerTodos();
        UsuarioViewModel ObtenerTodosPagination(int pageNumber, int pageSize);
        void Crear(UsuarioModel model);
        void Actualizar(UsuarioModel model);
        void Eliminar(int id);
    }
}
