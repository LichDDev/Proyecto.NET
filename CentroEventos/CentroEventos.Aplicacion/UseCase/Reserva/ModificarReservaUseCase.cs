using System;

namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase (IRepositorioReserva repoRes,IRepositorioEventoDeportivo repoEve,IRepositorioPersona repoPer,ValidacionReserva v)
{
    public void Ejecutar(int id,Reserva r){
        if(r == null){
            throw new NullReferenceException("Reserva");
        }
        v.Validar(r,repoPer,repoEve,repoRes);
        repoRes.ModificarReserva(id,r);
    }
}
