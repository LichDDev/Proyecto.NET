using System;

namespace CentroEventos.Aplicacion;

public class Persona
{
    public int? ID { get; set; }
    public string? DNI { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Telefono { get; set; }
    protected Persona(){}
    public override string ToString() => $"ID: {ID}, DNI: {DNI}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}";
}