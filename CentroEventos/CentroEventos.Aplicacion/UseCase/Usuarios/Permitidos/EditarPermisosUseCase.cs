using System;

namespace CentroEventos.Aplicacion;

public class EditarPermisosUseCase (IRepositorioUsuario repo)
{
    public void Ejecutar(int usuarioID,List<PermisoCheckbox> permisos)
    {
        repo.EditarPermisos(usuarioID,permisos);
    }
}
