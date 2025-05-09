using System;

namespace CentroEventos.Aplicacion;

public class DuplicadoException : Exception
{
    public DuplicadoException(string message) : base(message){}
}
