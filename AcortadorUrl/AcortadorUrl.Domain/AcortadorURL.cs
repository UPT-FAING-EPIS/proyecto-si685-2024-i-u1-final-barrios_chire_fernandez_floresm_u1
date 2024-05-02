using System;

// Clase AcortadorURL implementando el patrón Singleton
public class AcortadorURL
{
    private static AcortadorURL instance = new AcortadorURL()!;


    private AcortadorURL()
    {
        // Constructor privado para implementar el patrón Singleton
    }

    public static AcortadorURL GetInstance()
    {
        if (instance == null)
        {
            instance = new AcortadorURL();
        }
        return instance;
    }

    public string AcortarURL(string url, Usuario usuario)
    {
        // Lógica para acortar URL
        Random rand = new Random();
        const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        char[] codigo = new char[6];
        for (int i = 0; i < codigo.Length; i++)
        {
            codigo[i] = caracteresPermitidos[rand.Next(caracteresPermitidos.Length)];
        }
        return new string(codigo);
    }
}
