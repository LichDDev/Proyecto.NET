using System;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int IdUsuario, Permiso permiso)=>(IdUsuario==1);
}
