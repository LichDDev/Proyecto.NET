using System;

namespace CentroEventos.Aplicacion;

public class AgregarUsuarioUseCase (IRepositorioUsuario repo,IServicioAutorizacion servicio,IValidadorUsuario v)
{
    public void Ejecutar(Usuario usuario, int idUsuario)
    {
        if (!servicio.PoseeElPermiso(idUsuario, Permiso.UsuarioAlta))
        {
            throw new FalloAutorizacionException("No tiene permisos para realizar esta operacion");
        }
        if (!v.ValidarDatosAusentes(usuario, out string message))
            throw new ValidacionException(message);
        repo.AgregarUsuario(usuario);
    }
}
