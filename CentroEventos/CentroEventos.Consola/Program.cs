using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;

int idUsuario = 1;
string personaPath = "Personas.txt";
string idPersonasPath = "IDsPersonas.txt";
string eventoPath = "Eventos.txt";
string idEventosPath = "IDsEventos.txt";
string reservasPath = "Reservas.txt";
string idReservasPath="IDsReservas.txt";
// Instanciar repositorios y validaciones
var repoPersonas = new RepositorioPersona(personaPath,idPersonasPath);
var repoEventos = new RepositorioEventoDeportivo(eventoPath,idEventosPath);
var repoReservas = new RespositorioReserva(reservasPath,idReservasPath);
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

// PERSONAS:

// Prueba: Agregar una persona
var persona = new Persona { DNI = "4628554259", Nombre = "Nicolas", Apellido = "Aparicio", Email = "nico@55mail.com", Telefono = "2241" };
agregarPersonaUC.Ejecutar(persona);
persona.DNI = "7777777";persona.Email = "nico2@nose.com";
agregarPersonaUC.Ejecutar(persona);
// Prueba: Listar personas
var personas = listarPersonasUC.Ejecutar();
foreach (var p in personas)
    Console.WriteLine(p);

// Prueba: Modificar persona
int idModificarP = 1;
try
{
    persona.Nombre = "Nikitoh";
    var modificarPersonaUC = new ModificarPersonaUseCase(repoPersonas, validacionPersona);
    modificarPersonaUC.Ejecutar(idModificarP, persona);
    Console.WriteLine("Persona modificada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar persona: {ex.Message}");
}

// Prueba: Eliminar persona (esto lanzará excepción si tiene reservas o es responsable)
int idEliminarP = 1;
try
{
    var eliminarPersonaUC = new EliminarPersonaUseCase(repoPersonas, repoEventos, repoReservas);
    eliminarPersonaUC.Ejecutar(idEliminarP);
    Console.WriteLine("Persona eliminada correctamente.");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


// EVENTOS DEPORTIVOS:

// Prueba: Agregar un evento deportivo
var evento = new EventoDeportivo
{
    Nombre = "Voley",
    Descripcion = "Torneo amistoso",
    FechaHoraInicio = DateTime.Now.AddDays(2),
    DuracionHoras = 2,
    CupoMaximo = 10,
    ResponsableId = 2,
};
agregarEventoUC.Ejecutar(evento, idUsuario);
agregarEventoUC.Ejecutar(evento, idUsuario);

// Prueba: Listar eventos
var eventos = listarEventosUC.Ejecutar();
foreach (var e in eventos)
    Console.WriteLine(e);

// Prueba: Modificar evento deportivo
int idModificarE = 1;
try
{
    evento.Descripcion = "Torneo modificado";
    var modificarEventoUC = new ModificarEventoDeportivoUseCase(repoEventos, servicioAutorizacion, validacionEvento);
    modificarEventoUC.Ejecutar(idModificarE, evento, idUsuario);
    Console.WriteLine("Evento modificado correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar evento: {ex.Message}");
}

// Prueba: Eliminar evento deportivo (esto lanzará excepción si tiene reservas)
int idEliminarE = 1;
try
{
    var eliminarEventoUC = new EliminarEventoDeportivoUseCase(repoEventos, servicioAutorizacion, repoReservas);
    eliminarEventoUC.Ejecutar(idEliminarE, idUsuario);
    Console.WriteLine("Evento eliminado correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al eliminar evento: {ex.Message}");
}

// RESERVAS:

// Prueba: Agregar una reserva
var reserva = new Reserva
{
    PersonaId = 2,
    EventoDeportivoId = 2,
    FechaAltaReserva = DateTime.Now,
    EstadoAsistencia = Estado.Pendiente
};
agregarReservaUC.Ejecutar(reserva, idUsuario);

// Prueba: Listar reservas
var reservas = listarReservasUC.Ejecutar();
foreach (var r in reservas)
    Console.WriteLine(r);

// Prueba: Modificar reserva
int idModificarR = 1;
try
{
    reserva.EstadoAsistencia = Estado.Presente;
    var modificarReservaUC = new ModificarReservaUseCase(repoReservas, servicioAutorizacion, validacionReserva);
    modificarReservaUC.Ejecutar(idModificarR, reserva, idUsuario);
    Console.WriteLine("Reserva modificada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al modificar reserva: {ex.Message}");
}

// Prueba: Eliminar reserva
int idEliminarR = 1;
try
{
    var eliminarReservaUC = new EliminarReservaUseCase(repoReservas, servicioAutorizacion);
    eliminarReservaUC.Ejecutar(idEliminarR, idUsuario);
    Console.WriteLine("Reserva eliminada correctamente.");
}
catch (Exception ex)
{
    Console.WriteLine($"Error al eliminar reserva: {ex.Message}");
}
