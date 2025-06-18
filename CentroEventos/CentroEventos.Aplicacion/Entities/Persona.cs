using System;
using System.Globalization;

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
    public Persona(string? dni = null,string? nombre = null, string? apellido = null ,string ? email = null,string? telefono = null)
    {
        DNI = dni;
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Telefono = telefono;
    }
    public Persona(int? id = null, string? dni = null, string? nombre = null, string? apellido = null, string? email = null, string? telefono = null) : this(dni, nombre, apellido, email, telefono)
    {
        ID=id;
    }
    public override string ToString() => $"ID: {ID}, DNI: {DNI}, Nombre: {Nombre}, Apellido: {Apellido}, Email: {Email}, Telefono: {Telefono}";
}