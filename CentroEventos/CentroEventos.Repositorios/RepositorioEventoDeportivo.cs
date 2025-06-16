using System;
using CentroEventos.Aplicacion;
using Microsoft.VisualBasic;


namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo  : IRepositorioEventoDeportivo
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
    public bool ModificarEventoDeportivo(EventoDeportivo eve)
    {
        using var context = new CentroDeportivoContext();
        var eventoModificar = context.Eventos.Where(e => e.ID == eve.ID).SingleOrDefault();
        if (eventoModificar != null)
        {
            eventoModificar.Nombre = eve.Nombre;
            eventoModificar.Descripcion = eve.Descripcion;
            eventoModificar.FechaHoraInicio = eve.FechaHoraInicio;
            eventoModificar.DuracionHoras = eve.DuracionHoras;
            eventoModificar.CupoMaximo = eve.CupoMaximo;
            eventoModificar.ResponsableId = eve.ResponsableId;
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