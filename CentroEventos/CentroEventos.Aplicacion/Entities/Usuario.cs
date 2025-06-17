using System;

namespace CentroEventos.Aplicacion;

public class Usuario
{
    public int ID { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? Email { get; set; }
    public string? Contraseña { get; set; }
    public List<Permiso>? Permisos;
    protected Usuario() { }
    public Usuario(string? nombre, string? apellido, string? email, string? contraseña, List<Permiso>? permisos = null)
    {
        Nombre = nombre;
        Apellido = apellido;
        Email = email;
        Contraseña = contraseña;
        Permisos = permisos;
    }
}
