using System;
using System.Collections.Generic;
using System.Linq; // Necesario para el método ToList()

// Clase para manejar el abecedario
public class Abecedario
{
    // Propiedad para almacenar las letras del abecedario
    public List<char> Letras { get; set; }

    // Constructor que inicializa la lista con el abecedario
    public Abecedario()
    {
        Letras = new List<char>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            Letras.Add(c);
        }
    }

    // Método para eliminar letras en posiciones múltiplos de 3
    public void FiltrarAbecedario()
    {
        // Crear una nueva lista para almacenar las letras que no serán eliminadas
        List<char> letrasFiltradas = new List<char>();
        for (int i = 0; i < Letras.Count; i++)
        {
            // Las posiciones son 0-indexadas, por lo tanto, (i + 1) % 3 == 0
            // significa que la posición (i+1) es múltiplo de 3.
            if ((i + 1) % 3 != 0)
            {
                letrasFiltradas.Add(Letras[i]);
            }
        }
        Letras = letrasFiltradas; // Actualizar la lista original
    }

    // Método para mostrar las letras
    public void MostrarAbecedario()
    {
        Console.WriteLine("Abecedario filtrado:");
        Console.WriteLine(string.Join(", ", Letras));
    }
}

public class Ejercicio7
{
    // Este es el método Main, el punto de entrada de tu aplicación C#.
    // Debe ser público, estático y no devolver nada (void).
    // string[] args permite pasar argumentos desde la línea de comandos, aunque no se usen aquí.
    public static void Main(string[] args)
    {
        Console.WriteLine("\n====Ejercicio 7: Abecedario Filtrado====");
        // Crear una instancia de la clase Abecedario
        Abecedario miAbecedario = new Abecedario();

        // Filtrar el abecedario
        miAbecedario.FiltrarAbecedario();

        // Mostrar el abecedario resultante
        miAbecedario.MostrarAbecedario();
        Console.WriteLine();
    }
}