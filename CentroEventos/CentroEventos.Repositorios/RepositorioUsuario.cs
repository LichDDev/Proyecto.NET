using System;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario() : IRepositorioUsuario
{
    public void AgregarUsuario(Usuario u)
    {
        using var context = new CentroDeportivoContext();
        context.Usuarios.Add(u);
        context.SaveChanges();
    }
    public bool EliminarUsuario(int id)
    {
        using var context = new CentroDeportivoContext();
        var usuarioBorrar = context.Usuarios.Where(u => u.ID == id).SingleOrDefault();
        if (usuarioBorrar != null)
        {
            context.Usuarios.Remove(usuarioBorrar);
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public bool ModificarUsuario(int id, Usuario u)
    {
        using var context = new CentroDeportivoContext();
        var usuarioModificar = context.Usuarios.Where(u => u.ID == id).SingleOrDefault();
        if (usuarioModificar != null)
        {
            usuarioModificar.ID = u.ID;
            usuarioModificar.Nombre = u.Nombre;
            usuarioModificar.Apellido = u.Apellido;
            usuarioModificar.Email = u.Email;
            usuarioModificar.Contraseña=u.Contraseña;
            usuarioModificar.Permisos = u.Permisos;
            context.SaveChanges();
            return true;
        }
        else
            return false;
    }
    public bool ExisteId(int usuarioID)
    {
        using var context = new CentroDeportivoContext();
        var usuario = context.Usuarios.Where(u => u.ID == usuarioID).SingleOrDefault();
        return (usuario != null);
    }
    public bool BuscarPermiso(int usuarioID, Permiso permiso)
    {
        using var context = new CentroDeportivoContext();
        var usuario = context.Usuarios.Where(u => u.ID == usuarioID).SingleOrDefault();
        if (usuario != null)
            return usuario.Permisos.Contains(permiso);
        else
            return false;
    }
}
