using System;

namespace CentroEventos.Aplicacion;

public interface IValidadorUsuario
{
    bool ValidarDatosAusentes(int id,out string message);
}
