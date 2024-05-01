using System;
using System.Collections.Generic;

public class URLShortener
{
    private static URLShortener? instance = null;
    private static Dictionary<string, string> urlMappings = new Dictionary<string, string>(); // Diccionario estático para compartir entre todas las instancias

    private URLShortener()
    {
        // No necesitas inicializar urlMappings aquí
    }

    public static URLShortener GetInstance()
    {
        if (instance == null)
        {
            instance = new URLShortener();
        }
        return instance!;
    }

    public string ShortenURL(string longURL)
    {
        string shortCode = GenerateShortCode();
        urlMappings.Add(shortCode, longURL);
        return shortCode;
    }

    public string ExpandURL(string shortCode)
    {
        if (urlMappings.ContainsKey(shortCode))
        {
            return urlMappings[shortCode]; // Retorna la URL larga correspondiente al código corto
        }
        else
        {
            return "URL not found";
        }
    }

    private string GenerateShortCode()
    {
        // Lógica para generar un código corto único
        // Aquí puedes implementar cualquier algoritmo que prefieras
        return Guid.NewGuid().ToString().Substring(0, 6);
    }
}
