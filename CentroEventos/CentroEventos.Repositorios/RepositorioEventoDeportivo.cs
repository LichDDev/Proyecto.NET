using System;
using CentroEventos.Aplicacion;
using Microsoft.VisualBasic;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo () : IRepositorioEventoDeportivo
{
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        using var db = new CentroEventosDB();
        db.Add(e);
        db.SaveChanges();
    }
    public bool EliminarEventoDeportivo(int idEvento)
    {
        using var db = new CentroEventosDB();
        var elim = db.EventosDeportivos.Where(r => r.ID == idEvento).SingleOrDefault();
        if (elim != null)
        {
            db.Remove(elim);
            db.SaveChanges();
            return true;
        }
        else
        {
            db.SaveChanges();
            return false;
        }
    }
    public bool ModificarEventoDeportivo(int id, EventoDeportivo e)
    {
        using var db = new CentroEventosDB();
        var a = db.EventosDeportivos.Where(r => r.ID == id).SingleOrDefault();
        if (a != null)
        {
            a.Nombre = e.Nombre;
            a.CupoMaximo = e.CupoMaximo;
            a.Descripcion = e.Descripcion;
            a.FechaHoraInicio = e.FechaHoraInicio;
            a.DuracionHoras = e.DuracionHoras;
            a.ResponsableId = e.ResponsableId;
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using var db = new CentroEventosDB();
        return db.EventosDeportivos.ToList();
    }
    public bool ExisteId(int idEvento)
    {
        using var db = new CentroEventosDB();
        var a = db.EventosDeportivos.Where(r=> r.ID == idEvento).SingleOrDefault();
        return(a!=null);
    }
    public int CupoMaximoPorEvento(int idEvento)
    {
        using var db = new CentroEventosDB();
        var a = db.EventosDeportivos.Where(r=> r.ID == idEvento).SingleOrDefault();
        return a!= null ? a.CupoMaximo : 0;
    }   
}