using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    void AgregarReserva(Reserva r);
    void EliminarReserva(int id);
    void ModificarReserva(int id,Reserva r);
    List<Reserva> ListarReservas();
    bool ExisteReserva(int personaId,int eventoId);
    int CantPersonasPorEvento(int eventoId);
}
