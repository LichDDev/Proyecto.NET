using System;

namespace CentroEventos.Aplicacion;

public class ListarAsistenciaAEventoUseCase (IRepositorioEventoDeportivo repoEve,IRepositorioReserva repoRes,IRepositorioPersona repoPer)
{
    public List<Persona> Ejecutar(){
        List<Persona> listaAsistencia = new List<Persona>();
        List<Reserva> listaReserva = repoRes.ListarReservas();
        List<EventoDeportivo> listaEvento = repoEve.ListarEventosDeportivos();

        foreach (var item in listaEvento)
        {
            if(item.FechaHoraInicio < DateTime.Now){
                foreach (var i in listaReserva)
                {
                    if(i.EventoDeportivoId == item.ID && i.EstadoAsistencia == Estado.Presente){
                        listaAsistencia.Add(repoPer.BuscarPersona(i.PersonaId));
                    }
                }
            }
        }
        return listaAsistencia;
    }
}
