using System;

namespace CentroEventos.Aplicacion;

public class EliminarReservaUseCase (IRepositorioReserva repoRes,IServicioAutorizacion s)
{
    public void Ejecutar(int id,int IdUsuario) { 
        if(!s.PoseeElPermiso(IdUsuario,Permiso.ReservaBaja )){
            throw new FalloAutorizacionException("no tiene Permisos");
        }
        if(!repoRes.EliminarReserva(id))throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
