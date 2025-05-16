using System;

namespace CentroEventos.Aplicacion;

public interface IRepositorioPersona
{
    void AgregarPersona(Persona persona);
    void EliminarPersona(int personaID);
    void ModificarPersona(int personaID,Persona persona);
    List<Persona> ListarPersonas();
    bool ExisteId(int personaID);
    bool ExisteDNI(string personaDNI);
    bool ExisteEmail(string personaEmail);
    Persona BuscarPersona(int personaID);
}
