﻿using WebApplicationAPI.Models;

namespace WebApplicationAPI.Repository
{
    public interface IUsuarioRolRepository
    {
        UsuarioRolModel ObtenerPorID(int id);
        List<UsuarioRolModel> ObtenerTodos();
        void Crear(UsuarioRolModel model);
        void Actualizar(UsuarioRolModel model);
        void Eliminar(int id);
    }
}
