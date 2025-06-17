using System;


namespace CentroEventos.Aplicacion;

public class ListarEventosDeportivosUseCase (IRepositorioEventoDeportivo repoEve)
{
    public List<EventoDeportivo> Ejecutar() => repoEve.ListarEventosDeportivos();
}
