namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int ID { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public string? FechaAltaReserva { get; set; }
    public Estado? EstadoAsistencia { get; set; }
    protected Reserva(){}
    public Reserva(int personaId, int eventoDeportivoId, string? fechaAltaReserva, Estado? estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }
    public Reserva(int id,int personaId, int eventoDeportivoId, string? fechaAltaReserva, Estado? estadoAsistencia):this(personaId, eventoDeportivoId, fechaAltaReserva, estadoAsistencia)
    {
        ID = id;
    }
    public override string ToString() => $"ID: {ID}, Persona ID: {PersonaId}, Evento deportivo ID: {EventoDeportivoId}, Fecha de alta de reserva: {FechaAltaReserva}, Estado de asistencia: {EstadoAsistencia}";
}
