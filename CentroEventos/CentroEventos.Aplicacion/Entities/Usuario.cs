using System;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public static Usuario? s_Actual;
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
    protected Usuario() { }
    public Usuario(string? nombre, string? apellido, string? email, string? contraseña)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Contraseña = contraseña;
    }
    public Usuario(int id, string? nombre, string? apellido, string? email, string? contraseña) : this(nombre, apellido, email, contraseña)
    {
        ID = id;
    }
    public Usuario(int id)
    {
        ID = id;
    }   
}
