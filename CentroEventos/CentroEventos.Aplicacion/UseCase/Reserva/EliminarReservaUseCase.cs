using System;

namespace CentroEventos.Aplicacion;

public class EliminarReservaUseCase (IRepositorioReserva repoRes)
{
    public void Ejecutar(int id) => repoRes.EliminarReserva(id);
}
