using System;

// Clase abstracta Suscripcion que utiliza el patrón State
public abstract class Suscripcion
{
    protected IEstadoSuscripcion estado;

    public void CambiarEstado(IEstadoSuscripcion nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public string ObtenerEstado()
    {
        return estado.Estado();
    }

    public void AcortarURL(string url, Usuario usuario, AcortadorURL acortador)
    {
        estado.AcortarURL(url, usuario, acortador);
    }

    public abstract int CantidadUrlsPermitidas(); // Método abstracto para obtener la cantidad de URLs permitidas
    public abstract void ReducirCantidadUrlsPermitidas(); // Método abstracto para reducir la cantidad de URLs permitidas
}

// Clases concretas de suscripción que implementan el patrón State
public class SuscripcionFREE : Suscripcion
{
    private int CantidadUrls = 3; // Solo se pueden acortar 3 veces

    public SuscripcionFREE()
    {
        estado = new EstadoSuscripcionFREE(); // Estado inicial: Suscripción FREE
    }

    public override int CantidadUrlsPermitidas()
    {
        return CantidadUrls;
    }

    public override void ReducirCantidadUrlsPermitidas()
    {
        CantidadUrls--;
    }
}

public class SuscripcionVIP : Suscripcion
{
    private int CantidadUrls = 100; // Permitir acortar hasta 100 URLs

    public SuscripcionVIP()
    {
        estado = new EstadoSuscripcionVIP(); // Estado inicial: Suscripción VIP
    }

    public override int CantidadUrlsPermitidas()
    {
        return CantidadUrls;
    }

    public override void ReducirCantidadUrlsPermitidas()
    {
        CantidadUrls--;
    }
}

public class SuscripcionPRO : Suscripcion
{
    private int CantidadUrls = int.MaxValue; // Ilimitado

    public SuscripcionPRO()
    {
        estado = new EstadoSuscripcionPRO(); // Estado inicial: Suscripción PRO
    }

    public override int CantidadUrlsPermitidas()
    {
        return CantidadUrls;
    }

    public override void ReducirCantidadUrlsPermitidas()
    {
        // No se reduce la cantidad de URLs permitidas (ilimitado)
    }
}
