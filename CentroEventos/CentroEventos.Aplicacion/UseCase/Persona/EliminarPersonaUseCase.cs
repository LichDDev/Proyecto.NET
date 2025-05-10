using System;

namespace CentroEventos.Aplicacion;

public class EliminarPersonaUseCase(IRepositorioPersona repPer)
{
    public void Ejecutar(int Id) => repPer.EliminarPersona(Id);
}
