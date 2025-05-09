using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioEventoDeportivo
{
    bool ExisteId(int eventoId);
    int CupoMaximoPorEvento(int eventoId);
}
