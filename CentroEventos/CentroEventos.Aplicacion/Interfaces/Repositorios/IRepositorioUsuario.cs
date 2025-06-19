using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    List<Usuario> ListarUsuarios();
    void AgregarUsuario(Usuario usuario);
    bool EliminarUsuario(int usuarioID);
    bool ModificarUsuario(Usuario usuario);
    bool ExisteId(int usuarioID);
    bool ExisteEmail(string Email);
    bool BuscarPermiso(int usuarioID, Permiso permiso);
    bool VerificarContraseña(Usuario usuario);
    void DarPermiso(int usuarioID, Permiso permiso);
    void RetirarPermiso(int usuarioID, Permiso permiso);
    List<Permiso> ListarPermisos(int usuarioId);
    Usuario? BuscarUsuario(string mail);
}
