using System;

namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase (IRepositorioReserva repoRes,IServicioAutorizacion s,IValidadorReserva v)
{
    public void Ejecutar(Reserva r,int IdUsuario){
        string message;
        if (!s.PoseeElPermiso(IdUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        if(r == null)
            throw new NullReferenceException("Reserva");
        //validaciones
        if (!v.ValidarEntidadesExistentes(r, out message))
            throw new EntidadNotFoundException(message);
        var res = repoRes.ListarReservas().Where(a=> a.ID == r.ID).SingleOrDefault();
        //verificamos solo cuando la reserva sea a nombre de otra persona
        if (res != null && (res.PersonaId != r.PersonaId && r.EventoDeportivoId == res.EventoDeportivoId || res.PersonaId == r.PersonaId && r.EventoDeportivoId != res.EventoDeportivoId ))
        {
            if (!v.ValidarReservaUnica(r, out message))
                throw new DuplicadoException(message);
        }
        if (res != null && r.EventoDeportivoId != res.EventoDeportivoId)
        {
            if (!v.ValidarCuposDisponibles(r, out message))
               throw new CupoExcedidoException(message);   
        }  
        if (!repoRes.ModificarReserva(r))
            throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
