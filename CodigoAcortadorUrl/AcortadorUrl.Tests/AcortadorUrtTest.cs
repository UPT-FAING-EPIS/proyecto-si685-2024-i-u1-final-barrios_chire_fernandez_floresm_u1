using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcortadorUrl.Domain;

namespace AcortadorUrl.Tests
{
    [TestClass]
    public class AcortadorURLTests
    {
        //TEST AcortadorUrl
        [TestMethod]
        public void Acortar_DeberiaRetornarURLAcortada()
        {
            // Arrange
            var acortador = AcortadorURL.Instance;
            string urlOriginal = "https://www.example.com";

            // Act
            string urlAcortada = acortador.Acortar(urlOriginal);

            // Assert
            Assert.IsNotNull(urlAcortada);
            Assert.IsFalse(string.IsNullOrEmpty(urlAcortada));
            Assert.IsTrue(urlAcortada.StartsWith(urlOriginal)); // La URL acortada debería comenzar con la URL original
        }

        [TestMethod]
        public void Acortar_DeberiaGenerarDiferenteURLAcortadaParaMismaURLOriginal()
        {
            // Arrange
            var acortador = AcortadorURL.Instance;
            string urlOriginal = "https://www.example.com";

            // Act
            string urlAcortada1 = acortador.Acortar(urlOriginal);
            string urlAcortada2 = acortador.Acortar(urlOriginal);

            // Assert
            Assert.AreNotEqual(urlAcortada1, urlAcortada2); // Asegura que cada URL acortada es única
        }

        [TestMethod]
        public void GenerarCodigoAleatorio_DeberiaGenerarCodigoAleatorioDeLaLongitudCorrecta()
        {
            // Arrange
            var acortador = AcortadorURL.Instance;
            int longitud = 6;

            // Act
            string codigoAleatorio = acortador.GenerarCodigoAleatorio(longitud);

            // Assert
            Assert.AreEqual(longitud, codigoAleatorio.Length); // Asegura que la longitud del código aleatorio es la esperada
        }

        [TestMethod]
        public void GenerarCodigoAleatorio_DeberiaGenerarDiferentesCodigosAleatorios()
        {
            // Arrange
            var acortador = AcortadorURL.Instance;
            int longitud = 6;

            // Act
            string codigoAleatorio1 = acortador.GenerarCodigoAleatorio(longitud);
            string codigoAleatorio2 = acortador.GenerarCodigoAleatorio(longitud);

            // Assert
            Assert.AreNotEqual(codigoAleatorio1, codigoAleatorio2); // Asegura que cada código aleatorio es único
        }

        //TEST Usuario
        [TestMethod]
        public void CrearUsuario_DeberiaRetornarInstanciaDeUsuario()
        {
            // Arrange
            UsuarioFactory factory = new UsuarioFactoryImpl();
            string nombre = "Usuario1";
            string password = "contraseña123";

            // Act
            Usuario usuario = factory.CrearUsuario(nombre, password);

            // Assert
            Assert.IsNotNull(usuario);
            Assert.AreEqual(nombre, usuario.Nombre);
            Assert.AreEqual(password, usuario.Password);
        }

        [TestMethod]
        public void CrearUsuario_DeberiaRetornarNullSiNombreEsNull()
        {
            // Arrange
            UsuarioFactory factory = new UsuarioFactoryImpl();
            string nombre = null; // Nombre nulo
            string password = "contraseña123";

            // Act
            Usuario usuario = factory.CrearUsuario(nombre, password);

            // Assert
            Assert.IsNull(usuario);
        }


        [TestMethod]
        public void Constructor_DeberiaInicializarNombreYPasswordCorrectamente()
        {
            // Arrange
            string nombre = "Usuario2";
            string password = "password123";

            // Act
            Usuario usuario = new Usuario(nombre, password);

            // Assert
            Assert.IsNotNull(usuario);
            Assert.AreEqual(nombre, usuario.Nombre);
            Assert.AreEqual(password, usuario.Password);
        }

        [TestMethod]
        public void Constructor_DeberiaInicializarCorreoElectronicoComoNull()
        {
            // Arrange
            string nombre = "Usuario3";
            string password = "password456";

            // Act
            Usuario usuario = new Usuario(nombre, password);

            // Assert
            Assert.IsNotNull(usuario);
            Assert.IsNull(usuario.CorreoElectronico);
        }

        //TEST Suscripcion
        [TestMethod]
        public void CantidadUrlsPermitidas_DeberiaRetornarCantidadCorrecta()
        {
            // Arrange
            int cantidadEsperada = 100;
            var strategyMock = new SuscripcionStrategyMock(cantidadEsperada);
            Suscripcion suscripcion = new SuscripcionBasic(strategyMock);

            // Act
            int cantidadObtenida = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(cantidadEsperada, cantidadObtenida);
        }

        [TestMethod]
        public void AdquirirSuscripcion_DeberiaRealizarLogicaDeAdquisicion()
        {
            // Arrange
            var strategyMock = new SuscripcionStrategyMock(100);
            Suscripcion suscripcion = new SuscripcionBasic(strategyMock);
            Suscripcion suscripcionAdquirida = new SuscripcionBasic(strategyMock);

            // Act
            suscripcion.AdquirirSuscripcion(suscripcionAdquirida);

            // Assert
            // Aquí podrías realizar alguna aserción adicional si hay alguna lógica específica que verificar
        }

        private class SuscripcionBasic : Suscripcion
        {
            public SuscripcionBasic(ISuscripcionStrategy strategy) : base(strategy)
            {
            }
        }

        private class SuscripcionStrategyMock : ISuscripcionStrategy
        {
            private int _cantidadUrls;

            public SuscripcionStrategyMock(int cantidadUrls)
            {
                _cantidadUrls = cantidadUrls;
            }

            public int CantidadUrlsPermitidas()
            {
                return _cantidadUrls;
            }
        }

        //TiposSuscripcion
        [TestMethod]
        public void CantidadUrlsPermitidas_DeberiaRetornarCantidadCorrectaParaSuscripcionFREE()
        {
            // Arrange
            SuscripcionFREE suscripcion = new SuscripcionFREE();

            // Act
            int cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(50, cantidadUrls);
        }

        [TestMethod]
        public void CantidadUrlsPermitidas_DeberiaRetornarCantidadCorrectaParaSuscripcionVIP()
        {
            // Arrange
            SuscripcionVIP suscripcion = new SuscripcionVIP();

            // Act
            int cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(5000, cantidadUrls);
        }

        [TestMethod]
        public void CantidadUrlsPermitidas_DeberiaRetornarCantidadCorrectaParaSuscripcionPRO()
        {
            // Arrange
            SuscripcionPRO suscripcion = new SuscripcionPRO();

            // Act
            int cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(int.MaxValue, cantidadUrls);
        }

        //TEST DetalleUrl
        [TestMethod]
        public void Update_DeberiaActualizarURLOriginal()
        {
            // Arrange
            string originalURL = "https://www.ejemplo.com";
            DetalleURL detalleURL = new DetalleURL(originalURL);

            // Act
            detalleURL.Update();

            // Assert
            Assert.AreEqual("https://www.nuevourl.com", detalleURL.OriginalURL);
        }

        [TestMethod]
        public void Update_DeberiaActualizarFechaDeModificacion()
        {
            // Arrange
            string originalURL = "https://www.ejemplo.com";
            DetalleURL detalleURL = new DetalleURL(originalURL);
            DateTime fechaCreacionAntesUpdate = detalleURL.FechaCreacion;

            // Act
            detalleURL.Update();

            // Assert
            Assert.AreNotEqual(fechaCreacionAntesUpdate, detalleURL.FechaCreacion);
        }

        //TEST UsuarioSuscripccion
        [TestMethod]
        public void RenovarSuscripcion_DeberiaActualizarFechasCorrectamente()
        {
            // Arrange
            var usuarioSuscripcion = new UsuarioSuscripcion();

            // Act
            usuarioSuscripcion.RenovarSuscripcion();

            // Assert
            Assert.IsTrue(usuarioSuscripcion.FechaInicio <= DateTime.Now);
            Assert.AreEqual(usuarioSuscripcion.FechaFin, usuarioSuscripcion.FechaInicio.AddYears(1));
        }

        [TestMethod]
        public void CancelarSuscripcion_DeberiaActualizarFechaFin()
        {
            // Arrange
            var usuarioSuscripcion = new UsuarioSuscripcion();
            var fechaInicial = usuarioSuscripcion.FechaFin; // Guardamos la fecha de inicio

            // Act
            usuarioSuscripcion.CancelarSuscripcion();

            // Assert
            Assert.IsTrue(usuarioSuscripcion.FechaFin > fechaInicial); // Verificamos que la fecha de fin haya sido actualizada
        }

        [TestMethod]
        public void Notify_DeberiaNotificarTodosLosDetallesURL()
        {
            // Arrange
            var usuarioSuscripcion = new UsuarioSuscripcion();
            var detalle1 = new DetalleURL("https://www.example.com");
            var detalle2 = new DetalleURL("https://www.example.com");
            usuarioSuscripcion.Attach(detalle1);
            usuarioSuscripcion.Attach(detalle2);

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // Act
            usuarioSuscripcion.Notify();

            // Assert
            StringAssert.Contains(stringWriter.ToString(), detalle1.OriginalURL);
            StringAssert.Contains(stringWriter.ToString(), detalle2.OriginalURL);
        }
    }
}











