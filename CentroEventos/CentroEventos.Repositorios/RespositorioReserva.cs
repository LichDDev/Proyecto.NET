using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RespositorioReserva : IRepositorioReserva
{
    public RespositorioReserva()
    {
        CentroEventosDB.Inicializar();
    }
    public void AgregarReserva(Reserva r)
    {
        //Se asegura que el archivo exista antes de leerlo
        using var db = new CentroEventosDB();
        db.Add(r);
        db.SaveChanges();
    }
    public bool EliminarReserva(int id)
    {
        using var db = new CentroEventosDB();
        var elim = db.Reservas.Where(r => r.ID == id).SingleOrDefault();
        if (elim != null)
        {
            db.Remove(elim);
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public bool ModificarReserva(int id, Reserva r)
    {
        using var db = new CentroEventosDB();
        var a = db.Reservas.Where(r => r.ID == id).SingleOrDefault();
        if (a != null)
        {
            a.PersonaId = r.PersonaId;
            a.EventoDeportivoId = r.EventoDeportivoId;
            a.FechaAltaReserva = r.FechaAltaReserva;
            a.EstadoAsistencia = r.EstadoAsistencia;
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public List<Reserva> ListarReservas()
    {
        using var db = new CentroEventosDB();
        return db.Reservas.ToList();
    }
    public bool ExisteReserva(int personaId, int eventoId)
    {
        using var db = new CentroEventosDB();
        return db.Reservas.Any(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
    }
    public int CantPersonasPorEvento(int eventoId)
    {
        using var db = new CentroEventosDB();
        return db.Reservas.Count(r => r.EventoDeportivoId == eventoId);
    }
}
