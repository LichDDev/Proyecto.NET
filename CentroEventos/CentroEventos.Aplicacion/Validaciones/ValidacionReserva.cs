using System;

namespace CentroEventos.Aplicacion;

public class ValidacionReserva (IRepositorioPersona repoPer,IRepositorioEventoDeportivo repoDep,IRepositorioReserva repoRes)
{
    public void Validar(Reserva reserva)
    {
        string message="";
        if(!repoPer.ExisteId(reserva.PersonaId))message+="No existe una persona con esa ID\n";
        if(!repoDep.ExisteId(reserva.EventoDeportivoId))message+="No existe un evento deportivo con esa ID\n";
        if(message!="")throw new ValidacionException(message);
        if(repoRes.ExisteReserva(reserva.PersonaId,reserva.EventoDeportivoId))throw new DuplicadoException("Reserva duplicada");
        //Si la cantidad de personas que reservaron el evento con esa ID es mayor o igual que el cupo máximo de ese evento, lanza la excepción
        if(repoRes.CantPersonasPorEvento(reserva.EventoDeportivoId)>=repoDep.CupoMaximoPorEvento(reserva.EventoDeportivoId))throw new CupoExcedidoException("Se exedió el cupo máximo de reservas para ese evento");
    }
}