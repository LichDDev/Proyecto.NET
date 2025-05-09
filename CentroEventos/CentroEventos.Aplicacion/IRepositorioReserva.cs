using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioReserva
{
    bool ExisteReserva(int personaId,int eventoId);
    int CantPersonasPorEvento(int eventoId);
}
