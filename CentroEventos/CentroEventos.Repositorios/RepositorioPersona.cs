using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioPersona : IRepositorioPersona
{   
    int _ultimoEliminado;
    readonly string _personasPath="Personas.txt";
    public void AgregarPersona(Persona p)
    {
        //Se asegura que el archivo exista antes de leerlo
        if (!File.Exists(_personasPath))
        {
            using var aux = File.CreateText(_personasPath);
            aux.Close();
        }
        //Se instancia el StreamReader con el archivo _personasPath y se lee hasta la última linea
        string? linea = "";
        using (var sr = new StreamReader(_personasPath))
        {
            while (!sr.EndOfStream)
                linea = sr.ReadLine();
        }
        //Se lee la persona y se asigna la ID a la siguiente persona
        string[] persona = (!string.IsNullOrWhiteSpace(linea)) ? linea.Split(':') : new string[] { "0" };
        int id=int.Parse(persona[0])+1;
        if(id==_ultimoEliminado)id++;
        p.ID=id;
        //Se vuelve a escribir el archivo actualizado
        using var sw = new StreamWriter(_personasPath, true);
        sw.WriteLine($"{p.ID}:{p.DNI}:{p.Nombre}:{p.Apellido}:{p.Email}:{p.Telefono}");
    }
    public void EliminarPersona(int id)
    {
        List<Persona> lista=ListarPersonas();
        //Se busca en la lista una persona con la misma ID que el parametro y la remueve si existe
        int i=lista.FindIndex(p=>p.ID==id);
        if(i!=-1)
        {
            lista.RemoveAt(i);
            _ultimoEliminado=id;
            //Se removió la persona y se instancia un StreamWriter para volver a escribir el archivo
            using var sw = new StreamWriter(_personasPath);
            foreach(Persona p in lista)
                sw.WriteLine($"{p.ID}:{p.DNI}:{p.Nombre}:{p.Apellido}:{p.Email}:{p.Telefono}");
        }
    }
    public void ModificarPersona(int id, Persona p)
    {
        List<Persona> lista = ListarPersonas();
        //Se busca en la lista una persona con la misma ID que el parametro y se modifica si se encuentra
        int i = lista.FindIndex(p => p.ID == id);
        if (i != -1)
        {
            lista[i] = p;
            //Se modificó la persona y se instancia un StreamWriter para volver a escribir el archivo
            using var sw = new StreamWriter(_personasPath);
            foreach (Persona per in lista)
                sw.WriteLine($"{per.ID}:{per.DNI}:{per.Nombre}:{per.Apellido}:{per.Email}:{per.Telefono}");
        }
    }
    public List<Persona> ListarPersonas()
    {
        List<Persona> lista=new List<Persona>();
        //Si no existe el archivo, develve una lista vacia
        if (!File.Exists(_personasPath))
            return lista;
        //Se instancia un StreamReader con el archivo personasPath y se agregan las personas a un vector
        using var sr = new StreamReader(_personasPath);
        while(!sr.EndOfStream)
        {
            string? linea=sr.ReadLine();
            string[]?datos=linea?.Split(':');
            //Si hay datos se añade la persona a la lista para retornarla cuando se termine el archivo
            if (datos != null)
                lista.Add(new Persona() { ID = int.Parse(datos[0]), DNI = datos[1], Nombre = datos[2], Apellido = datos[3], Email = datos[4], Telefono = datos[5] });
        }
        return lista;
    }
    public bool ExisteId(int id)
    {
        List<Persona>lista=ListarPersonas();
        //Se busca en la lista una persona con la misma ID que el parametro
        int i=lista.FindIndex(p=>p.ID==id);
        return(i!=-1);
    }
    public bool ExisteDNI(string dni)
    {
        List<Persona>lista=ListarPersonas();
        //Se busca en la lista una persona con el mismo DNI que el parametro
        int i=lista.FindIndex(p=>p.DNI==dni);
        return(i!=-1);
    }
    public bool ExisteEmail(string email)
    {
        List<Persona>lista=ListarPersonas();
        //Se busca en la lista una persona con el mismo email que el parametro
        int i=lista.FindIndex(p=>p.Email==email);
        return(i!=-1);
    }
    public Persona BuscarPersona(int personaID)
    {
        List<Persona>lista=ListarPersonas();
        //Se busca en la lista una persona con el mismo ID que el parametro y si existe la retorna y si no lanza una excepción
        int i=lista.FindIndex(p=>p.ID==personaID);
        if(i!=-1)
            return lista[i];
        else
            throw new Exception("Persona no encontrada");
    }
}
