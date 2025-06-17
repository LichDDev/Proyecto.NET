namespace CentroEventos.Aplicacion;

public class Reserva
{
    public int ID { get; set; }
    public int PersonaId { get; set; }
    public int EventoDeportivoId { get; set; }
    public DateTime FechaAltaReserva { get; set; }
    public Estado EstadoAsistencia { get; set; }
    protected Reserva(){}
    public Reserva(int personaId, int eventoDeportivoId, DateTime fechaAltaReserva, Estado estadoAsistencia)
    {
        PersonaId = personaId;
        EventoDeportivoId = eventoDeportivoId;
        FechaAltaReserva = fechaAltaReserva;
        EstadoAsistencia = estadoAsistencia;
    }
    public override string ToString() => $"ID: {ID}, Persona ID: {PersonaId}, Evento deportivo ID: {EventoDeportivoId}, Fecha de alta de reserva: {FechaAltaReserva}, Estado de asistencia: {EstadoAsistencia}";
}
