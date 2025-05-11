using System;

namespace CentroEventos.Aplicacion;

public class AgregarPersonaUseCase (IRepositorioPersona repPer,ValidacionPersona v)
{
    public void Ejecutar(Persona p,int idUsuario){ 
        if(p == null){
            throw new NullReferenceException("entidad = null");
        }
        v.Validar(p);
        repPer.AgregarPersona(p);
    }
}
