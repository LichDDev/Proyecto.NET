
namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int ID{get;set;}
    public int PersonaId{get;set;}
    public int EventoDeportivoId{get;set;}
    public DateTime FechaAltaReserva{get;set;}
    public Estado EstadoAsistencia{get;set;}
}
