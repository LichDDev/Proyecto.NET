using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

int idUsuario = 1;
// Instanciar repositorios y validaciones
var repoPersonas = new RepositorioPersona();
var repoEventos = new RepositorioEventoDeportivoTXT();
var repoReservas = new RespositorioReserva();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();

var validacionPersona = new ValidacionPersona(repoPersonas);
var validacionEvento = new ValidacionEventoDeportivo(repoPersonas);
var validacionReserva = new ValidacionReserva(repoPersonas, repoEventos, repoReservas);

// UseCases
var agregarPersonaUC = new AgregarPersonaUseCase(repoPersonas, validacionPersona);
var listarPersonasUC = new ListarPersonasUseCase(repoPersonas);

var agregarEventoUC = new AgregarEventoDeportivoUseCase(repoEventos, servicioAutorizacion, validacionEvento);
var listarEventosUC = new ListarEventosDeportivosUseCase(repoEventos);

var agregarReservaUC = new AgregarReservaUseCase(repoReservas, servicioAutorizacion, validacionReserva);
var listarReservasUC = new ListarReservasUseCase(repoReservas);

// Prueba: Agregar una persona
var persona = new Persona { DNI = "12345678", Nombre = "Juan", Apellido = "Pérez", Email = "juan@mail.com", Telefono = "1234" };
/*agregarPersonaUC.Ejecutar(persona, idUsuario);

// Prueba: Listar personas
var personas = listarPersonasUC.Ejecutar();
foreach (var p in personas)
    Console.WriteLine(p);

// Prueba: Agregar un evento deportivo
var evento = new EventoDeportivo
{
    Nombre = "Fútbol 5",
    Descripcion = "Torneo amistoso",
    FechaHoraInicio = DateTime.Now.AddDays(2),
    DuracionHoras = 2,
    CupoMaximo = 10,
    ResponsableId = persona.ID ?? 0
};
agregarEventoUC.Ejecutar(evento, 1);

// Prueba: Listar eventos
var eventos = listarEventosUC.Ejecutar();
foreach (var e in eventos)
    Console.WriteLine(e);

// Prueba: Agregar una reserva
var reserva = new Reserva
{
    PersonaId = persona.ID ?? 0,
    EventoDeportivoId = evento.ID,
    FechaAltaReserva = DateTime.Now,
    EstadoAsistencia = Estado.Pendiente
};
agregarReservaUC.Ejecutar(reserva, 1);

// Prueba: Listar reservas
var reservas = listarReservasUC.Ejecutar();
foreach (var r in reservas)
    Console.WriteLine(r);
*/
// Prueba: Modificar persona
try
{
    persona.Nombre = "Juan Carlos";
    var modificarPersonaUC = new ModificarPersonaUseCase(repoPersonas, validacionPersona);
    modificarPersonaUC.Ejecutar(persona.ID ?? 0, persona);
    Console.WriteLine("Persona modificada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar persona: {ex.Message}");
}

// Prueba: Eliminar persona (esto lanzará excepción si tiene reservas o es responsable)
try
{
    var eliminarPersonaUC = new EliminarPersonaUseCase(repoPersonas, repoEventos, repoReservas);
    eliminarPersonaUC.Ejecutar(persona.ID ?? 0);
    Console.WriteLine("Persona eliminada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al eliminar persona: {ex.Message}");
}

/*// Prueba: Modificar evento deportivo
try
{
    evento.Descripcion = "Torneo modificado";
    var modificarEventoUC = new ModificarEventoDeportivoUseCase(repoEventos, servicioAutorizacion, validacionEvento);
    modificarEventoUC.Ejecutar(evento, idUsuario);
    Console.WriteLine("Evento modificado correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar evento: {ex.Message}");
}

// Prueba: Eliminar evento deportivo (esto lanzará excepción si tiene reservas)
try
{
    var eliminarEventoUC = new EliminarEventoDeportivoUseCase(repoEventos, servicioAutorizacion, repoReservas);
    eliminarEventoUC.Ejecutar(evento.ID, idUsuario);
    Console.WriteLine("Evento eliminado correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al eliminar evento: {ex.Message}");
}

// Prueba: Modificar reserva
try
{
    reserva.EstadoAsistencia = Estado.Presente;
    var modificarReservaUC = new ModificarReservaUseCase(repoReservas, servicioAutorizacion, validacionReserva);
    modificarReservaUC.Ejecutar(reserva.ID, reserva, idUsuario);
    Console.WriteLine("Reserva modificada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar reserva: {ex.Message}");
}

// Prueba: Eliminar reserva
try
{
    var eliminarReservaUC = new EliminarReservaUseCase(repoReservas, servicioAutorizacion);
    eliminarReservaUC.Ejecutar(reserva.ID, idUsuario);
    Console.WriteLine("Reserva eliminada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al eliminar reserva: {ex.Message}");
}*/
