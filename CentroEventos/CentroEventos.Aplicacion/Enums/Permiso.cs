using System;

namespace CentroEventos.Aplicacion;

public enum Permiso
{
    EventoAlta,             //Puede crear nuevos eventos deportivos en el centro
    EventoModificacion,     //Puede modificar los detalles de los eventos deportivos
    EventoBaja,             //Puede eliminar eventos deportivos del centro
    ReservaAlta,            //Puede registrar nuevas reservas
    ReservaModificacion,    //Puede modificar las reservas
    ReservaBaja,            //Puede dar de baja reservas
    PersonaAlta,            //Puede dar de alta Personas
    PersonaBaja,            //Puede dar de Baja Personas
    PersonaModificacion,    //Puede Modificar Personas
    UsuarioAlta,            //puede dar de alta Usuarios
    UsuarioModificacion,    //Puede modificar los datos de los usuarios
    UsuarioBaja,            //Puede dar de baja usuarios del sistema
}
