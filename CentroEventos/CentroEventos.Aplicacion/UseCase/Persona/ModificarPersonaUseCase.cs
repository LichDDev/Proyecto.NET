using System;

namespace CentroEventos.Aplicacion;

public class ModificarPersonaUseCase(IRepositorioPersona repPer, IServicioAutorizacion s, IValidadorPersona v)
{
    public void Ejecutar( Persona p, int idUsuario)
    {
        if (!s.PoseeElPermiso(idUsuario, Permiso.PersonaModificacion))
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        if (p == null)
            throw new NullReferenceException("entidad = null");
        if (!v.ValidarDatosAusentes(p, out string message))
            throw new ValidacionException(message);
        var perso = repPer.BuscarPersona(Convert.ToInt32(p.ID));
        //solo verifica cuando la persona cambie el dni 
        if (perso != null && perso.DNI != p.DNI)
        {
            if (!v.ValidarDNIUnico(p, out string mensaje))
                throw new DuplicadoException(mensaje);
        }
        if (perso != null && perso.Email != p.Email)
        {
            if (!v.ValidarEmailUnico(p, out string M))
                throw new DuplicadoException(M);   
        }
        if (!repPer.ModificarPersona(p))
            throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
