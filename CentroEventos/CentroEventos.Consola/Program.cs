using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;
using Microsoft.Extensions.DependencyInjection;

var Servicios = new ServiceCollection();
//repos
Servicios.AddSingleton<IRepositorioPersona,RepositorioPersona>();
Servicios.AddSingleton<IRepositorioReserva,RespositorioReserva>();
Servicios.AddSingleton<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
//validadores
Servicios.AddTransient<IValidadorPersona, ValidacionPersona>();
Servicios.AddTransient<IValidadorReserva, ValidacionReserva>();
Servicios.AddTransient<IValidadorEventoDeportivo, ValidacionEventoDeportivo>();
Servicios.AddTransient<IServicioAutorizacion,ServicioAutorizacion>();
//casos de uso
//Personas
Servicios.AddTransient<AgregarPersonaUseCase>();
Servicios.AddTransient<ListarPersonasUseCase>();
Servicios.AddTransient<EliminarPersonaUseCase>();
Servicios.AddTransient<ModificarPersonaUseCase>();
//Eventos
Servicios.AddTransient<AgregarEventoDeportivoUseCase>();
Servicios.AddTransient<ListarEventosDeportivosUseCase>();
Servicios.AddTransient<ListarAsistenciaAEventoUseCase>();
Servicios.AddTransient<ListarEventosConCupoDisponibleUseCase>();
Servicios.AddTransient<EliminarEventoDeportivoUseCase>();
Servicios.AddTransient<ModificarEventoDeportivoUseCase>();
//Reservas
Servicios.AddTransient<AgregarReservaUseCase>();
Servicios.AddTransient<ListarReservasUseCase>();
Servicios.AddTransient<EliminarReservaUseCase>();
Servicios.AddTransient<ModificarReservaUseCase>();

var fun = Servicios.BuildServiceProvider();

var agregar = fun.GetService<AgregarPersonaUseCase>();
var listar = fun.GetService<ListarPersonasUseCase>();



