using System;

namespace CentroEventos.Aplicacion;

public class ValidacionEventoDeportivo(IRepositorioPersona repo)
{
    public bool Validar(EventoDeportivo evento, out string message)
    {
        //Se valida que no haya ningún elemento faltante
        message = "";
        if (string.IsNullOrWhiteSpace(evento.Nombre)) message += "El nombre del evento esta ausente\n";
        if (string.IsNullOrWhiteSpace(evento.Descripcion)) message += "La descripción del evento esta ausente\n";
        if (evento.CupoMaximo <= 0) message += "El cupo máximo debe ser mayor que cero\n";
        if (evento.DuracionHoras <= 0) message += "La duración debe ser mayor que cero\n";
        //Si la persona responsable existe, retorna si los datos son correctos, y si no existe lanza la EntidadNotFoundExeption
        if (!repo.ExisteId(evento.ResponsableId)) throw new EntidadNotFoundException("La persona responsable no existe");
        if (evento.FechaHoraInicio < DateTime.Now) throw new OperacionInvalidaException("La fecha de inicio no puede ser en el pasado");
        return string.IsNullOrEmpty(message);
    }
}
