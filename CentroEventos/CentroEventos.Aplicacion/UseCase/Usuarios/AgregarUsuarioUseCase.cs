using System;

namespace CentroEventos.Aplicacion;

public class AgregarUsuarioUseCase (IRepositorioUsuario repo,IValidadorUsuario v)
{
    public void Ejecutar(Usuario usuario)
    {
        if (!v.ValidarDatosAusentes(usuario, out string message))
            throw new ValidacionException(message);
        repo.AgregarUsuario(usuario);
    }
}
