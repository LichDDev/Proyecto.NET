using System;

namespace CentroEventos.Aplicacion;

public class ModificarUsuarioUseCase(IRepositorioUsuario repo,IServicioAutorizacion s,IValidadorUsuario v)
{
    public void Ejecutar(Usuario usuario, int idUsuario)
    {
        if (!s.PoseeElPermiso(idUsuario, Permiso.UsuarioModificacion))
        {
            throw new FalloAutorizacionException("No tiene permisos para realizar esta operacion");
        }
        if (!v.ValidarDatosAusentes(usuario, out string message))
            throw new ValidacionException(message);
        if (!v.ValidarEmailUnico(usuario, out message))
            throw new DuplicadoException(message);
        if (!repo.ModificarUsuario(usuario))
            throw new EntidadNotFoundException("no existe El usuario");
    }
}
