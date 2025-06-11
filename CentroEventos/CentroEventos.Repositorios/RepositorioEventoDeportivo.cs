using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivo () : IRepositorioEventoDeportivo
{
    //mejorable 
    readonly string _idPath = @".\idEventos.txt";
    readonly string _eventosPath = @".\Eventos.txt";

    private int ObtenerSiguienteID()
    {
        int ultimoID = 0;
        if (File.Exists(_idPath))
        {
            using var sr = new StreamReader(_idPath);
            string contenido = sr.ReadToEnd();
            ultimoID = contenido != ""  ? int.Parse(contenido) : 0;
        }
        else
        {
            using var aux = File.CreateText(_idPath);
            ultimoID = 0;
        }

        int nuevoID = ultimoID + 1;
        using var sw = new StreamWriter(_idPath,false);
        sw.WriteLine(nuevoID);
        return nuevoID;
    }

    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        //Se asegura que el archivo exista antes de leerlo
        if (!File.Exists(_eventosPath))
        {
            using var aux = File.CreateText(_eventosPath);
        }
        e.ID = ObtenerSiguienteID();

        using var sw = new StreamWriter(_eventosPath, true);
        sw.WriteLine($"{e.ID},{e.Nombre},{e.Descripcion},{e.FechaHoraInicio},{e.DuracionHoras},{e.CupoMaximo},{e.ResponsableId}");
    }

    public bool EliminarEventoDeportivo(int idEvento)
    {
        var lista = ListarEventosDeportivos();
        int i = lista.FindIndex(p => p.ID == idEvento);
        if (i != -1)
        {
            using var sw = new StreamWriter(_eventosPath, false);
            lista.RemoveAt(i);
            foreach (var e in lista)
            {
                sw.WriteLine($"{e.ID},{e.Nombre},{e.Descripcion},{e.FechaHoraInicio},{e.DuracionHoras},{e.CupoMaximo},{e.ResponsableId}");
            }
            return true;
        }
        else return false;
    }
    public void ModificarEventoDeportivo(int id, EventoDeportivo e)
    {
        var lista = ListarEventosDeportivos();
        int i = lista.FindIndex(r => r.ID == id);
        if (i != -1)
        {
            using var sw = new StreamWriter(_eventosPath, false);
            e.ID = id;
            lista[i] = e;
            foreach (var eve in lista)
                sw.WriteLine($"{eve.ID},{eve.Nombre},{eve.Descripcion},{eve.FechaHoraInicio},{eve.DuracionHoras},{eve.CupoMaximo},{eve.ResponsableId}");
        }
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        var lista = new List<EventoDeportivo>();
        //Si no existe el archivo, develve una lista vacia
        if (!File.Exists(_eventosPath))
            return lista;
        using var sr = new StreamReader(_eventosPath);
        while (!sr.EndOfStream)
        {
            string? linea = sr.ReadLine();
            string[]? datos = (linea == null) ? null : linea.Split(',');
            if (datos != null)
            {
                lista.Add(new EventoDeportivo() { ID = int.Parse(datos[0]), Nombre = datos[1], Descripcion = datos[2], FechaHoraInicio = DateTime.ParseExact(datos[3], "d/M/yyyy H:mm:ss", null), DuracionHoras = double.Parse(datos[4]), CupoMaximo = int.Parse(datos[5]), ResponsableId = int.Parse(datos[6]) });
            }
        }
        return lista;
    }
    public bool ExisteId(int idEvento)
    {
        List<EventoDeportivo>lista=ListarEventosDeportivos();
        //Se busca en la lista un evento deportivo con el mismo ID que el parametro
        int i=lista.FindIndex(e=>e.ID==idEvento);
        return(i!=-1);
    }
    public int CupoMaximoPorEvento(int idEvento)
    {
        List<EventoDeportivo> lista = ListarEventosDeportivos();
        int i = lista.FindIndex(e => e.ID == idEvento);
        if (i != -1)
            return lista[i].CupoMaximo;
        else
            throw new EntidadNotFoundException("No existe un evento con ese ID");
    }   
}