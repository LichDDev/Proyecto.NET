using System;

namespace CentroEventos.Aplicacion;

public class AgregarReservaUseCase(IRepositorioReserva repoRes,IServicioAutorizacion s,ValidacionReserva v)
{
    public void Ejecutar(Reserva r,int IdUsuario){
        if(!s.PoseeElPermiso(IdUsuario,Permiso.ReservaAlta)){
            throw new FalloAutorizacionException("No tiene Permisos");
        }
        if(r == null){
            throw new NullReferenceException("Reserva");
        }
        if (!v.Validar(r, out string message))
            throw new ValidacionException(message);
        repoRes.AgregarReserva(r);
    }
}
