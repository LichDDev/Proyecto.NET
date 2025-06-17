using System;

namespace CentroEventos.Aplicacion;

public class VerificarUsuarioUseCase(IRepositorioUsuario repo)
{
    public bool Ejecutar(Usuario usuario) {
        return repo.VerificarContraseña(usuario);
    } 
}
