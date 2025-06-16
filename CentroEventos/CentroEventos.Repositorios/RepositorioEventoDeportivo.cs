using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo () : IRepositorioEventoDeportivo
{
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        using var context = new CentroDeportivoContext();
        context.Eventos.Add(e);
        context.SaveChanges();
    }

    public bool EliminarEventoDeportivo(int idEvento)
    {
        using var context = new CentroDeportivoContext();
        var eventoBorrar = context.Eventos.Where(e => e.ID == idEvento).SingleOrDefault();
        if (eventoBorrar != null)
        {
            context.Eventos.Remove(eventoBorrar);
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public bool ModificarEventoDeportivo(int id, EventoDeportivo e)
    {
        using var context = new CentroDeportivoContext();
        var eventoModificar = context.Eventos.Where(e => e.ID == id).SingleOrDefault();
        if (eventoModificar != null)
        {
            eventoModificar.Nombre = e.Nombre;
            eventoModificar.Descripcion = e.Descripcion;
            eventoModificar.FechaHoraInicio = e.FechaHoraInicio;
            eventoModificar.DuracionHoras = e.DuracionHoras;
            eventoModificar.CupoMaximo = e.CupoMaximo;
            eventoModificar.ResponsableId = e.ResponsableId;
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using var context = new CentroDeportivoContext();
        return context.Eventos.ToList<EventoDeportivo>();
    }
    public bool ExisteId(int idEvento)
    {
        using var context = new CentroDeportivoContext();
        var evento = context.Eventos.Where(e => e.ID == idEvento).SingleOrDefault();
        return (evento != null);
    }
    public int CupoMaximoPorEvento(int idEvento)
    {
        using var context = new CentroDeportivoContext();
        var evento = context.Eventos.Where(e => e.ID == idEvento).SingleOrDefault();
        if (evento != null)
            return evento.CupoMaximo;
        else
            throw new EntidadNotFoundException("No existe un evento con ese ID");
    }   
}