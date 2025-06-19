using System;

namespace CentroEventos.Aplicacion;

public class ListarUsuariosUseCase(IRepositorioUsuario repo)
{
    public List<Usuario> Ejecutar(int idUsuario)
    {
        return repo.ListarUsuarios();
    } 
}
