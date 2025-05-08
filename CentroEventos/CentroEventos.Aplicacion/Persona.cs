using System;

namespace CentroEventos.Aplicacion;

public class Persona
{
    public int? ID{get;private set;}
    public string? DNI {get;private set;} 
    public string? Nombre{get;private set;}
    public string? Apellido{get;private set;}
    public string? Email{get;private set;}
    public string? Telefono{get;private set;}
}