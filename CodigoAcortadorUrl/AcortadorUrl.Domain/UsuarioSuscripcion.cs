namespace AcortadorUrl.Domain;
    public class UsuarioSuscripcion
    {
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        private Suscripcion Suscripcion;
        private string Usuario;

        private List<DetalleURL> detalles = new List<DetalleURL>();

        public void RenovarSuscripcion()
        {
            // Simplemente actualizamos la fecha de inicio y fin
            FechaInicio = DateTime.Now;
            FechaFin = FechaInicio.AddYears(1);
        }

        public void CancelarSuscripcion()
        {
            // Simplemente establecemos la fecha de fin como la fecha actual
            FechaFin = DateTime.Now;
        }

        public void Attach(DetalleURL detalle)
        {
            detalles.Add(detalle);
        }

        public void Detach(DetalleURL detalle)
        {
            detalles.Remove(detalle);
        }

        public void Notify()
        {
            foreach (var detalle in detalles)
            {
                // Simplemente imprimimos un mensaje de notificación
                Console.WriteLine($"Notificando al detalle de URL: {detalle.OriginalURL}");
            }
        }
    }
