using System;
using System.Security.AccessControl;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona: IRepositorioPersona
{
    public RepositorioPersona()
    {
        CentroEventosDB.Inicializar();
    }
    public void AgregarPersona(Persona p)
    {
        using var db = new CentroEventosDB();
        db.Add(p);
        db.SaveChanges();
    }
    public bool EliminarPersona(int id)
    {
        using var db = new CentroEventosDB();
        var elim = db.Personas.Where(r => r.ID == id).SingleOrDefault();
        if (elim != null)
        {
            db.Remove(elim);
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public bool ModificarPersona(int id, Persona p)
    {
        using var db = new CentroEventosDB();
        var a = db.Personas.Where(r => r.ID == id).SingleOrDefault();
        if (a != null)
        {
            a.Nombre = p.Nombre;
            a.DNI = p.DNI;
            a.Apellido = p.Apellido;
            a.Email = p.Email;
            a.Telefono = p.Telefono;
            db.SaveChanges();
            return true;
        }
        return false;
    }
    public List<Persona> ListarPersonas()
    {
        using var db = new CentroEventosDB();
        return db.Personas.ToList();
    }
    public bool ExisteId(int id)
    {
        using var db = new CentroEventosDB();
        return db.Personas.Any(a => a.ID == id);
    }
    public bool ExisteDNI(string dni)
    {
        using var db = new CentroEventosDB();
        return db.Personas.Any(r=> r.DNI == dni);
    }
    public bool ExisteEmail(string email)
    {
        using var db = new CentroEventosDB();
        return db.Personas.Any(r=> r.Email == email);
    }
    public Persona? BuscarPersona(int personaID)
    {
        using var db = new CentroEventosDB();
        var a = db.Personas.Where(r => r.ID == personaID).SingleOrDefault();
        return a ;
    }
}
