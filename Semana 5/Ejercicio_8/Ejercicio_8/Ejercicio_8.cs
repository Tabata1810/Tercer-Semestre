using System;
using System.Linq; // Necesario para el método Where()

// Clase para verificar si una palabra es un palíndromo
public class VerificadorPalindromo
{
    // Propiedad para almacenar la palabra
    public string Palabra { get; set; }

    // Constructor
    public VerificadorPalindromo(string palabra)
    {
        Palabra = palabra;
    }

    // Método para verificar si la palabra es un palíndromo
    public bool EsPalindromo()
    {
        // Convertir la palabra a minúsculas y eliminar caracteres no alfanuméricos
        string palabraLimpia = new string(Palabra.ToLower().Where(char.IsLetterOrDigit).ToArray());

        // Invertir la palabra
        char[] arrayPalabra = palabraLimpia.ToCharArray();
        Array.Reverse(arrayPalabra);
        string palabraInvertida = new string(arrayPalabra);

        // Comparar la palabra original limpia con la invertida
        return palabraLimpia.Equals(palabraInvertida);
    }

    // Método para mostrar el resultado
    public void MostrarResultado()
    {
        if (EsPalindromo())
        {
            Console.WriteLine($"'{Palabra}' es un palíndromo.");
        }
        else
        {
            Console.WriteLine($"'{Palabra}' no es un palíndromo. Prueba con otra.");
        }
    }
}

public class Ejercicio8
{
    // Este es el método Main, el punto de entrada de la aplicación.
    public static void Main(string[] args)
    {
        Run(); 
    }

    public static void Run()
    {
        Console.WriteLine("\n-_-_-Ejercicio 8: Palíndromo-_-_-");
        
        bool continuarVerificando = true; // Bandera principal para controlar el bucle de la aplicación

        while (continuarVerificando)
        {
            bool esPalindromoValido = false; // Bandera para controlar el bucle de entrada de palabra
            string palabraInput;

            do // Bucle para asegurar que el usuario ingrese un palíndromo
            {
                Console.Write("Ingresa una palabra para verificar si es un palíndromo: ");
                palabraInput = Console.ReadLine() ?? ""; 

                VerificadorPalindromo verificador = new VerificadorPalindromo(palabraInput);

                verificador.MostrarResultado();
                
                esPalindromoValido = verificador.EsPalindromo(); // Actualiza la bandera para salir de este bucle si es palíndromo

                Console.WriteLine(); // Salto de línea para mejor legibilidad entre intentos
                
            } while (!esPalindromoValido); // El bucle interno continúa mientras la palabra NO sea un palíndromo

            // Si llegamos aquí, el usuario ingresó un palíndromo válido.
            Console.Write("¿Quieres verificar otra palabra? (sí/no): ");
            string respuesta = Console.ReadLine()?.ToLower() ?? ""; // Lee la respuesta y la convierte a minúsculas
            
            // Si la respuesta no es "sí", se establece 'continuarVerificando' en false para salir del bucle principal
            if (respuesta != "si" && respuesta != "sí") 
            {
                continuarVerificando = false;
            }
            Console.WriteLine(); // Salto de línea para separar la próxima interacción
        }

        Console.WriteLine("¡Gracias por usar el verificador de palíndromos!");
    }
}