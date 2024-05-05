namespace AcortadorUrl.Domain;

public abstract class Suscripcion
{
    private string Estado;
    private ISuscripcionStrategy _strategy;

    public Suscripcion(ISuscripcionStrategy strategy)
    {
        _strategy = strategy;
    }

    public int CantidadUrlsPermitidas()
    {
        return _strategy.CantidadUrlsPermitidas();
    }

    public void AdquirirSuscripcion(Suscripcion suscripcion)
    {
        // Lógica para adquirir la suscripción
    }
}
