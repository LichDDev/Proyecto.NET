using System;

namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IRepositorioPersona repoPer,ValidacionEventoDeportivo v)
{
    public void Ejecutar(int id,EventoDeportivo e){
        if(e == null){
            throw new NullReferenceException("EventoDeportivo");
        }
        v.Validar(e,repoPer);
        repoEve.ModificarEventoDeportivo(id,e);
    }
}
