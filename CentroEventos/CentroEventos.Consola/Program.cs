using CentroEventos.Aplicacion;
using CentroEventos.Repositorios;



using var context = new CentroEventosDB();
if (context.Database.EnsureCreated())
{
    Console.WriteLine("Se creó base de datos");
}
