using System;

namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(){}

    public FalloAutorizacionException(string message): base(message){}

    public FalloAutorizacionException(string message,Exception inner):base(message , inner){}
}
