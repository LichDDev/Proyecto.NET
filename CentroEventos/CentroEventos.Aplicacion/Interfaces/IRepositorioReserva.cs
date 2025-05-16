using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva reserva);
    void EliminarReserva(int reservaID);
    void ModificarReserva(int reservaID,Reserva reserva);
    List<Reserva> ListarReservas();
    bool ExisteReserva(int personaId,int eventoId);
    int CantPersonasPorEvento(int eventoId);
}
