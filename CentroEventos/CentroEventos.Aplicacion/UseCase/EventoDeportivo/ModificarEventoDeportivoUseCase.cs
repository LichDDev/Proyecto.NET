using System;

namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IServicioAutorizacion s,ValidacionEventoDeportivo v)
{
    public void Ejecutar(EventoDeportivo e,int idUsuario){
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoModificacion)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        if(e == null){
            throw new NullReferenceException("EventoDeportivo");
        }
        if (!v.Validar(e, out string mensaje))
            throw new ValidacionException(mensaje);
        repoEve.ModificarEventoDeportivo(e);
    }
}
