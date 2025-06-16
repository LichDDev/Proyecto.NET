using System;

namespace CentroEventos.Aplicacion;

public interface IValidadorUsuario
{
    bool ValidarDatosAusentes(Usuario id,out string message);
}
