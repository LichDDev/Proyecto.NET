using System;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public static int s_miId;
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
}
