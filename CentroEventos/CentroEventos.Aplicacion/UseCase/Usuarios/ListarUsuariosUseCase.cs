using System;

namespace CentroEventos.Aplicacion;

public class ListarUsuariosUseCase(IRepositorioUsuario repo)
{
    public List<Usuario> Ejecutar() => repo.ListarUsuarios();
}
