using System;

namespace CentroEventos.Aplicacion;

public class ListarEventosConCupoDisponibleUseCase (IRepositorioEventoDeportivo repoEve, IRepositorioReserva repoRes)
{
    public List<EventoDeportivo> Ejecutar(){
        
        List<EventoDeportivo> listaEventos = repoEve.ListarEventosDeportivos();
        List<EventoDeportivo> listaEventosLibres = new List<EventoDeportivo>();

        foreach (var evento in listaEventos)
        {
            if (evento.FechaHoraInicio > DateTime.Now)
            {
                int reservas = repoRes.CantPersonasPorEvento(evento.ID);
                int cupo = repoEve.CupoMaximoPorEvento(evento.ID);

                if (reservas < cupo)
                    listaEventosLibres.Add(evento);
            }
        }
        return listaEventosLibres;
    }
}
