using System;

namespace CentroEventos.Aplicacion;

public class ListarPermisosUseCase(IRepositorioUsuario repo)
{
    public List<Permiso> Ejecutar(int idUsuario) => repo.ListarPermisos(idUsuario);
}
