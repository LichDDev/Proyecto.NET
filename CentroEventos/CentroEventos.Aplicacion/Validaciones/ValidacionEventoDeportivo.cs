using System;

namespace CentroEventos.Aplicacion;

public class ValidacionEventoDeportivo
{
    public static void Validar(EventoDeportivo evento,IRepositorioPersona repo)
    {
        string message="";
        if(string.IsNullOrWhiteSpace(evento.Nombre)) message+= "El nombre del evento esta ausente\n";
        if(string.IsNullOrWhiteSpace(evento.Descripcion)) message+= "La descripción del evento esta ausente\n";
        if(evento.CupoMaximo<=0)message+= "El cupo máximo debe ser mayor que cero\n";
        if(evento.DuracionHoras<=0)message+= "La duración debe ser mayor que cero\n";
        if(message!="")throw new ValidacionException(message);
        if(!repo.ExisteId(evento.ResponsableId))throw new EntidadNotFoundException("La persona responsable no existe");
    }
}
