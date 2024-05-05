namespace AcortadorUrl.Domain
{
    public interface ISuscripcionStrategy
    {
        int CantidadUrlsPermitidas();
    }

    public class SuscripcionFREE : ISuscripcionStrategy
    {
        private decimal CostoMensual;
        private decimal CostoAnual;
        protected internal int CantidadUrls = 50;

        public int CantidadUrlsPermitidas()
        {
            return CantidadUrls;
        }
    }

    public class SuscripcionVIP : ISuscripcionStrategy
    {
        private decimal CostoMensual;
        private decimal CostoAnual;
        protected int CantidadUrls = 5000; // Cambiado a protected

        public int CantidadUrlsPermitidas()
        {
            return CantidadUrls;
        }
    }

    public class SuscripcionPRO : ISuscripcionStrategy
    {
        private decimal CostoMensual;
        private decimal CostoAnual;

        public int CantidadUrlsPermitidas()
        {
            return int.MaxValue;
        }
    }
}
