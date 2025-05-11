using System;

namespace CentroEventos.Aplicacion;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,ServicioAutorizacionProvisorio s, ValidacionEventoDeportivo v)
{
    public void Ejecutar(EventoDeportivo e,int idUsuario){
        if(!s.PoseeElPermiso(idUsuario,Permiso.EventoAlta)){
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        v.Validar(e);
        repoEve.AgregarEventoDeportivo(e);
    }
}
