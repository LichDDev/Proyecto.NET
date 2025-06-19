using System;

namespace CentroEventos.Aplicacion;

public class BuscarUsuarioUseCase(IRepositorioUsuario repo)
{
    public Usuario? Ejecutar(string mail)
    {
        return repo.BuscarUsuario(mail);
    }
}
