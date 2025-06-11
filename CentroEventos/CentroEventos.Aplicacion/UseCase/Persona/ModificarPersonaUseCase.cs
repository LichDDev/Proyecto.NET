using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase (IRepositorioPersona repPer,IValidadorPersona v)
{
    public void Ejecutar(int id, Persona p) {
        if (p == null) 
            throw new NullReferenceException("entidad = null");
        if (!v.ValidarDatosAusentes(p, out string message))
            throw new ValidacionException(message);
        if (!v.ValidarDNIUnico(p, out string mensaje))
            throw new DuplicadoException(mensaje);
        if (!v.ValidarEmailUnico(p, out string M))
            throw new DuplicadoException(M);
            
        if (!repPer.ModificarPersona(id, p))
            throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
