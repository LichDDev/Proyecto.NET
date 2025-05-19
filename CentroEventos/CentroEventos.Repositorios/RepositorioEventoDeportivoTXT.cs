using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioEventoDeportivoTXT : IRepositorioEventoDeportivo
{
    private int _idFinal;
    readonly string _eventosPath = "Eventos.txt";
    public void AgregarEventoDeportivo(EventoDeportivo e)
    {
        var lista = ListarEventosDeportivos();
        int id = (lista.Count > 0) ? lista[lista.Count-1].ID : 0;
        id++;
        if (id <= _idFinal)
            id = _idFinal +1;
        e.ID = id;

        using var sw = new StreamWriter(_eventosPath,true);
        sw.WriteLine($"{e.ID}:{e.Nombre}:{e.Descripcion}:{e.FechaHoraInicio}:{e.DuracionHoras}:{e.CupoMaximo}:{e.ResponsableId}");
    }
    public void EliminarEventoDeportivo(int idEvento)
    {
        bool encontrado = false;
        using var sw = new StreamWriter(_eventosPath, false);
        var lista = ListarEventosDeportivos();
        if (idEvento > _idFinal)
        {
            _idFinal = idEvento;
        } 
        for (int i = 0; i < lista.Count; i++)
        {
            if (lista[i].ID == idEvento)
            {
                lista.RemoveAt(i);
                encontrado = true;
            }
        }
        if (!encontrado)
        {
            throw new EntidadNotFoundException("Entidad no encontrada");
        }
        foreach (var e in lista)
        {
            sw.WriteLine($"{e.ID}:{e.Nombre}:{e.Descripcion}:{e.FechaHoraInicio}:{e.DuracionHoras}:{e.CupoMaximo}:{e.ResponsableId}");
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
            sw.WriteLine($"{e.ID}:{e.Nombre}:{e.Descripcion}:{e.FechaHoraInicio}:{e.DuracionHoras}:{e.CupoMaximo}:{e.ResponsableId}");
        }  
    }
    public List<EventoDeportivo> ListarEventosDeportivos()
    {
        using var sr = new StreamReader(_eventosPath);
        var lista = new List<EventoDeportivo>();
        while (!sr.EndOfStream)
        {
            string? linea = sr.ReadLine();
            string[]? datos = (linea == null)? null : linea.Split(':');
            if (datos != null)
            {
                lista.Add(new EventoDeportivo() { ID = int.Parse(datos[0]), Nombre = datos[1], Descripcion = datos[2], FechaHoraInicio = DateTime.Parse(datos[3]), DuracionHoras = double.Parse(datos[4]), CupoMaximo = int.Parse(datos[5]), ResponsableId = int.Parse(datos[6]) });
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
