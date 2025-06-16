using System;
using System.Runtime.InteropServices;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacion(IRepositorioUsuario repo) : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)
    {
        return repo.BuscarPermiso(IdUsuario, permiso);
    }
}
