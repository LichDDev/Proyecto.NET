using System;

namespace CentroEventos.Aplicacion;

public interface IServicioAutorizacion
{
    bool PoseeElPermiso(int IdUsuario, Permiso permiso);
}
