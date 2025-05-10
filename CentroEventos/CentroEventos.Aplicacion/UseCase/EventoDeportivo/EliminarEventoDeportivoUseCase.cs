using System;

namespace CentroEventos.Aplicacion;

public class EliminarEventoDeportivoUseCase(IRepositorioEventoDeportivo repEve)
{
    public void Ejecutar(int id) =>repEve.EliminarEventoDeportivo(id);
}
