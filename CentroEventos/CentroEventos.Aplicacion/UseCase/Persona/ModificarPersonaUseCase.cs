using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase (IRepositorioPersona repPer,ValidacionPersona v)
{
    public void Ejecutar(int id,Persona p) {
        if(p == null){
            throw new NullReferenceException("entidad = null");
        }
        if (!v.Validar(p, out string message))
            throw new ValidacionException(message);
        repPer.ModificarPersona(id,p);
    }
}
