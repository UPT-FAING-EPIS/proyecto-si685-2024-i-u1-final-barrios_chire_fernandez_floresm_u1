using System;

// Implementaciones concretas de los estados de suscripción
public class EstadoSuscripcionFREE : IEstadoSuscripcion
{
    public string Estado()
    {
        return "Suscripción FREE"; // Devuelve el estado de la suscripción FREE
    }

    public void AcortarURL(string url, Usuario usuario, AcortadorURL acortador)
    {
        // Lógica específica para acortar URL en el estado FREE
        if (usuario.Suscripcion.CantidadUrlsPermitidas() > 0)
        {
            usuario.Suscripcion.ReducirCantidadUrlsPermitidas();
            Console.WriteLine(">> URL acortada: " + acortador.AcortarURL(url, usuario));
        }
        else
        {
            Console.WriteLine("CUENTA AGOTADA: No se pueden acortar más URLs.");
        }
    }
}

public class EstadoSuscripcionVIP : IEstadoSuscripcion
{
    public string Estado()
    {
        return "Suscripción VIP"; // Devuelve el estado de la suscripción VIP
    }

    public void AcortarURL(string url, Usuario usuario, AcortadorURL acortador)
    {
        // Lógica específica para acortar URL en el estado VIP
        usuario.Suscripcion.ReducirCantidadUrlsPermitidas();
        Console.WriteLine(">> URL acortada: " + acortador.AcortarURL(url, usuario));
    }
}

public class EstadoSuscripcionPRO : IEstadoSuscripcion
{
    public string Estado()
    {
        return "Suscripción PRO"; // Devuelve el estado de la suscripción PRO
    }

    public void AcortarURL(string url, Usuario usuario, AcortadorURL acortador)
    {
        // Lógica específica para acortar URL en el estado PRO
        Console.WriteLine(">> URL acortada: " + acortador.AcortarURL(url, usuario));
    }
}
