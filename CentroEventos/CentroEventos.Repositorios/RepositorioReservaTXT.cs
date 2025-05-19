using System;
using CentroEventos.Aplicacion;
namespace CentroEventos.Repositorios;

public class RepositorioReservaTXT : IRepositorioReserva
{
    public void AgregarReserva(Reserva r)
    {

    }
    public void EliminarReserva(int reservaID)
    {

    }
    public void ModificarReserva(int id, Reserva reserva)
    {

    }
    public List<Reserva> ListarReservas()
    {
        return new List<Reserva>();
    }

    public bool ExisteReserva(int personaID,int eventoID)
    {
        return true;
    }
    public int CantPersonasPorEvento(int eventoID)
    {
        return 0;
    }
    
}
