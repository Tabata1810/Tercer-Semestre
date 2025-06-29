using System;
using System.Collections.Generic;
using System.Linq; // Necesario para el método OrderBy

// Clase para representar la Lotería
public class Loteria
{
    // Propiedad para almacenar los números ganadores
    public List<int> NumerosGanadores { get; set; }

    // Constructor
    public Loteria()
    {
        NumerosGanadores = new List<int>();
    }

    // Método para pedir al usuario los números
    public void PedirNumeros()
    {
        Console.WriteLine("Ingresa los números ganadores de la lotería primitiva(separados por espacios):");
        // Manejar el posible valor nulo de Console.ReadLine()
        string input = Console.ReadLine() ?? string.Empty;
        string[] numerosTexto = input.Split(' ', StringSplitOptions.RemoveEmptyEntries); // Eliminar entradas vacías

        foreach (var numTexto in numerosTexto)
        {
            if (int.TryParse(numTexto, out int numero))
            {
                NumerosGanadores.Add(numero);
            }
            else
            {
                Console.WriteLine($"'{numTexto}' no es un número válido y será ignorado.");
            }
        }
    }

    // Método para mostrar los números ordenados
    public void MostrarNumerosOrdenados()
    {
        Console.WriteLine("Números ganadores ordenados de menor a mayor:");
        // Ordenar la lista utilizando LINQ
        var numerosOrdenados = NumerosGanadores.OrderBy(n => n).ToList();
        foreach (var numero in numerosOrdenados)
        {
            Console.Write($"{numero} ");
        }
        Console.WriteLine();
    }
}

public class Ejercicio4
{
    // Este es el método Main, el punto de entrada de tu aplicación
    public static void Main(string[] args)
    {
        Console.WriteLine("\n+++Ejercicio 4: Números Ganadores de la Lotería+++");
        // Crear una instancia de la clase Loteria
        Loteria miLoteria = new Loteria();

        // Pedir los números al usuario
        miLoteria.PedirNumeros();

        // Mostrar los números ordenados
        miLoteria.MostrarNumerosOrdenados();
        Console.WriteLine();
    }
}