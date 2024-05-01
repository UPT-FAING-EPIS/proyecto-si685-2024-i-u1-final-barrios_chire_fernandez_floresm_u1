using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<User> users = new List<User>();

        URLShortener shortener = URLShortener.GetInstance();
        
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
