using System;

namespace CentroEventos.Aplicacion;

public class ValidacionPersona(IRepositorioPersona repo) : IValidadorPersona
{
    public bool ValidarDatosAusentes(Persona p, out string message)
    {
        //Se valida que no haya ningún elemento faltante
        message = "";
        if (string.IsNullOrWhiteSpace(p.Nombre)) message += "El nombre de la persona esta ausente\n";
        if (string.IsNullOrWhiteSpace(p.Apellido)) message += "El apellido de la persona esta ausente\n";
        if (string.IsNullOrWhiteSpace(p.DNI)) message += "El DNI de la persona esta ausente\n";
        if (string.IsNullOrWhiteSpace(p.Email)) message += "El Email de la persona esta ausente\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarDNIUnico(Persona p, out string message)
    {
        message = "";
        if (p.DNI != null && repo.ExisteDNI(p.DNI)) message += "Ya existe una persona con ese DNI\n";
        return (string.IsNullOrWhiteSpace(message));
    }
    public bool ValidarEmailUnico(Persona p, out string message)
    {
        message = "";
        if (p.Email != null && repo.ExisteEmail(p.Email)) message += "Ya existe una persona con ese Email\n"; 
        return (string.IsNullOrWhiteSpace(message));
    }
}
