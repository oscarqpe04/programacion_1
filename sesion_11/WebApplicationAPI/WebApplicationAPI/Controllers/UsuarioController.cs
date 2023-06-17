using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationAPI.Models;
using WebApplicationAPI.Repository;
using WebApplicationAPI.Service;
using WebApplicationAPI.Utils;
using WebApplicationAPI.ViewModels;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IRolRepository rolRepository;
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioRepository usuarioRepository, IRolRepository rolRepository, IUsuarioService usuarioService)
        {
            this.usuarioRepository = usuarioRepository;
            this.rolRepository = rolRepository;
            this.usuarioService = usuarioService;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<UsuarioViewModel>> GetusuariosCollection(int pageNumber = 1, int pageSize = 3)
        {
            /*
            var items = usuarioRepository.ObtenerTodos();
            var totalItems = items.Count();
            var totalPages = (int) Math.Ceiling(totalItems / (double)pageSize);
            var currentPageList = items.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
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
            */
            return usuarioRepository.ObtenerTodosPagination(pageNumber, pageSize);
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> GetUsuarioModel(int id)
        {
            return usuarioRepository.ObtenerPorID(id);
        }

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioModel(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    usuarioModel.contrasenia = Utilitarios.GetMd5Hash(usuarioModel.contrasenia);
                    usuarioRepository.Actualizar(usuarioModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioModelExists(usuarioModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return NoContent();
            }
            return NoContent();
        }

        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                usuarioModel.contrasenia = Utilitarios.GetMd5Hash(usuarioModel.contrasenia);
                var roles = usuarioModel.roles.Select(roleId => new RolModel { id = roleId }).ToList();
                usuarioService.RegistrarUsuario(usuarioModel, roles);
                return NoContent();
            }

            return NoContent();
        }

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioModel(int id)
        {
            var usuarioModel = usuarioRepository.ObtenerPorID(id);

            return NoContent();
        }

        private bool UsuarioModelExists(int id)
        {
            return usuarioRepository.ObtenerPorID(id) != null;
        }
    }
}
