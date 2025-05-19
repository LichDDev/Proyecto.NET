using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo e);
    void EliminarEventoDeportivo(int eventoID);
    void ModificarEventoDeportivo(int eventoID,EventoDeportivo evento);
    List<EventoDeportivo> ListarEventosDeportivos();
    bool ExisteId(int eventoID);
    int CupoMaximoPorEvento(int eventoID);
}
