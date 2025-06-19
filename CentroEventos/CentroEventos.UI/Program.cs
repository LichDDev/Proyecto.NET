using CentroEventos.UI.Components;
using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// UseCases
builder.Services.AddTransient<AgregarPersonaUseCase>();
builder.Services.AddTransient<ListarPersonasUseCase>();
builder.Services.AddTransient<EliminarPersonaUseCase>();
builder.Services.AddTransient<ModificarPersonaUseCase>();

builder.Services.AddTransient<AgregarEventoDeportivoUseCase>();
builder.Services.AddTransient<ListarEventosDeportivosUseCase>();
builder.Services.AddTransient<ListarEventosConCupoDisponibleUseCase>();
builder.Services.AddTransient<ListarAsistenciaAEventoUseCase>();
builder.Services.AddTransient<EliminarEventoDeportivoUseCase>();
builder.Services.AddTransient<ModificarEventoDeportivoUseCase>();

builder.Services.AddTransient<AgregarReservaUseCase>();
builder.Services.AddTransient<ListarReservasUseCase>();
builder.Services.AddTransient<EliminarReservaUseCase>();
builder.Services.AddTransient<ModificarReservaUseCase>();

builder.Services.AddTransient<AgregarUsuarioUseCase>();
builder.Services.AddTransient<ListarUsuariosUseCase>();
builder.Services.AddTransient<EliminarUsuarioUseCase>();
builder.Services.AddTransient<ModificarUsuarioUseCase>();
builder.Services.AddTransient<VerificarUsuarioUseCase>();
builder.Services.AddTransient<BuscarUsuarioUseCase>();
builder.Services.AddTransient<EditarPermisosUseCase>();
builder.Services.AddTransient<ListarPermisosUseCase>();
builder.Services.AddTransient<ServicioAutorizacion>();

// Repositorios
builder.Services.AddScoped<IRepositorioPersona, RepositorioPersona>();
builder.Services.AddScoped<IRepositorioEventoDeportivo, RepositorioEventoDeportivo>();
builder.Services.AddScoped<IRepositorioReserva, RespositorioReserva>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

// Servicios y validadores
builder.Services.AddScoped<IServicioAutorizacion, ServicioAutorizacion>();
builder.Services.AddScoped<IValidadorPersona, ValidacionPersona>();
builder.Services.AddScoped<IValidadorEventoDeportivo, ValidacionEventoDeportivo>();
builder.Services.AddScoped<IValidadorReserva, ValidacionReserva>();
builder.Services.AddScoped<IValidadorUsuario, ValidacionUsuario>();

CentroDeportivoSqLite.Inicializar();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
