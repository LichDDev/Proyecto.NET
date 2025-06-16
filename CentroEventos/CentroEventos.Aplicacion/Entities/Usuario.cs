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
}
