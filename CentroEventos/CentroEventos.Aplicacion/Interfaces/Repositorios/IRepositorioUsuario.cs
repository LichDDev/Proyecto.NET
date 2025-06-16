using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioUsuario
{
    public
    void AgregarUsuario(Usuario usuario);
    bool EliminarUsuario(int usuarioID);
    bool ModificarUsuario(int usuarioIDreserva, Usuario usuario);
    bool ExisteId(int usuarioID);
    bool BuscarPermiso(int usuarioID, Permiso permiso);
}
