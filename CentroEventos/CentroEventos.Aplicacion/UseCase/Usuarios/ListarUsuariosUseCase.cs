using System;

namespace CentroEventos.Aplicacion;

public class ListarUsuariosUseCase(IRepositorioUsuario repo,IServicioAutorizacion s)
{
    public List<Usuario> Ejecutar(int idUsuario)
    {
        if (!s.PoseeElPermiso(idUsuario,Permiso.UsuarioListar))
        {
            throw new FalloAutorizacionException("No tiene permisos para realizar esta operacion");
        }
        return repo.ListarUsuarios();
    } 
}
