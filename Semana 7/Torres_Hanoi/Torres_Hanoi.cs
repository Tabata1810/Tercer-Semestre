using System;
using System.Collections.Generic;

public class TowersOfHanoi
{
    // Se utilizan pilas para representar cada torre.
    // Esto es más para visualización y comprensión del estado actual de los discos en cada torre.
    private static Stack<int> sourceTower = new Stack<int>();
    private static Stack<int> auxiliaryTower = new Stack<int>();
    private static Stack<int> destinationTower = new Stack<int>();

    public static void Main(string[] args)
    {
        Console.WriteLine("\n=== Resolución del Problema de las Torres de Hanói ===");
        Console.Write("Ingrese el número de discos: ");
        // Asegúrate de que Console.ReadLine() no sea null antes de intentar analizarlo.
        string? input = Console.ReadLine();
        if (input != null && int.TryParse(input, out int numDisks) && numDisks > 0)
        {
            // Inicializa la torre de origen con los discos en orden descendente.
            for (int i = numDisks; i >= 1; i--)
            {
                sourceTower.Push(i);
            }

            Console.WriteLine($"\nEstado inicial con {numDisks} discos:");
            PrintTowers();

            // Llama a la función recursiva para resolver las Torres de Hanói.
            SolveHanoi(numDisks, "Torre Origen", "Torre Auxiliar", "Torre Destino");

            Console.WriteLine("\n¡Torres de Hanói resueltas!");
            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Número de discos inválido. Por favor, ingrese un número entero positivo.");
        }
    }

    /// <summary>
    /// Resuelve el problema de las Torres de Hanói de forma recursiva.
    /// </summary>
    /// <param name="n">Número de discos a mover.</param>
    /// <param name="source">Nombre de la torre de origen.</param>
    /// <param name="auxiliary">Nombre de la torre auxiliar.</param>
    /// <param name="destination">Nombre de la torre de destino.</param>
    public static void SolveHanoi(int n, string source, string auxiliary, string destination)
    {
        // Caso base: si solo hay un disco, moverlo directamente de origen a destino.
        if (n == 1)
        {
            MoveDisk(1, source, destination);
            PrintTowers(); // Imprime el estado de las torres después de cada movimiento.
            return;
        }

        // Paso 1: Mover n-1 discos de la torre de origen a la torre auxiliar.
        SolveHanoi(n - 1, source, destination, auxiliary);

        // Paso 2: Mover el disco más grande (el disco n) de la torre de origen a la torre de destino.
        MoveDisk(n, source, destination);
        PrintTowers(); // Imprime el estado de las torres después de cada movimiento.

        // Paso 3: Mover los n-1 discos restantes de la torre auxiliar a la torre de destino.
        SolveHanoi(n - 1, auxiliary, source, destination);
    }

    /// <summary>
    /// Simula el movimiento de un disco entre dos torres.
    /// Actualiza el estado de las pilas que representan las torres.
    /// </summary>
    /// <param name="diskNum">El número del disco que se mueve.</param>
    /// <param name="sourceName">Nombre de la torre de origen.</param>
    /// <param name="destinationName">Nombre de la torre de destino.</param>
    private static void MoveDisk(int diskNum, string sourceName, string destinationName)
    {
        Console.WriteLine($"\nMoviendo disco {diskNum} de {sourceName} a {destinationName}");

        Stack<int> source = GetTower(sourceName);
        Stack<int> destination = GetTower(destinationName);

        // Se verifica si la torre de origen tiene discos.
        if (source.Count > 0)
        {
            int disk = source.Pop();
            destination.Push(disk);
        }
    }

    /// <summary>
    /// Obtiene la pila (torre) correspondiente al nombre dado.
    /// </summary>
    /// <param name="towerName">El nombre de la torre.</param>
    /// <returns>La pila que representa la torre.</returns>
    private static Stack<int> GetTower(string towerName)
    {
        switch (towerName)
        {
            case "Torre Origen": return sourceTower;
            case "Torre Auxiliar": return auxiliaryTower;
            case "Torre Destino": return destinationTower;
            default:
                // Lanza una excepción en lugar de devolver null.
                throw new ArgumentException($"Nombre de torre inválido: '{towerName}'.", nameof(towerName));
        }
    }

    /// <summary>
    /// Imprime el estado actual de las tres torres.
    /// </summary>
    private static void PrintTowers()
    {
        Console.WriteLine("=== Estado Actual de las Torres ===");
        Console.WriteLine($"Torre Origen: {string.Join(", ", sourceTower.ToArray())}");
        Console.WriteLine($"Torre Auxiliar: {string.Join(", ", auxiliaryTower.ToArray())}");
        Console.WriteLine($"Torre Destino: {string.Join(", ", destinationTower.ToArray())}");
        Console.WriteLine("---------------------------------");
    }
}