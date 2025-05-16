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
        v.Validar(e);
        repoEve.ModificarEventoDeportivo(e);
    }
}
