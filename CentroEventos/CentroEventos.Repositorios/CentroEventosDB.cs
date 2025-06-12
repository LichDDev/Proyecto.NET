namespace CentroEventos.Repositorios;

using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;

public class CentroEventosDB : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<EventoDeportivo> EventosDeportivos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroEventos.sqlite");
    }
}