

namespace CentroEventos.Aplicacion;

public class ListarEventosConCupoDisponibleUseCase (IRepositorioEventoDeportivo repoEve, IRepositorioReserva repoRes)
{
    public List<EventoDeportivo> Ejecutar(){
        var listaEventos = repoEve.ListarEventosDeportivos().Where(r=>DateTime.Parse(r.FechaHoraInicio) > DateTime.Now);
        var reservasL = repoRes.ListarReservas();
        var libres = listaEventos.GroupJoin(reservasL, ev => ev.ID, r => r.EventoDeportivoId,
                (evento, reservas) => new { Cupos = evento.CupoMaximo, Inscriptas = reservas.Count() , Evento = evento}).Where(o => o.Inscriptas < o.Cupos).Select(r=> r.Evento).ToList();
        return libres;
    }
}
