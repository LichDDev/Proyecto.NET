using System;

namespace CentroEventos.Aplicacion;

public class ModificarReservaUseCase (IRepositorioReserva repoRes,IServicioAutorizacion s,IValidadorReserva v)
{
    public void Ejecutar(int id,Reserva r,int IdUsuario){
        string message;
        if (!s.PoseeElPermiso(IdUsuario, Permiso.ReservaModificacion))
            throw new FalloAutorizacionException("No tiene Permisos para realizar esta operacion");
        if(r == null)
            throw new NullReferenceException("Reserva");
        //validaciones
        if (!v.ValidarEntidadesExistentes(r, out message))
            throw new EntidadNotFoundException(message);
        if (!v.ValidarReservaUnica(r, out message))
            throw new DuplicadoException(message);
        if (!v.ValidarCuposDisponibles(r, out message))
            throw new CupoExcedidoException(message);
        if (!repoRes.ModificarReserva(id, r)) throw new EntidadNotFoundException("No se encontró una persona con esa ID");
    }
}
