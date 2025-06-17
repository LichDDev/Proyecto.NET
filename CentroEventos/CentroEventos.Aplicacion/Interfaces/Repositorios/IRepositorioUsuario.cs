using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    List<Usuario> ListarUsuarios();
    void AgregarUsuario(Usuario usuario);
    bool EliminarUsuario(int usuarioID);
    bool ModificarUsuario(Usuario usuario);
    bool ExisteId(int usuarioID);
    bool BuscarPermiso(int usuarioID, Permiso permiso);
}
