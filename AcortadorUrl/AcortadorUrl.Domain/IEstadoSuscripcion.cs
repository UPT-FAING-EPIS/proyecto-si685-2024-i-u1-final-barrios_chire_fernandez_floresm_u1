using System;

// Interfaz que define el comportamiento de los estados de suscripción
public interface IEstadoSuscripcion
{
    string Estado(); // Método para obtener el estado actual
    void AcortarURL(string url, Usuario usuario, AcortadorURL acortador); // Método para acortar una URL
}
