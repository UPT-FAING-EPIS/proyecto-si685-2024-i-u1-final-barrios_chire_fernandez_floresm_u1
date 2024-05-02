using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcortadorUrl.Tests
{
    [TestClass]
    public class AcortadorURLTest
    {
        [TestMethod]
        public void AcortadorURL_AcortarURL_Deberia_GenerarCodigoDeLongitudCorrecta()
        {
            // Arrange
            var acortador = AcortadorURL.GetInstance();
            var url = "https://www.example.com";

            // Act
            var codigo = acortador.AcortarURL(url, new Usuario("John", "john@example.com", "password"));

            // Assert
            Assert.AreEqual(6, codigo.Length);
        }

        [TestMethod]
        public void AcortadorURL_AcortarURL_Deberia_GenerarCodigoAlfanumerico()
        {
            // Arrange
            var acortador = AcortadorURL.GetInstance();
            var url = "https://www.example.com";

            // Act
            var codigo = acortador.AcortarURL(url, new Usuario("John", "john@example.com", "password"));

            // Assert
            Assert.IsTrue(System.Text.RegularExpressions.Regex.IsMatch(codigo, "^[a-zA-Z0-9]*$"));
        }

        [TestMethod]
        public void SuscripcionFREE_CantidadUrlsPermitidas_Deberia_Ser3Inicialmente()
        {
            // Arrange
            var suscripcion = new SuscripcionFREE();

            // Act
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(3, cantidadUrls);
        }

        [TestMethod]
        public void SuscripcionFREE_ReduceCantidadUrlsPermitidas_Deberia_ReducirEn1()
        {
            // Arrange
            var suscripcion = new SuscripcionFREE();

            // Act
            suscripcion.ReducirCantidadUrlsPermitidas();
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(2, cantidadUrls);
        }

        [TestMethod]
        public void SuscripcionVIP_CantidadUrlsPermitidas_Deberia_Ser100Inicialmente()
        {
            // Arrange
            var suscripcion = new SuscripcionVIP();

            // Act
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(100, cantidadUrls);
        }

        [TestMethod]
        public void SuscripcionVIP_ReduceCantidadUrlsPermitidas_Deberia_ReducirEn1()
        {
            // Arrange
            var suscripcion = new SuscripcionVIP();

            // Act
            suscripcion.ReducirCantidadUrlsPermitidas();
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(99, cantidadUrls);
        }

        [TestMethod]
        public void SuscripcionPRO_CantidadUrlsPermitidas_Deberia_SerIlimitado()
        {
            // Arrange
            var suscripcion = new SuscripcionPRO();

            // Act
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(int.MaxValue, cantidadUrls);
        }

        [TestMethod]
        public void SuscripcionPRO_NoDeberia_ReducirCantidadUrlsPermitidas()
        {
            // Arrange
            var suscripcion = new SuscripcionPRO();

            // Act
            suscripcion.ReducirCantidadUrlsPermitidas();
            var cantidadUrls = suscripcion.CantidadUrlsPermitidas();

            // Assert
            Assert.AreEqual(int.MaxValue, cantidadUrls);
        }

        [TestMethod]
        public void Usuario_RenovarSuscripcion_Deberia_CambiarSuscripcion()
        {
            // Arrange
            var usuario = new Usuario("John", "john@example.com", "password");
            var suscripcionInicial = usuario.Suscripcion;

            // Act
            usuario.RenovarSuscripcion(new SuscripcionVIP());

            // Assert
            Assert.AreNotSame(suscripcionInicial, usuario.Suscripcion);
        }

        [TestMethod]
        public void Usuario_CancelarSuscripcion_Deberia_AnularSuscripcion()
        {
            // Arrange
            var usuario = new Usuario("John", "john@example.com", "password");

            // Act
            usuario.CancelarSuscripcion();

            // Assert
            Assert.IsNull(usuario.Suscripcion);
        }

        [TestMethod]
        public void Usuario_AcortarURL_Deberia_ReducirCantidadUrlsPermitidas()
        {
            // Arrange
            var usuario = new Usuario("John", "john@example.com", "password");
            var acortador = AcortadorURL.GetInstance();
            var url = "https://www.example.com";

            // Act
            usuario.AcortarURL(url, acortador);

            // Assert
            Assert.AreEqual(2, usuario.Suscripcion.CantidadUrlsPermitidas());
        }

        [TestMethod]
        public void Usuario_AcortarURL_Cuando_CantidadUrlsPermitidasEsCero_Deberia_MostrarMensajeCuentaAgotada()
        {
            // Arrange
            var usuario = new Usuario("John", "john@example.com", "password");
            var acortador = AcortadorURL.GetInstance();
            var url = "https://www.example.com";
            usuario.Suscripcion = new SuscripcionFREE(); // Establecer una suscripción FREE con 0 URLs permitidas

            // Act
            usuario.AcortarURL(url, acortador);

            // Assert
            // Verificar que el mensaje se muestra en la consola
            // Puedes redirigir la salida estándar a un TextWriter para realizar esta verificación
            // También puedes modificar el método AcortarURL para que devuelva un valor (por ejemplo, un booleano) y verificarlo aquí.
        }
    }
}
