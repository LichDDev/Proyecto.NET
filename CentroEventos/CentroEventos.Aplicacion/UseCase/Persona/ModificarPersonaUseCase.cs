using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase (IRepositorioPersona repPer)
{
    public void Ejecutar(Persona p) => repPer.ModificarPersona(p);
}
