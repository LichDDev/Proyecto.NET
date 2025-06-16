using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo e);
    bool EliminarEventoDeportivo(int eventoID);
    bool ModificarEventoDeportivo(int eventoID,EventoDeportivo evento);
    List<EventoDeportivo> ListarEventosDeportivos();
    bool ExisteId(int eventoID);
    int CupoMaximoPorEvento(int eventoID);
}
