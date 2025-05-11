using System;

namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase (IRepositorioReserva repoRes,ServicioAutorizacionProvisorio s,ValidacionReserva v)
{
    public void Ejecutar(int id,Reserva r,int IdUsuario){
        if(!s.PoseeElPermiso(IdUsuario,Permiso.ReservaModificacion)){
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        }
        if(r == null){
            throw new NullReferenceException("Reserva");
        }
        v.Validar(r);
        repoRes.ModificarReserva(id,r);
    }
}
