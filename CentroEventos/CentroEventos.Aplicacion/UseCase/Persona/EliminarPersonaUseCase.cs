using System;

namespace CentroEventos.Aplicacion;

public class EliminarPersonaUseCase(IRepositorioPersona repPer,IRepositorioEventoDeportivo repoEve,IRepositorioReserva repoRes,IServicioAutorizacion s)
{
    public void Ejecutar(int personaID,int idUsuario)
    {
        if(!s.PoseeElPermiso(idUsuario,Permiso.PersonaBaja))
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        //No puede eliminarse si es responsable de algún evento
        if (repoEve.ListarEventosDeportivos().Any(e => e.ResponsableId == personaID))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque es responsable de un evento");
        
        //No puede eliminarse si tiene reservas asociadas
        if (repoRes.ListarReservas().Any(r => r.PersonaId == personaID))
            throw new OperacionInvalidaException("No se puede eliminar la persona porque tiene reservas asociadas");

        if (!repPer.EliminarPersona(personaID))
            throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
