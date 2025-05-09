using System;

namespace CentroEventos.Aplicacion;

public class OperacionInvalidaException : Exception
{
    public OperacionInvalidaException(string message) : base(message){}
}
