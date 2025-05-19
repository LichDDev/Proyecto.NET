using System;

namespace CentroEventos.Aplicacion;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repEve,IServicioAutorizacion s,IRepositorioReserva repRes)
{
    public void Ejecutar(int id, int idUsuario) {
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoBaja)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        //No puede eliminarse un EventoDeportivo si existen Reservas asociadas al mismo
            if (repRes.CantPersonasPorEvento(id) > 0)
                throw new OperacionInvalidaException("No se puede eliminar el evento porque tiene reservas asociadas.");
        repEve.EliminarEventoDeportivo(id);
    }
}
