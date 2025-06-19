using System;

namespace CentroEventos.Aplicacion;

public class AgregarUsuarioUseCase (IRepositorioUsuario repo,IValidadorUsuario v)
{
    public void Ejecutar(Usuario usuario)
    {
        if (!v.ValidarDatosAusentes(usuario, out string message))
            throw new ValidacionException(message);
        if (!v.ValidarEmailUnico(usuario, out message))
            throw new DuplicadoException(message);
        repo.AgregarUsuario(usuario);
    }
}
