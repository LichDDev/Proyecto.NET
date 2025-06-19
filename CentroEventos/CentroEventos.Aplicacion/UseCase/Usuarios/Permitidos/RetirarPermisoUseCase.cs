using System;

namespace CentroEventos.Aplicacion;

public class RetirarPermisoUseCase (IRepositorioUsuario repo)
{
    public void Ejecutar(int usuarioID,Permiso permiso) => repo.RetirarPermiso(usuarioID,permiso);
}
