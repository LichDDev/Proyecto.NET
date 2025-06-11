using System;

namespace CentroEventos.Aplicacion;

public class AgregarPersonaUseCase (IRepositorioPersona repPer,IValidadorPersona v)
{
    public void Ejecutar(Persona p){ 
        if(p == null)
            throw new NullReferenceException("entidad = null");
        if (!v.ValidarDatosAusentes(p, out string message))
            throw new ValidacionException(message);
        if (!v.ValidarDNIUnico(p, out string mensaje))
            throw new DuplicadoException(mensaje);
        if (!v.ValidarEmailUnico(p, out string M))
            throw new DuplicadoException(M);
        repPer.AgregarPersona(p);
    }
}
