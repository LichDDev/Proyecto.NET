using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    bool ExisteId(int id);
    bool ExisteDNI(int dni);
    bool ExisteEmail(string email);
}
