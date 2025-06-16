using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva reserva);
    bool EliminarReserva(int reservaID);
    bool ModificarReserva(Reserva reserva);
    List<Reserva> ListarReservas();
    bool ExisteReserva(int personaId,int eventoId);
    int CantPersonasPorEvento(int eventoId);
}
