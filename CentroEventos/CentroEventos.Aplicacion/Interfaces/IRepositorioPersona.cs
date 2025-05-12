using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona p);
    void EliminarPersona(int id);
    void ModificarPersona(int id,Persona p);
    List<Persona> ListarPersonas();
    bool ExisteId(int id);
    bool ExisteDNI(string dni);
    bool ExisteEmail(string email);
    Persona BuscarPersona(int personaID);
}
