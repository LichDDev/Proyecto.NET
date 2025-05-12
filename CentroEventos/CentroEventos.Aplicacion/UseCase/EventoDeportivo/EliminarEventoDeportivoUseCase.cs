using System;

namespace CentroEventos.Aplicacion;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repEve,IServicioAutorizacion s)
{
    public void Ejecutar(int id, int idUsuario) {
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoBaja)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        repEve.EliminarEventoDeportivo(id);
    }
}
