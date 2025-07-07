using System;
using System.Collections.Generic; // Necesario para LinkedList

public class Ejercicio5
{
    // Función para verificar si un número es primo
    public static bool IsPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i * i <= number; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    // Función para verificar si un número es Armstrong
    public static bool IsArmstrong(int number)
    {
        int originalNumber = number;
        int sum = 0;
        int numberOfDigits = number.ToString().Length;

        int tempNumber = number;
        while (tempNumber > 0)
        {
            int remainder = tempNumber % 10;
            sum += (int)Math.Pow(remainder, numberOfDigits);
            tempNumber /= 10;
        }
        return originalNumber == sum;
    }

    // Nuevo método para mostrar los elementos de LinkedList
    public static void DisplayList(LinkedList<int> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }
        foreach (int item in list)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    // Este es el punto de entrada de tu aplicación
    public static void Main(string[] args) // Renombrado de Run() a Main()
    {
        LinkedList<int> primeNumbersList = new LinkedList<int>();
        LinkedList<int> armstrongNumbersList = new LinkedList<int>();

        Console.WriteLine("--- Ejercicio 5: Listas de Números Primos y Armstrong ---");

        // Simulación de carga de datos
        Console.WriteLine("\nIngrese números enteros (0 para terminar):");
        int input;
        do
        {
            Console.Write("Número: ");
            if (int.TryParse(Console.ReadLine(), out input) && input != 0)
            {
                if (IsPrime(input))
                {
                    primeNumbersList.AddLast(input);
                    Console.WriteLine($"'{input}' agregado a la lista de números primos.");
                }
                if (IsArmstrong(input))
                {
                    armstrongNumbersList.AddFirst(input);
                    Console.WriteLine($"'{input}' agregado a la lista de números Armstrong.");
                }
                if (!IsPrime(input) && !IsArmstrong(input))
                {
                    Console.WriteLine($"'{input}' no es primo ni Armstrong.");
                }
            }
            else if (input != 0)
            {
                Console.WriteLine("Entrada inválida. Por favor ingrese un número entero.");
            }
        } while (input != 0);

        Console.WriteLine("\n--- Resultados ---");

        // a. El número de datos insertados en cada lista.
        Console.WriteLine($"\nNúmero de datos en la lista de Primos: {primeNumbersList.Count}");
        Console.WriteLine($"Número de datos en la lista de Armstrong: {armstrongNumbersList.Count}");

        // b. Mostrar un mensaje indicando la lista que contiene más elementos.
        if (primeNumbersList.Count > armstrongNumbersList.Count)
        {
            Console.WriteLine("La lista de números primos contiene más elementos.");
        }
        else if (armstrongNumbersList.Count > primeNumbersList.Count)
        {
            Console.WriteLine("La lista de números Armstrong contiene más elementos.");
        }
        else
        {
            Console.WriteLine("Ambas listas tienen la misma cantidad de elementos.");
        }

        // c. Mostrar todos los datos insertados en las listas.
        Console.Write("\nNúmeros Primos en la lista: ");
        DisplayList(primeNumbersList); // Llama a tu método DisplayList personalizado

        Console.Write("Números Armstrong en la lista: ");
        DisplayList(armstrongNumbersList); // Llama a tu método DisplayList personalizado
    }
}
