using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RespositorioReserva() : IRepositorioReserva
{
    private string _idPath = @".\idReservas.txt";
    readonly string _reservasPath = @".\Reservas.txt";
    private int ObtenerSiguienteID()
    {
        int ultimoID = 0;
        if (File.Exists(_idPath))
        {
            using var sr = new StreamReader(_idPath);
            string contenido = sr.ReadToEnd();
            ultimoID = contenido != "" ? int.Parse(contenido) : 0;
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
    public void AgregarReserva(Reserva r)
    {
        //Se asegura que el archivo exista antes de leerlo
        if (!File.Exists(_reservasPath))
        {
            using var aux = File.CreateText(_reservasPath);
        }
        r.ID = ObtenerSiguienteID();
        //Se vuelve a escribir el archivo actualizado
        using var sw = new StreamWriter(_reservasPath, true);
        sw.WriteLine($"{r.ID},{r.PersonaId},{r.EventoDeportivoId},{r.FechaAltaReserva},{r.EstadoAsistencia}");
    }
    public bool EliminarReserva(int id)
    {
        List<Reserva> lista = ListarReservas();
        //Se busca en la lista una reserva con la misma ID que el parametro y la remueve si existe
        int i = lista.FindIndex(p => p.ID == id);
        if (i != -1)
        {
            lista.RemoveAt(i);
            //Se removió la reserva y se instancia un StreamWriter para volver a escribir el archivo
            using var sw = new StreamWriter(_reservasPath);
            foreach (Reserva r in lista)
                sw.WriteLine($"{r.ID},{r.PersonaId},{r.EventoDeportivoId},{r.FechaAltaReserva},{r.EstadoAsistencia}");
            return true;
        }
        else return false;
    }
    public bool ModificarReserva(int id, Reserva r)
    {
        List<Reserva> lista = ListarReservas();
        //Se busca en la lista una reserva con la misma ID que el parametro y se modifica si se encuentra
        int i = lista.FindIndex(r => r.ID == id);
        if (i != -1)
        {
            r.ID = lista[i].ID;
            lista[i] = r;
            //Se modificó la reserva y se instancia un StreamWriter para volver a escribir el archivo
            using var sw = new StreamWriter(_reservasPath);
            foreach (Reserva res in lista)
                sw.WriteLine($"{res.ID},{res.PersonaId},{res.EventoDeportivoId},{res.FechaAltaReserva},{res.EstadoAsistencia}");
            return true;
        }
        else return false;
    }
    public List<Reserva> ListarReservas()
    {
        List<Reserva> lista = new List<Reserva>();
        //Si no existe el archivo, develve una lista vacia
        if (!File.Exists(_reservasPath))
            return lista;
        //Se instancia un StreamReader con el archivo reservasPath y se agregan las reservas a un vector
        using var sr = new StreamReader(_reservasPath);
        while (!sr.EndOfStream)
        {
            string? linea = sr.ReadLine();
            string[]? datos = linea?.Split(',');
            //Si hay datos se añade la reserva a la lista para retornarla cuando se termine el archivo
            if (datos != null)
                lista.Add(new Reserva() { ID = int.Parse(datos[0]), PersonaId = int.Parse(datos[1]), EventoDeportivoId = int.Parse(datos[2]), FechaAltaReserva = DateTime.Parse(datos[3]), EstadoAsistencia = Enum.Parse<Estado>(datos[4]) });
        }
        return lista;
    }
    public bool ExisteReserva(int personaId, int eventoId)
    {
        List<Reserva> lista = ListarReservas();
        //Se busca en la lista una reserva con la misma ID que el parametro
        int i = lista.FindIndex(r => r.PersonaId == personaId && r.EventoDeportivoId == eventoId);
        return (i != -1);
    }
    public int CantPersonasPorEvento(int eventoId)
    {
        List<Reserva> lista = ListarReservas();
        //Se busca en la lista la cantidad de reservas del evento deportivo con la misma ID que el parametro
        return lista.Count(r => r.EventoDeportivoId == eventoId);
    }
}
