using WebApplicationAPI.Models;

namespace WebApplicationAPI.ViewModels
{
    public class UsuarioViewModel
    {
        public List<UsuarioModel> usuarios { get; set; }
        public PaginationInfo pagination { get; set; }
    }
}
