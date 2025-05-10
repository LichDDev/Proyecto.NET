using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    void AgregarEventoDeportivo(EventoDeportivo e);
    void EliminarEventoDeportivo(int id);
    void ModificarEventoDeportivo(int id,EventoDeportivo p);
    List<EventoDeportivo> ListarEventosDeportivos();
    bool ExisteId(int eventoId);
    int CupoMaximoPorEvento(int eventoId);
}
