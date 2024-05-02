using System;

// Clase Usuario que utiliza el patrón State
public class Usuario
{
    public string Nombre { get; private set; }
    public string CorreoElectronico { get; private set; }
    public string Password { get; private set; }
    public Suscripcion Suscripcion { get; set; }

    public Usuario(string nombre, string correoElectronico, string password)
    {
        Nombre = nombre;
        CorreoElectronico = correoElectronico;
        Password = password;
        Suscripcion = new SuscripcionFREE(); // Asignar una suscripción FREE por defecto
    }

    public void RenovarSuscripcion(Suscripcion nuevaSuscripcion)
    {
        Suscripcion = nuevaSuscripcion;
    }

    public void CancelarSuscripcion()
    {
        Suscripcion = null;
    }

    public void AcortarURL(string url, AcortadorURL acortador)
    {
        Suscripcion.AcortarURL(url, this, acortador);
    }
}
