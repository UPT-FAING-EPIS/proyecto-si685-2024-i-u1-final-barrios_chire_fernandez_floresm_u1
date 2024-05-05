namespace AcortadorUrl.Domain;

public abstract class UsuarioFactory
{
    public abstract Usuario CrearUsuario(string nombre, string password);
}

public class UsuarioFactoryImpl : UsuarioFactory
{
    public override Usuario CrearUsuario(string nombre, string password)
    {
        if (nombre == null)
        {
            return null; // Devuelve null si el nombre es nulo
        }

        return new Usuario(nombre, password);
    }
}


public class Usuario
{
    public string Nombre { get; private set; }
    public string CorreoElectronico { get; private set; }
    public string Password { get; private set; }

    public Usuario(string nombre, string password)
    {
        if (nombre == null)
        {
            throw new ArgumentNullException(nameof(nombre), "El nombre no puede ser nulo");
        }

        Nombre = nombre;
        Password = password;
    }
}



