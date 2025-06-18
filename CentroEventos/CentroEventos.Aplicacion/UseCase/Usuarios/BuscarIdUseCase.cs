using System;

namespace CentroEventos.Aplicacion;

public class BuscarIdUseCase(IRepositorioUsuario repo)
{
    public int Ejecutar(string mail)
    {
        return repo.BuscarId(mail);
    }
}
