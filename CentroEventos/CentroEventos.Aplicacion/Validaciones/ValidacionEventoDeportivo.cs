using System;

namespace CentroEventos.Aplicacion;

public class ValidacionEventoDeportivo(IRepositorioPersona repo) : IValidadorEventoDeportivo
{
    public bool ValidarDatosVacios(EventoDeportivo evento, out string message)
    {
        message = "";
        if (string.IsNullOrWhiteSpace(evento.Nombre)) message += "El nombre del evento esta ausente\n";
        if (string.IsNullOrWhiteSpace(evento.Descripcion)) message += "La descripción del evento esta ausente\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarCupos(EventoDeportivo evento, out string message)
    { 
        message = "";
        if (evento.CupoMaximo <= 0)
            message += "El cupo máximo debe ser mayor que cero\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarFechaDeInicio(EventoDeportivo evento,out string message)
    {
        message = "";
        if (DateTime.Parse(evento.FechaHoraInicio) < DateTime.Now)
            message += "La fecha de inicio no puede ser en el pasado";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarDuracion(EventoDeportivo evento,out string message)
    {
        message = "";
        if (evento.DuracionHoras <= 0)
            message += "La duración debe ser mayor que cero\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarResponsable(EventoDeportivo evento,out string message)
    {
        message = "";
        if (!repo.ExisteId(evento.ResponsableId))
            message += "La persona responsable no existe";
        return (string.IsNullOrWhiteSpace(message));
    }
}
