using System;
using System.Collections.Generic;

namespace Vacunacion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conjunto total de ciudadanos
            HashSet<string> todos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
                todos.Add($"Ciudadano {i}");

            // Conjunto de ciudadanos vacunados con Pfizer (1 al 75)
            HashSet<string> pfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
                pfizer.Add($"Ciudadano {i}");

            // Conjunto de ciudadanos vacunados con AstraZeneca (51 al 125)
            HashSet<string> astrazeneca = new HashSet<string>();
            for (int i = 51; i <= 125; i++)
                astrazeneca.Add($"Ciudadano {i}");

            HashSet<string> noVacunados = new HashSet<string>(todos);
            noVacunados.ExceptWith(pfizer);
            noVacunados.ExceptWith(astrazeneca);

            HashSet<string> ambasDosis = new HashSet<string>(pfizer);
            ambasDosis.IntersectWith(astrazeneca);

            HashSet<string> soloPfizer = new HashSet<string>(pfizer);
            soloPfizer.ExceptWith(astrazeneca);

            HashSet<string> soloAstrazeneca = new HashSet<string>(astrazeneca);
            soloAstrazeneca.ExceptWith(pfizer);

            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("SISTEMA DE INFORMACIÓN DE VACUNACIÓN\n");
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("1. Listado de ciudadanos que NO se han vacunado");
                Console.WriteLine("2. Listado de ciudadanos con ambas dosis");
                Console.WriteLine("3. Listado de ciudadanos con solo Pfizer");
                Console.WriteLine("4. Listado de ciudadanos con solo AstraZeneca");
                Console.WriteLine("5. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                Console.Clear();
                switch (opcion)
                {
                    case 1:
                        MostrarListado("Ciudadanos que NO se han vacunado", noVacunados);
                        break;
                    case 2:
                        MostrarListado("Ciudadanos con ambas dosis", ambasDosis);
                        break;
                    case 3:
                        MostrarListado("Ciudadanos con solo Pfizer", soloPfizer);
                        break;
                    case 4:
                        MostrarListado("Ciudadanos con solo AstraZeneca", soloAstrazeneca);
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Intente nuevamente.");
                        break;
                }

                if (opcion != 5)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 5);
        }

        static void MostrarListado(string titulo, HashSet<string> lista)
        {
            Console.WriteLine($"{titulo} (Total: {lista.Count})\n");
            foreach (var ciudadano in lista)
                Console.WriteLine($" - {ciudadano}");
        }
    }
}