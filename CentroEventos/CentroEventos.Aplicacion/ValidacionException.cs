using System;

namespace CentroEventos.Aplicacion;

public class ValidacionException : Exception
{
    public ValidacionException(string message) : base(message){}
}
