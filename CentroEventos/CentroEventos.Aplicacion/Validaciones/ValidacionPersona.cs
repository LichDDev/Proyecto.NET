using System;

namespace CentroEventos.Aplicacion;

public class ValidacionPersona (IRepositorioPersona repo)
{
    public bool Validar(Persona persona,out string message)
    {
        //Se valida que no haya ningún elemento faltante
        message ="";
        if(string.IsNullOrWhiteSpace(persona.Nombre)) message+= "El nombre de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.Apellido)) message+= "El apellido de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.DNI)) message+= "El DNI de la persona esta ausente\n";
        if(string.IsNullOrWhiteSpace(persona.Email)) message+= "El Email de la persona esta ausente\n";
        //Se valida que no haya ningún elemento duplicado
        string mensaje ="";
        if(persona.DNI != null && repo.ExisteDNI(persona.DNI))mensaje+= "Ya existe una persona con ese DNI\n";  //Este posible null reference es imposible porque lanzaría la tercera excepción
        if(persona.Email != null&&repo.ExisteEmail(persona.Email))mensaje+= "Ya existe una persona con ese Email\n";       //Este igual
        //Si no hay nada duplicado devuelve si hay elemento faltante para que el use case lance la excepción, y si hay duplicado lanza la duplicadoExeption
        if (mensaje == "")
            return (string.IsNullOrWhiteSpace(message));
        else
            throw new DuplicadoException(mensaje);
    }
}
