using System;

namespace CentroEventos.Aplicacion;

public class ValidacionReserva(IRepositorioPersona repoPer, IRepositorioEventoDeportivo repoDep, IRepositorioReserva repoRes) : IValidadorReserva
{
    public bool ValidarEntidadesExistentes(Reserva r, out string message)
    {
        message = "";
        if (!repoPer.ExisteId(r.PersonaId))
            message += "No existe una persona con esa ID\n";
        if (!repoDep.ExisteId(r.EventoDeportivoId))
            message += "No existe un evento deportivo con esa ID\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarReservaUnica(Reserva r, out string message)
    {
        message = "";
        if (repoRes.ExisteReserva(r.PersonaId, r.EventoDeportivoId))
            message += "Reserva duplicada";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarCuposDisponibles(Reserva r, out string message)
    {
        message = "";
         if (repoRes.CantPersonasPorEvento(r.EventoDeportivoId) >= repoDep.CupoMaximoPorEvento(r.EventoDeportivoId))
            message +="Se exedió el cupo máximo de reservas para ese evento";
        return (string.IsNullOrWhiteSpace(message));
    }
}