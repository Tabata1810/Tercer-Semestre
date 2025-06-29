using System;
using System.Collections.Generic;
using System.Linq; // Necesario para el método Reverse (aunque List<T>.Reverse() también funciona)

// Clase para manejar una secuencia numérica
public class SecuenciaNumerica
{
    // Propiedad para almacenar los números
    public List<int> Numeros { get; set; }

    // Constructor que inicializa la lista con números del 1 al 10
    public SecuenciaNumerica()
    {
        Numeros = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            Numeros.Add(i);
        }
    }

    // Método para mostrar los números en orden inverso
    public void MostrarNumerosInversos()
    {
        Console.WriteLine("Números en orden inverso:");
        // Revertir la lista
        Numeros.Reverse();
        Console.WriteLine(string.Join(", ", Numeros)); // Unir los números con comas
    }
}

public class Ejercicio5
{
    // Este es el método Main, el punto de entrada del programa.
    public static void Main(string[] args) // Cambiado de Run a Main
    {
        Console.WriteLine("\n---Ejercicio 5: Números Inversos---");
        // Crear una instancia de la clase SecuenciaNumerica
        SecuenciaNumerica secuencia = new SecuenciaNumerica();

        // Mostrar los números en orden inverso
        secuencia.MostrarNumerosInversos();
        Console.WriteLine();
    }
}