using System;

namespace CentroEventos.Aplicacion;

public class AgregarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve,IRepositorioPersona repoPer, ValidacionEventoDeportivo v)
{
    public void Ejecutar(EventoDeportivo e){
        if(e == null){
            throw new NullReferenceException("EventoDeportivo");
        }
        v.Validar(e,repoPer);
        repoEve.AgregarEventoDeportivo(e);
    }
}
