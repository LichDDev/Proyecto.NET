using System;

namespace CentroEventos.Aplicacion;

public class EliminarPersonaUseCase(IRepositorioPersona repPer,IRepositorioEventoDeportivo repoEve,IRepositorioReserva repoRes)
{
    public void Ejecutar(int personaID)
    {
        //No puede eliminarse si es responsable de algún evento
        if (repoEve.ListarEventosDeportivos().Any(e => e.ResponsableId == personaID))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque es responsable de un evento");

        //No puede eliminarse si tiene reservas asociadas
        if (repoRes.ListarReservas().Any(r => r.PersonaId == personaID))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene reservas asociadas");

        repPer.EliminarPersona(personaID);
    }
}
