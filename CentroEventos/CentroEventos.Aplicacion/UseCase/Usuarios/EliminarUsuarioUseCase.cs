using System;

namespace CentroEventos.Aplicacion;

public class EliminarUsuarioUseCase(IRepositorioUsuario repo,IServicioAutorizacion servicio)
{
    public void Ejecutar(int id, int idUsuario)
    {
        if (!servicio.PoseeElPermiso(idUsuario, Permiso.UsuarioBaja))
        {
            throw new FalloAutorizacionException("No tiene permisos para realizar esta operacion");
        }
        if (!repo.EliminarUsuario(id))
            throw new EntidadNotFoundException("no existe este usuario");
    }
}
