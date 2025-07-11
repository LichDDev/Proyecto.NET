using System;
using System.Security.Cryptography;
using System.Text;
using CentroEventos.Aplicacion;

namespace CentroEventos.Repositorios;

public class RepositorioUsuario() : IRepositorioUsuario
{
    public void AgregarUsuario(Usuario u)
    {
        using var context = new CentroDeportivoContext();
        //le aplico le hash al la contraseña antes de agregar al usuario
        u.Contraseña = HashPassword(u.Contraseña != null ? u.Contraseña : "");
        context.Usuarios.Add(u);
        context.SaveChanges(); // Aquí se asigna el ID

        if (u.ID == 1)
        {
            OtorgarPermisos(u.ID, context);
            context.SaveChanges(); // Guardar los permisos asignados
        }
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
    public List<Usuario> ListarUsuarios()
    {
        using var context = new CentroDeportivoContext();
        return context.Usuarios.ToList();
    }
    public bool ModificarUsuario(Usuario u)
    {
        using var context = new CentroDeportivoContext();
        var usuarioModificar = context.Usuarios.Where(a => a.ID == u.ID).SingleOrDefault();
        if (usuarioModificar != null)
        {
            usuarioModificar.ID = u.ID;
            usuarioModificar.Nombre = u.Nombre;
            usuarioModificar.Apellido = u.Apellido;
            usuarioModificar.Email = u.Email;
            usuarioModificar.Contraseña = HashPassword(u.Contraseña ?? "");
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
    public bool ExisteEmail(string usuarioEmail)
    {
        using var context = new CentroDeportivoContext();
        var usuario = context.Usuarios.Where(u => u.Email == usuarioEmail).SingleOrDefault();
        return (usuario != null);
    }
    public bool BuscarPermiso(int usuarioID, Permiso permiso)
    {
        using var context = new CentroDeportivoContext();
        var usuario = context.Usuarios.Where(u => u.ID == usuarioID).SingleOrDefault();
        if (usuario != null)
            return context.Permitidos.Any(r => r.UsuarioId == usuario.ID && r.Permiso == permiso);
        else
            return false;
    }
    public bool VerificarContraseña(Usuario usuario)
    {
        using var context = new CentroDeportivoContext();
        //se busca al usuario por su email (idea inicial)
        var user = context.Usuarios.Where(r => r.Email == usuario.Email).SingleOrDefault();
        if (user != null)
        {
            //se aplica el hash a la contraseña ingresada
            string? contra = HashPassword(usuario.Contraseña == null ? "" : usuario.Contraseña);
            // se hace la comparacion con la contraseña que esta en la base de datos
            return user.Contraseña != null ? user.Contraseña.Equals(contra) : false;
        }
        else
            return false;
    }
    private string? HashPassword(string input)
    {
        using SHA256 sha256 = SHA256.Create();
        // Convertir a bytes
        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        // Obtener hash
        byte[] hashBytes = sha256.ComputeHash(inputBytes);
        // Convertir a string hexadecimal
        return Convert.ToHexString(hashBytes); // .NET 5+
    }
    private void OtorgarPermisos(int id, CentroDeportivoContext context)
    {
        foreach (Permiso item in Enum.GetValues(typeof(Permiso)))
        {
            context.Permitidos.Add(new Permitido(item, id));
        }
        context.SaveChanges();
    }
    public void EditarPermisos(int usuarioId, List<PermisoCheckbox> permisos)
    {
        using var context = new CentroDeportivoContext();

        var permisosActuales = context.Permitidos.Where(p => p.UsuarioId == usuarioId).ToList();

        var permisosSeleccionados = permisos.Where(p => p.Seleccionado).Select(p => p.Valor).ToHashSet();

        // puse los seleccionados que faltan
        foreach (var permiso in permisosSeleccionados)
        {
            if (!permisosActuales.Any(p => p.Permiso == permiso))
            {
                context.Permitidos.Add(new Permitido(permiso, usuarioId));
            }
        }

        // saque los permisos que no se seleccionaron
        foreach (var permisoActual in permisosActuales)
        {
            if (!permisosSeleccionados.Contains(permisoActual.Permiso))
            {
                context.Permitidos.Remove(permisoActual);
            }
        }
        context.SaveChanges();
    }
    public Usuario? BuscarUsuario(string mail)
    {
        using var context = new CentroDeportivoContext();
        var usuario = context.Usuarios.Where(u => u.Email == mail).SingleOrDefault();
        return usuario;
    }
    public List<PermisoCheckbox> ListarPermisos(int idUsuario)
    {
        using var context = new CentroDeportivoContext();
        var permisos = context.Permitidos.Where(r=>r.UsuarioId == idUsuario).Select(a=>a.Permiso).ToHashSet();
        var todosLosPermisos = Enum.GetValues(typeof(Permiso)).Cast<Permiso>()
        .Select(p => new PermisoCheckbox{Valor = p,Seleccionado = permisos.Contains(p)}).ToList();
        return todosLosPermisos;
    }
}
