using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDBContext applicationDBContext;
        public UsuarioRepository(ApplicationDBContext applicationDBContext)
        {
            this.applicationDBContext = applicationDBContext;
        }

        public void Actualizar(UsuarioModel model)
        {
            applicationDBContext.Entry(model).State = EntityState.Modified;
            applicationDBContext.SaveChanges();
        }

        public void Crear(UsuarioModel model)
        {
            applicationDBContext.usuariosCollection.Add(model);
            applicationDBContext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var model = applicationDBContext.usuariosCollection.Find(id);
            if (model != null)
            {
                applicationDBContext.usuariosCollection.Remove(model);
            }
            applicationDBContext.SaveChangesAsync();
        }

        public UsuarioModel ObtenerPorID(int id)
        {
            return applicationDBContext.usuariosCollection.Find(id);
        }
        public UsuarioModel ObtenerPorNombreUsuario(string nombre_usuario)
        {
            var user = applicationDBContext.usuariosCollection.Include(a => a.usuarioRoles).FirstOrDefault(u => u.usuario == nombre_usuario);
            return user;
        }

        public List<UsuarioModel> ObtenerTodos()
        {
            return applicationDBContext.usuariosCollection.ToList();
        }
        public UsuarioViewModel ObtenerTodosPagination(int pageNumber, int pageSize)
        {
            var totalItems = applicationDBContext.usuariosCollection.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
            var currentPageList = applicationDBContext.usuariosCollection.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var viewModel = new UsuarioViewModel
            {
                usuarios = currentPageList,
                pagination = new PaginationInfo
                {
                    currentPage = pageNumber,
                    totalItems = totalItems,
                    totalPages = totalPages,
                    pageSize = pageSize
                }
            };
            return viewModel;
        }
    }
}
