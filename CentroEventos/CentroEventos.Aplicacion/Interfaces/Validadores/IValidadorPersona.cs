using System;

namespace CentroEventos.Aplicacion;

public interface IValidadorPersona
{
    bool ValidarDatosAusentes(Persona p, out string message);
    bool ValidarDNIUnico(Persona p, out string message);
    bool ValidarEmailUnico(Persona p, out string message);
}
