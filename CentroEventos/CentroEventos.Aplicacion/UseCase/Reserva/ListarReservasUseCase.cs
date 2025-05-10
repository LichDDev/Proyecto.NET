using System;

namespace CentroEventos.Aplicacion;

public class ListarReservasUseCase(IRepositorioReserva repoRes)
{
    public List<Reserva> Ejecutar() =>repoRes.ListarReservas();
}
