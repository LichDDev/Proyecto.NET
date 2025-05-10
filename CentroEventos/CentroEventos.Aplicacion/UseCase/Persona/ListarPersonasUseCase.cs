using System;

namespace CentroEventos.Aplicacion;

public class ListarPersonasUseCase (IRepositorioPersona repPer)
{
    public List<Persona> Ejecutar() => repPer.ListarPersonas();
}
