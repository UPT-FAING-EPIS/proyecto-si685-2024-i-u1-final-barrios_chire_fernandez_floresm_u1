using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        AcortadorURL acortador = AcortadorURL.GetInstance();
        Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();

        int opcion;
        Usuario? usuarioActual = null;

        do
        {
            Console.WriteLine("====================");
            Console.WriteLine("        MENÚ        ");
            if (usuarioActual == null)
            {
                Console.WriteLine("1. Iniciar sesión");
                Console.WriteLine("2. Crear cuenta");
                
            }
            else
            {
                Console.WriteLine("1. Acortar URL");
                Console.WriteLine("2. Renovar suscripción");
                Console.WriteLine("3. Cancelar suscripción");
                Console.WriteLine("4. Cerrar sesión");
            }
            Console.WriteLine("0. Salir");
            Console.WriteLine("====================");
            Console.Write("Ingrese su opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1 when usuarioActual == null:
                    Console.Write(">>> Ingrese su usuario: ");
                    string nombreUsuario = Console.ReadLine();
                    Console.Write(">>> Ingrese su contraseña: ");
                    string password = Console.ReadLine();

                    if (usuarios.ContainsKey(nombreUsuario) && usuarios[nombreUsuario].Password == password)
                    {
                        usuarioActual = usuarios[nombreUsuario];
                        Console.WriteLine("Inicio de sesión exitoso.....");
                    }
                    else
                    {
                        Console.WriteLine("Usuario o contraseña incorrectos.");
                    }
                    break;
                case 2 when usuarioActual == null:
                    Console.WriteLine(".......Creando Cuenta");
                    Console.Write(">> Ingrese su Usuario: ");
                    string nombre = Console.ReadLine();
                    Console.Write(">> Ingrese su Correo Electrónico: ");
                    string correo = Console.ReadLine();
                    Console.Write(">> Ingrese su Contraseña: ");
                    string contrasena = Console.ReadLine();
                    Console.WriteLine("Seleccione el tipo de suscripción:");
                    Console.WriteLine("1. Suscripción FREE");
                    Console.WriteLine("2. Suscripción VIP");
                    Console.WriteLine("3. Suscripción PRO");
                    Console.Write("Ingrese su opción: ");
                    int tipoSuscripcion = Convert.ToInt32(Console.ReadLine());
                    Suscripcion suscripcionSeleccionada;
                    switch (tipoSuscripcion)
                    {
                        case 1:
                            suscripcionSeleccionada = new SuscripcionFREE();
                            break;
                        case 2:
                            suscripcionSeleccionada = new SuscripcionVIP();
                            break;
                        case 3:
                            suscripcionSeleccionada = new SuscripcionPRO();
                            break;
                        default:
                            Console.WriteLine("Opción no válida, se establecerá la suscripción FREE por defecto.");
                            suscripcionSeleccionada = new SuscripcionFREE();
                            break;
                    }
                    Usuario nuevoUsuario = new Usuario(nombre, correo, contrasena)
                    {
                        Suscripcion = suscripcionSeleccionada
                    };
                    usuarios.Add(nombre, nuevoUsuario);
                    Console.WriteLine($"Cuenta creada con éxito. Tipo de suscripción: {suscripcionSeleccionada.ObtenerEstado()}");
                    break;
                case 1 when usuarioActual != null:
                    Console.WriteLine("Ingrese la URL que desea acortar:");
                    string url = Console.ReadLine();
                    usuarioActual.AcortarURL(url, acortador);
                    break;
                case 2 when usuarioActual != null:
                    // Implementación de renovar suscripción
                    break;
                case 3 when usuarioActual != null:
                    // Implementación de cancelar suscripción
                    break;
                case 4 when usuarioActual != null:
                    usuarioActual = null;
                    Console.WriteLine("Sesión cerrada.");
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        } while (opcion != 0);
    }
}
