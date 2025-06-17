using System;

namespace CentroEventos.Aplicacion;

<<<<<<< HEAD
public class ValidacionUsuario : IValidadorUsuario
=======
public class ValidacionUsuario: IValidadorUsuario
>>>>>>> a7c52aa1d099b8ec3724cbebfc5b31278808aeb9
{
    public bool ValidarDatosAusentes(Usuario u, out string message)
    {
        //Se valida que no haya ningún elemento faltante
        message = "";
        if (string.IsNullOrWhiteSpace(u.Nombre)) message += "El nombre del usuario esta ausente\n";
        if (string.IsNullOrWhiteSpace(u.Apellido)) message += "El apellido del usuario esta ausente\n";
        if (string.IsNullOrWhiteSpace(u.Email)) message += "El Email del usuario esta ausente\n";
        if (string.IsNullOrWhiteSpace(u.Contraseña)) message += "La contraseña del usuario esta ausente\n";
        return (string.IsNullOrWhiteSpace(message));
    }
}
