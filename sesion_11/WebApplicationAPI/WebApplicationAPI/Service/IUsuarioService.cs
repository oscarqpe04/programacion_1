using WebApplicationAPI.Models;

namespace WebApplicationAPI.Service
{
    public interface IUsuarioService
    {
        bool RegistrarUsuario(UsuarioModel model, List<RolModel> roles);
    }
}
