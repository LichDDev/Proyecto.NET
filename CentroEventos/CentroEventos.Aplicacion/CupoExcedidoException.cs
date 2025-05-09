using System;

namespace CentroEventos.Aplicacion;

public class CupoExcedidoException : Exception
{
    public CupoExcedidoException(string message) : base(message){}
}
