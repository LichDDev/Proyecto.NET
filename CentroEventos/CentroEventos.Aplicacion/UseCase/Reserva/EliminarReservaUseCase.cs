using System;

namespace CentroEventos.Aplicacion;

public class EliminarReservaUseCase (IRepositorioReserva repoRes,ServicioAutorizacionProvisorio s)
{
    public void Ejecutar(int id,int IdUsuario) { 
        if(!s.PoseeElPermiso(IdUsuario,Permiso.ReservaBaja )){
            throw new FalloAutorizacionException("no tiene Permisos");
        }
        repoRes.EliminarReserva(id);
    }
}
