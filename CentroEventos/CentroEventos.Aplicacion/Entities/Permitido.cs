using System;

namespace CentroEventos.Aplicacion;

public class Permitido
{
    public int Id { get; set; }
    public Permiso Permiso { get; set; }
    public int UsuarioId { get; set; }

    protected Permitido() { }
    public Permitido(Permiso permiso, int usuario)
    {
        Permiso = permiso;
        UsuarioId = usuario;
    }
}
