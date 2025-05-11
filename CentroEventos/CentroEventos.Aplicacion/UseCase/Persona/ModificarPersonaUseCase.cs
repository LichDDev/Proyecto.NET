using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase (IRepositorioPersona repPer,ValidacionPersona v)
{
    public void Ejecutar(int id,Persona p) {
        if(p == null){
            throw new NullReferenceException("entidad = null");
        }
        
        v.Validar(p);
        repPer.ModificarPersona(id,p);
    }
}
