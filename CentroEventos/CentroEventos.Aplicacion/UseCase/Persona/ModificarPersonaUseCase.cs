using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase (IRepositorioPersona repPer)
{
    public void Ejecutar(int id, Persona p) {
        if (p == null) {
            throw new NullReferenceException("entidad = null");
        }
        if (!repPer.ModificarPersona(id, p)) throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
