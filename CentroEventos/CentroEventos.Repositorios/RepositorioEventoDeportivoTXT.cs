using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    private int _ultimoEliminado;
    readonly string _eventosPath = "Eventos.txt";
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        //Se asegura que el archivo exista antes de leerlo
        if (!File.Exists(_eventosPath))
        {
            using var aux = File.CreateText(_eventosPath);
            aux.Close();
        }
        string? linea = "";
        //instancia un streamReader con el path de la entidad(Persona, evento o reserva)
        using (var sr = new StreamReader(_eventosPath))
        {
            //lee la ultima linea del archivo (supone que los datos esta estructurados en una Linea)
            while (!sr.EndOfStream)
            {
            linea = sr.ReadLine();
            }
        }
        //recibe la ultima linea y lo separa por ':' para poder tomar el id que se encuentra primero
        //en caso de estar vacio se toma el id 0 
        string[] entidad = (!string.IsNullOrWhiteSpace(linea)) ? linea.Split(',') : new string[] { "0" };

        //toma el id y lo incrementa
        int id = int.Parse(entidad[0]);
        id++;
        if (id == _ultimoEliminado) id++;
        e.ID = id;

        using var sw = new StreamWriter(_eventosPath,true);
        sw.WriteLine($"{e.ID},{e.Nombre},{e.Descripcion},{e.FechaHoraInicio},{e.DuracionHoras},{e.CupoMaximo},{e.ResponsableId}");
    }
    public void EliminarEventoDeportivo(int idEvento)
    {
        _ultimoEliminado = idEvento;
        using var sw = new StreamWriter(_eventosPath, false);
        var lista = ListarEventosDeportivos();

        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].ID == idEvento)
            {
                lista.RemoveAt(i);
            }
        }
        foreach (var e in lista)
        {
            sw.WriteLine($"{e.ID},{e.Nombre},{e.Descripcion},{e.FechaHoraInicio},{e.DuracionHoras},{e.CupoMaximo},{e.ResponsableId}");
        }        
    }
    public void ModificarEventoDeportivo(EventoDeportivo e)
    {
        using var sw = new StreamWriter(_eventosPath,false);
        var lista = ListarEventosDeportivos();
        for(int i = 0; i< lista.Count; i++)
        {
            if (lista[i].ID == e.ID){
                lista[i] = e;
            }
            sw.WriteLine($"{e.ID},{e.Nombre},{e.Descripcion},{e.FechaHoraInicio},{e.DuracionHoras},{e.CupoMaximo},{e.ResponsableId}");
        }  
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using var sr = new StreamReader(_eventosPath);
        var lista = new List<EventoDeportivo>();
        //Si no existe el archivo, develve una lista vacia
        if (!File.Exists(_eventosPath))
            return lista;
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
