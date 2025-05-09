using System;

namespace CentroEventos.Aplicacion;

public class EntidadNotFoundException : Exception
{
    public EntidadNotFoundException(string message) : base(message){}
}
