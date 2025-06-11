using System;

namespace CentroEventos.Aplicacion;

public class AgregarReservaUseCase(IRepositorioReserva repoRes,IServicioAutorizacion s,IValidadorReserva v)
{
    public void Ejecutar(Reserva r,int IdUsuario){
        string message;
        if (!s.PoseeElPermiso(IdUsuario, Permiso.ReservaAlta))
        {
            throw new FalloAutorizacionException("No tiene Permisos");
        }
        if(r == null)
            throw new NullReferenceException("Reserva");
        //validaciones
        if (!v.ValidarEntidadesExistentes(r, out message))
            throw new EntidadNotFoundException(message);
        if (!v.ValidarReservaUnica(r, out message))
            throw new DuplicadoException(message);
        if (!v.ValidarCuposDisponibles(r, out message))
            throw new CupoExcedidoException(message);
        repoRes.AgregarReserva(r);
    }
}
