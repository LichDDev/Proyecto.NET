using System;

namespace CentroEventos.Aplicacion;

public class AgregarPersonaUseCase (IRepositorioPersona repPer,ValidacionPersona v)
{
    public void Ejecutar(Persona p) { 
        if(p == null){
            throw new NullReferenceException("entidad = null");
        }
        v.Validar(p,repPer);
        repPer.AgregarPersona(p);
    }
}
