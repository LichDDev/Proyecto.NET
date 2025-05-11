using System;

namespace CentroEventos.Aplicacion;

public class ValidacionPersona (IRepositorioPersona repo)
{
    public void Validar(Persona persona)
    {
        string message="";
        if(string.IsNullOrWhiteSpace(persona.Nombre)) message+= "El nombre de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.Apellido)) message+= "El apellido de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.DNI)) message+= "El DNI de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.Email)) message+= "El Email de la persona esta ausente\n";
        if(message!="")throw new ValidacionException(message);
        message="";

        if(persona.DNI != null && repo.ExisteDNI(persona.DNI))message+= "Ya existe una persona con ese DNI\n";  //Este posible null reference es imposible porque lanzaría la tercera excepción
        if(persona.Email != null&&repo.ExisteEmail(persona.Email))message+= "Ya existe una persona con ese Email\n";       //Este igual
        if(message!="")throw new DuplicadoException(message);
    }
}
