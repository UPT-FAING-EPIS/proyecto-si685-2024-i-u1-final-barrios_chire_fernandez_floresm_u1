namespace AcortadorUrl.Domain;
    public class DetalleURL
    {
        public DateTime FechaCreacion { get; private set; }
        public string OriginalURL { get; private set; }
        public string AcortadoURL { get; private set; }
        public DateTime EstadoValidez { get; private set; }

        public DetalleURL(string originalURL)
        {
            FechaCreacion = DateTime.Now;
            OriginalURL = originalURL;
            AcortadoURL = "";
            EstadoValidez = DateTime.Now.AddDays(7);
        }

        public void Update()
        {
            // Lógica para manejar actualizaciones de URL
            OriginalURL = "https://www.nuevourl.com";
            FechaCreacion = DateTime.Now; // Actualizar la fecha de creación
        }
    }

