using System;

namespace CentroEventos.Aplicacion;

public class ListarPermisosUseCase(IRepositorioUsuario repo)
{
    public List<PermisoCheckbox> Ejecutar(int idUsuario) => repo.ListarPermisos(idUsuario);
}
