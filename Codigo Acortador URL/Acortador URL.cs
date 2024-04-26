using System;
using System.Collections.Generic;

// Patrón creacional: Singleton
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

// Patrón de comportamiento: Strategy
public interface ILogger
{
    void Log(string message);
}

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

public enum SubscriptionType
{
    Free,
    Pro
}

public interface IUserState
{
    void ShortenURL(User user, URLShortener shortener, string longURL);
}

public class FreeUserState : IUserState
{
    public void ShortenURL(User user, URLShortener shortener, string longURL)
    {
        if (user.RemainingShortens > 0)
        {
            string shortURL = shortener.ShortenURL(longURL);
            Console.WriteLine($"Shortened URL: https://ShortenedURL/{shortURL}");
            user.RemainingShortens--;
        }
        else
        {
            Console.WriteLine("SUSCRIPCCION FREE AGOTADA !!!");
        }
    }
}

public class ProUserState : IUserState
{
    public void ShortenURL(User user, URLShortener shortener, string longURL)
    {
        string shortURL = shortener.ShortenURL(longURL);
        Console.WriteLine($"URL ACORTADO: https://ShortenedURL/{shortURL}");
    }
}

public class User
{
    public string Username { get; }
    private string Password { get; }
    public SubscriptionType Subscription { get; }
    public int RemainingShortens { get; set; } // Para usuarios con suscripción gratuita
    public IUserState State { get; private set; }

    public User(string username, string password, SubscriptionType subscription)
    {
        Username = username;
        Password = password;
        Subscription = subscription;
        RemainingShortens = subscription == SubscriptionType.Free ? 3 : int.MaxValue; // Inicializa el número de acortamientos restantes según el tipo de suscripción
        State = subscription == SubscriptionType.Free ? (IUserState)new FreeUserState() : new ProUserState();
    }

    public bool CheckCredentials(string username, string password)
    {
        return Username == username && Password == password;
    }

    public void ShortenURL(URLShortener shortener, string longURL)
    {
        State.ShortenURL(this, shortener, longURL);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Lista de usuarios registrados
        List<User> users = new List<User>();

        URLShortener shortener = URLShortener.GetInstance();
        ILogger logger = new ConsoleLogger();

        bool loggedIn = false;
        User? currentUser = null;

        while (!loggedIn)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("          Menu:          ");
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Sign up");
            Console.WriteLine("=========================");
            Console.Write("Escoge una opcion: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write(">>> Username: ");
                    string username = Console.ReadLine();
                    Console.Write(">>> Password: ");
                    string password = Console.ReadLine();

                    // Verificar credenciales
                    foreach (var user in users)
                    {
                        if (user.CheckCredentials(username, password))
                        {
                            loggedIn = true;
                            currentUser = user;
                            break;
                        }
                    }

                    if (!loggedIn)
                    {
                        Console.WriteLine("Usuario o Contraseña invalido. Intentalo denuevo");
                    }
                    break;
                case "2":
                    Console.Write(">>> nuevo username: ");
                    string newUsername = Console.ReadLine();
                    Console.Write(">>> nuevo password: ");
                    string newPassword = Console.ReadLine();
                    Console.WriteLine("Tipo de suscripcion ?:");
                    Console.WriteLine("1. Free");
                    Console.WriteLine("2. Pro");
                    Console.Write("Escoge una oppcion: ");
                    string subscriptionChoice = Console.ReadLine();
                    SubscriptionType subscription = subscriptionChoice == "2" ? SubscriptionType.Pro : SubscriptionType.Free;
                    users.Add(new User(newUsername, newPassword, subscription));
                    Console.WriteLine("CUENTA CREADA EXITOSAMENTE");
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("=========================");
            Console.WriteLine("        OPCCIONES        ");
            Console.WriteLine("1. Shorten URL");
            Console.WriteLine("2. Exit");
            Console.WriteLine("=========================");
            Console.Write("Escoge una opcion: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (currentUser != null)
                    {
                        Console.Write(">>> URL: ");
                        string longURL = Console.ReadLine();
                        currentUser.ShortenURL(shortener, longURL);
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                    }
                    break;
                case "2":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opcion invalida");
                    break;
            }
        }
    }
}
