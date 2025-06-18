namespace CentroEventos.Aplicacion;

public class EventoDeportivo 
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? FechaHoraInicio { get; set; }
    public double DuracionHoras { get; set; }
    public int CupoMaximo { get; set; }
    public int ResponsableId { get; set; }
    protected EventoDeportivo(){}
    public EventoDeportivo(string? nombre, string? descripcion, string? fechaHoraInicio, double duracionHoras, int cupoMaximo, int responsableId)
    {
        Nombre = nombre;
        Descripcion = descripcion;
        FechaHoraInicio = fechaHoraInicio;
        DuracionHoras = duracionHoras;
        CupoMaximo = cupoMaximo;
        ResponsableId = responsableId;
    }
    public EventoDeportivo(int id, string? nombre, string? descripcion, string? fechaHoraInicio, double duracionHoras, int cupoMaximo, int responsableId):this(nombre, descripcion, fechaHoraInicio, duracionHoras, cupoMaximo, responsableId)
    {
        ID = id;
    }
    public override string ToString() => $"ID: {ID}, Nombre: {Nombre}, Descripción: {Descripcion}, Fecha de inicio: {FechaHoraInicio}, Cupo máximo: {CupoMaximo}, ID del responsable: {ResponsableId}";
}
