using System;

namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IServicioAutorizacion s,ValidacionEventoDeportivo v)
{
    public void Ejecutar(int id,EventoDeportivo e,int idUsuario){
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoModificacion)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        if(e == null){
            throw new NullReferenceException("EventoDeportivo");
        }
        if (!v.Validar(e, out string mensaje))
            throw new ValidacionException(mensaje);
        if (DateTime.Now > e.FechaHoraInicio.AddHours(e.DuracionHoras)) throw new OperacionInvalidaException("No se puede modificar un evento pasado");
        repoEve.ModificarEventoDeportivo(id,e);
    }
}
