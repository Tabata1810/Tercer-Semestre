using System;
using System.Linq; // Necesario para el método .All()

namespace RegistroEstudiante
{
    // La clase Estudiante permanece sin cambios desde la última corrección.
    // Solo se incluye aquí para la completitud del código.
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string[] Telefonos { get; set; }

        public Estudiante(int id, string nombres, string apellidos, string direccion, string[]? telefonos)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Direccion = direccion;

            Telefonos = new string[3]; // Inicializa el array de teléfonos

            if (telefonos != null)
            {
                for (int i = 0; i < Math.Min(telefonos.Length, 3); i++)
                {
                    Telefonos[i] = telefonos[i] ?? string.Empty;
                }
            }
            // Asegurarse de que todos los elementos sean string.Empty si no se proporcionaron o si eran null.
            for (int i = 0; i < 3; i++)
            {
                if (Telefonos[i] == null)
                {
                    Telefonos[i] = string.Empty;
                }
            }
        }

        public void MostrarInformacion()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nombres: {Nombres}");
            Console.WriteLine($"Apellidos: {Apellidos}");
            Console.WriteLine($"Dirección: {Direccion}");
            Console.Write("Teléfonos: ");
            for (int i = 0; i < Telefonos.Length; i++)
            {
                if (!string.IsNullOrEmpty(Telefonos[i]))
                {
                    Console.Write($"{Telefonos[i]} ");
                }
            }
            Console.WriteLine("\n--------------------");
        }
    }

    // Clase Program modificada para interactuar con el usuario.
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("==== REGISTRO DE ESTUDIANTES ====");

            // Lista para almacenar múltiples estudiantes si se desea.
            // Esto es opcional, pero útil para un sistema real.
            // Para este ejemplo, solo crearemos un estudiante a la vez.
            // List<Estudiante> listaEstudiantes = new List<Estudiante>();

            bool continuarRegistrando = true;
            while (continuarRegistrando)
            {
                Console.WriteLine("\nIngrese los datos del estudiante:");

                // 1. Solicitar ID
                int id;
                Console.Write("ID del estudiante: ");
                // Intenta leer un entero; si no es válido, pide de nuevo.
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número entero para el ID.");
                    Console.Write("ID del estudiante: ");
                }

                // 2. Solicitar Nombres
                Console.Write("Nombres: ");
                string? nombres = Console.ReadLine(); // Puede ser null si el usuario solo presiona Enter
                // Asegurarse de que el nombre no sea null o vacío
                while (string.IsNullOrWhiteSpace(nombres))
                {
                    Console.WriteLine("Los nombres no pueden estar vacíos. Por favor, ingrese los nombres.");
                    Console.Write("Nombres: ");
                    nombres = Console.ReadLine();
                }

                // 3. Solicitar Apellidos
                Console.Write("Apellidos: ");
                string? apellidos = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(apellidos))
                {
                    Console.WriteLine("Los apellidos no pueden estar vacíos. Por favor, ingrese los apellidos.");
                    Console.Write("Apellidos: ");
                    apellidos = Console.ReadLine();
                }

                // 4. Solicitar Dirección
                Console.Write("Dirección: ");
                string? direccion = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(direccion))
                {
                    Console.WriteLine("La dirección no puede estar vacía. Por favor, ingrese la dirección.");
                    Console.Write("Dirección: ");
                    direccion = Console.ReadLine();
                }

                // 5. Solicitar Teléfonos (hasta 3)
                Console.WriteLine("Ingrese hasta 3 números de teléfono (presione Enter después de cada uno, o Enter vacío para terminar):");
                string?[] telefonosInput = new string?[3]; // Array temporal para la entrada del usuario
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Teléfono {i + 1}: ");
                    string? telefono = Console.ReadLine();
                    if (string.IsNullOrEmpty(telefono)) // Si el usuario presiona Enter vacío, termina la entrada de teléfonos
                    {
                        break; // Sale del bucle de teléfonos
                    }
                    telefonosInput[i] = telefono;
                }

                // Convertir el array temporal (que puede tener nulls) a un array de string no anulables
                // Filtrar los nulls y luego convertirlos a string.
                string[] telefonosFinal = telefonosInput.Where(t => t != null).Select(t => t!).ToArray();
                // El '!' (operador de nulabilidad "dammit") se usa aquí porque .Where(t => t != null)
                // garantiza que 't' no será null en el .Select(t => t!).

                // Crear la instancia del estudiante con los datos ingresados por el usuario
                Estudiante nuevoEstudiante = new Estudiante(id, nombres, apellidos, direccion, telefonosFinal);

                Console.WriteLine("\n--- Información del Estudiante Registrado ---");
                nuevoEstudiante.MostrarInformacion();

                Console.Write("\n¿Desea registrar otro estudiante? (s/n): ");
                string? respuesta = Console.ReadLine()?.ToLower();
                if (respuesta != "s")
                {
                    continuarRegistrando = false;
                }
            }

            Console.WriteLine("\nRegistro de estudiantes finalizado. ¡Hasta luego!");
            // Console.ReadKey(); // Se puede mantener si deseas que la ventana de consola no se cierre inmediatamente.
        }
    }
}