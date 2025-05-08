namespace CentroEventos.Aplicacion;

public class EventoDeportivo()
{
    public int ID{get;set;} 
    public string? Nombre{get;set;} 
    public string? Descripcion{get;set;}
    public DateTime FechaHoraInicio{get;set;}
    public double DuracionHoras{get;set;}
    public int CupoMaximo{get;set;}
    public int ResponsableId{get;set;} 
}
