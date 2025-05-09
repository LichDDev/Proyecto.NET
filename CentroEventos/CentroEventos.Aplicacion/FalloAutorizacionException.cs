using System;

namespace CentroEventos.Aplicacion;

public class FalloAutorizacionException : Exception
{
    public FalloAutorizacionException(String message) : base(message){}
}
