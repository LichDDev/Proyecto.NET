using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;



// Instanciar repositorios y validaciones
var repoPersonas = new RepositorioPersona();
var repoEventos = new RepositorioEventoDeportivo();
var repoReservas = new RespositorioReserva();
var servicioAutorizacion = new ServicioAutorizacionProvisorio();




var listarEventosConCupos = new ListarReservasUseCase(repoReservas);

var lista = listarEventosConCupos.Ejecutar();

lista.ForEach(r => Console.WriteLine(r));