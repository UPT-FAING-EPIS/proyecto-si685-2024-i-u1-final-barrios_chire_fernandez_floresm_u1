using System;

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
