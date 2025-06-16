using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RespositorioReserva() : IRepositorioReserva
{
    public void AgregarReserva(Reserva r)
    {
        using var context = new CentroDeportivoContext();
        context.Reservas.Add(r);
        context.SaveChanges();
    }
    public bool EliminarReserva(int id)
    {
        using var context = new CentroDeportivoContext();
        var reservaBorrar = context.Reservas.Where(r => r.ID == id).SingleOrDefault();
        if (reservaBorrar != null)
        {
            context.Reservas.Remove(reservaBorrar);
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public bool ModificarReserva(int id, Reserva r)
    {
        using var context = new CentroDeportivoContext();
        var reservaModificar = context.Reservas.Where(r => r.ID == id).SingleOrDefault();
        if (reservaModificar != null)
        {
            reservaModificar.PersonaId = r.PersonaId;
            reservaModificar.EventoDeportivoId = r.EventoDeportivoId;
            reservaModificar.FechaAltaReserva = r.FechaAltaReserva;
            reservaModificar.EstadoAsistencia = r.EstadoAsistencia;
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public List<Reserva> ListarReservas()
    {
        using var context = new CentroDeportivoContext();
        return context.Reservas.ToList<Reserva>();
    }
    public bool ExisteReserva(int personaId, int eventoId)
    {
        using var context = new CentroDeportivoContext();
        var reserva = context.Reservas.Where(r => r.PersonaId == personaId && r.EventoDeportivoId==eventoId).SingleOrDefault();
        return (reserva != null);
    }
    public int CantPersonasPorEvento(int eventoId)
    {
        using var context = new CentroDeportivoContext();
        return context.Reservas.Count(r => r.EventoDeportivoId == eventoId);
    }
}
