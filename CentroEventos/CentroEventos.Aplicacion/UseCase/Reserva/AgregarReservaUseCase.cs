using System;

namespace CentroEventos.Aplicacion;

public class AgregarReservaUseCase(IRepositorioReserva repoRes,IRepositorioEventoDeportivo repoEve,IRepositorioPersona repoPer,ValidacionReserva v)
{
    public void Ejecutar(Reserva r){
        if(r == null){
            throw new NullReferenceException("Reserva");
        }
        v.Validar(r,repoPer,repoEve,repoRes);
        repoRes.AgregarReserva(r);
    }
}
