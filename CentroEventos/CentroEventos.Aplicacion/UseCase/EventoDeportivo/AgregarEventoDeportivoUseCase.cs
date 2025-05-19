using System;

namespace CentroEventos.Aplicacion;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IServicioAutorizacion s, ValidacionEventoDeportivo v)
{
    public void Ejecutar(EventoDeportivo e,int idUsuario){
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoAlta)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        if (!v.Validar(e, out string message))
            throw new ValidacionException(message);
        repoEve.AgregarEventoDeportivo(e);
    }
}
