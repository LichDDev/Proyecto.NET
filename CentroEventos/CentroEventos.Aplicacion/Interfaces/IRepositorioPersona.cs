using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona p);
    void EliminarPersona(int id);
    void ModificarPersona(Persona p);
    List<Persona> ListarPersonas();
    bool ExisteId(int id);
    bool ExisteDNI(int dni);
    bool ExisteEmail(string email);
}
