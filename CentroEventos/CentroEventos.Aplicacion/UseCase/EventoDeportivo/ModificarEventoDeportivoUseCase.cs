using System;

namespace CentroEventos.Aplicacion;

public class ModificarEventoDeportivoUseCase(IRepositorioEventoDeportivo repoEve, IServicioAutorizacion s,IValidadorEventoDeportivo v)
{
    public void Ejecutar(int id, EventoDeportivo e, int idUsuario)
    {
        string message;
        //valida el permiso 
        if (!s.PoseeElPermiso(idUsuario, Permiso.EventoModificacion))
        {
            throw new FalloAutorizacionException("no posee permisos para realizar esta operacion");
        }
        if (e == null)
        {
            throw new NullReferenceException("EventoDeportivo");
        }
        //valida los datos por separado
        if (!v.ValidarDatosVacios(e, out message))
            throw new ValidacionException(message);
        if (!v.ValidarFechaDeInicio(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarCupos(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarDuracion(e,out message))
            throw new ValidacionException(message);
        if (!v.ValidarResponsable(e,out message))
            throw new EntidadNotFoundException(message);
        //regla de negocio
        if (DateTime.Now > e.FechaHoraInicio.AddHours(e.DuracionHoras))
        {
            throw new OperacionInvalidaException("No se puede modificar un evento pasado");
        }   
        repoEve.ModificarEventoDeportivo(id, e);
    }
}