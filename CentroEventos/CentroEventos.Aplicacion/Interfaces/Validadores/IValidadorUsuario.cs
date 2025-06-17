using System;

namespace CentroEventos.Aplicacion;

public interface IValidadorUsuario
{
    bool ValidarDatosAusentes(Usuario u,out string message);
}
