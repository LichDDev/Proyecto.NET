using System;

namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase (IRepositorioReserva repoRes,IServicioAutorizacion s,ValidacionReserva v)
{
    public void Ejecutar(int id,Reserva r,int IdUsuario){
        if(!s.PoseeElPermiso(IdUsuario,Permiso.ReservaModificacion)){
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        }
        if(r == null){
            throw new NullReferenceException("Reserva");
        }
        /*if (!v.Validar(r, out string message))
            throw new ValidacionException(message);*/
        if(!repoRes.ModificarReserva(id,r))throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
