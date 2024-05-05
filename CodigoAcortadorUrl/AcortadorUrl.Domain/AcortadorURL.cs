namespace AcortadorUrl.Domain;
using System;
using System.Text;

public sealed class AcortadorURL
{
    private static readonly AcortadorURL instance = new AcortadorURL();
    private readonly Random random = new Random();

    private AcortadorURL() { }

    public static AcortadorURL Instance
    {
        get { return instance; }
    }

    public string Acortar(string url)
    {
        // Generar un código aleatorio único
        string codigoAleatorio = GenerarCodigoAleatorio(6);

        // Devolver la URL acortada con el código aleatorio
        return $"{url}/{codigoAleatorio}";
    }

    public string GenerarCodigoAleatorio(int longitud)
    {
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < longitud; i++)
        {
            int indice = random.Next(caracteresPermitidos.Length);
            sb.Append(caracteresPermitidos[indice]);
        }

        return sb.ToString();
    }
}

