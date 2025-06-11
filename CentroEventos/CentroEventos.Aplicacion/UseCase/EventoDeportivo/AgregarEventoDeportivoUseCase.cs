using System;

namespace CentroEventos.Aplicacion;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IServicioAutorizacion s, IValidadorEventoDeportivo v)
{
    public void Ejecutar(EventoDeportivo e,int idUsuario){
        string message ;
        if (!s.PoseeElPermiso(idUsuario, Permiso.EventoAlta)) {
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        if (!v.ValidarDatosVacios(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarFechaDeInicio(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarCupos(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarDuracion(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarResponsable(e,out message))
            throw new EntidadNotFoundException(message);
        repoEve.AgregarEventoDeportivo(e);
    }
}
