using System;
using System.Security.AccessControl;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona(): IRepositorioPersona
{   
    public void AgregarPersona(Persona p)
    {
        using var context = new CentroDeportivoContext();
        context.Personas.Add(p);
        context.SaveChanges();
    }
    public bool EliminarPersona(int id)
    {
        using var context = new CentroDeportivoContext();
        var personaBorrar = context.Personas.Where(a => a.ID == id).SingleOrDefault();
        if (personaBorrar != null)
        {
            context.Personas.Remove(personaBorrar);
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public bool ModificarPersona(int id, Persona p)
    {
        using var context = new CentroDeportivoContext();
        var personaModificar = context.Personas.Where(a => a.ID == id).SingleOrDefault();
        if (personaModificar != null)
        {
            personaModificar.DNI = p.DNI;
            personaModificar.Nombre = p.Nombre;
            personaModificar.Apellido = p.Apellido;
            personaModificar.Email = p.Email;
            personaModificar.Telefono = p.Telefono;
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public List<Persona> ListarPersonas()
    {
        using var context = new CentroDeportivoContext();
        return context.Personas.ToList<Persona>();
    }
    public bool ExisteId(int id)
    {
        using var context = new CentroDeportivoContext();
        var persona = context.Personas.Where(p => p.ID == id).SingleOrDefault();
        return (persona != null);
    }
    public bool ExisteDNI(string dni)
    {
        using var context = new CentroDeportivoContext();
        var persona = context.Personas.Where(p => p.DNI == dni).SingleOrDefault();
        return (persona != null);
    }
    public bool ExisteEmail(string email)
    {
        using var context = new CentroDeportivoContext();
        var persona = context.Personas.Where(p => p.Email == email).SingleOrDefault();
        return (persona != null);
    }
    public Persona? BuscarPersona(int personaID)
    {
        using var context = new CentroDeportivoContext();
        var persona = context.Personas.Where(p => p.ID == personaID).SingleOrDefault();
        if (persona != null)
            return persona;
        else
            throw new EntidadNotFoundException("Persona no encontrada");
    }
}
