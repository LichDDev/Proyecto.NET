namespace CentroEventos.Aplicacion;

public interface IValidadorReserva
{
    bool ValidarEntidadesExistentes(Reserva r, out string message);
    bool ValidarReservaUnica(Reserva r, out string message);
    bool ValidarCuposDisponibles(Reserva r, out string message);
}