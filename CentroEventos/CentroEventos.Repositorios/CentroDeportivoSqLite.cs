using System;
using Microsoft.EntityFrameworkCore;

namespace CentroEventos.Repositorios;

public class CentroDeportivoSqLite
{
    public static void Inicializar()
    {
        using var context = new CentroDeportivoContext();
        if (context.Database.EnsureCreated())
        {
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
            command.CommandText = "PRAGMA journal_mode=DELETE;";
            command.ExecuteNonQuery();
            }
            Console.WriteLine("Se creó la base de datos");
            context.SaveChanges();
        }
    }
}
