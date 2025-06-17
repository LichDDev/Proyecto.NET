using System;
using CentroEventos.Aplicacion;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroDeportivoContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<EventoDeportivo> Eventos { get; set; }
    public DbSet<Reserva> Reservas { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Permitido> Permitidos{ get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("data source=CentroDeportivo.sqlite");
    }
}
