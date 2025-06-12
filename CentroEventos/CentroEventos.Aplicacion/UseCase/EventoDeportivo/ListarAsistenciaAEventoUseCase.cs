using System;

namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase (IRepositorioEventoDeportivo repoEve,IRepositorioReserva repoRes,IRepositorioPersona repoPer)
{
    public List<Persona> Ejecutar(int idEvento){
        var listaReserva = repoRes.ListarReservas();
        var listaEvento = repoEve.ListarEventosDeportivos();
        var listaPersona = repoPer.ListarPersonas();

        var listaAsistencia = listaEvento.Where(r => r.FechaHoraInicio < DateTime.Now && r.ID == idEvento).Join(listaReserva.Where(r=>r.EstadoAsistencia == Estado.Presente),
                            l => l.ID,
                            r => r.EventoDeportivoId,
                            (evento,reserva) => new { id = reserva.PersonaId}
                            ).Join(listaPersona, r => r.id, p=>p.ID,
                            (res, per) => per).ToList();
        return listaAsistencia;
    }
}
