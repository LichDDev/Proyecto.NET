using System;

namespace CentroEventos.Aplicacion;

public class DarPermisoUseCase (IRepositorioUsuario repo)
{
    public void Ejecutar(int usuarioID,Permiso permiso)
    {
        repo.DarPermiso(usuarioID,permiso);
    }
}
