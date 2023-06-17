using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;

namespace WebApplicationAPI.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IRolRepository rolRepository;
        private readonly IUsuarioRolRepository usuarioRolRepository;
        private readonly ApplicationDBContext applicationDBContext;
        public UsuarioService(IUsuarioRepository usuarioRepository, IRolRepository rolRepository, IUsuarioRolRepository usuarioRolRepository, ApplicationDBContext applicationDBContext)
        {
            this.usuarioRepository = usuarioRepository;
            this.rolRepository = rolRepository;
            this.applicationDBContext = applicationDBContext;
            this.usuarioRolRepository = usuarioRolRepository;
        }

        public bool RegistrarUsuario(UsuarioModel model, List<RolModel> roles)
        {
            using (var transaction = applicationDBContext.Database.BeginTransaction())
            {
                try
                {
                    usuarioRepository.Crear(model);
                    foreach(var rol in roles)
                    {
                        usuarioRolRepository.Crear(new UsuarioRolModel() { rol_id = rol.id, usuario_id = model.id });
                    }
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
    }
}
