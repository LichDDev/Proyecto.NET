using System;

namespace CentroEventos.Aplicacion;

public class AgregarPersonaUseCase (IRepositorioPersona repPer,ValidacionPersona v)
{
    public void Ejecutar(Persona p){ 
        if(p == null){
            throw new NullReferenceException("entidad = null");
        }
        if (!v.Validar(p, out string message))
            throw new ValidacionException(message);
        repPer.AgregarPersona(p);
    }
}
