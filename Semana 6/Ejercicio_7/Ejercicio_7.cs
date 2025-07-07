using System;
using System.Linq; // Para el método .Any() en las búsquedas y eliminaciones (aunque Find/Remove personalizado lo maneja)
using System.Collections.Generic; // Para IEnumerable, para hacer la LinkedList enumerable y por buenas prácticas

// Clase para representar un nodo en la lista enlazada
public class Node<T>
{
    public T Data { get; set; } // Los datos que almacena el nodo
    public Node<T>? Next { get; set; } // Referencia al siguiente nodo en la lista (puede ser nulo)

    public Node(T data)
    {
        Data = data;
        Next = null; // Inicialmente no hay siguiente nodo
    }
}

// Clase para la lista enlazada personalizada
public class LinkedList<T> : IEnumerable<T>
{
    public Node<T>? Head { get; private set; } // La cabeza de la lista (puede ser nula si la lista está vacía)
    public int Count { get; private set; } // Contador de elementos en la lista

    public LinkedList()
    {
        Head = null; // La lista está vacía al inicio
        Count = 0;
    }

    // Método para añadir un nuevo elemento al final de la lista
    public void AddLast(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode; // Si la lista está vacía, el nuevo nodo es la cabeza
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next; // Recorre hasta el último nodo
            }
            current.Next = newNode; // El último nodo apunta al nuevo nodo
        }
        Count++; // Incrementa el contador de elementos
    }

    // Método para buscar un nodo basándose en un predicado (función de condición)
    // Se usa Func<T, bool> para permitir expresiones lambda como condiciones de búsqueda
    public Node<T>? Find(Func<T, bool> predicate)
    {
        Node<T>? current = Head;
        while (current != null)
        {
            // Se verifica si current.Data no es nulo antes de aplicar el predicado
            if (current.Data != null && predicate(current.Data))
            {
                return current; // Retorna el nodo si el predicado es verdadero
            }
            current = current.Next;
        }
        return null; // Retorna null si no se encuentra ningún nodo que cumpla la condición
    }

    // Método para eliminar un nodo basándose en un predicado
    public bool Remove(Func<T, bool> predicate)
    {
        if (Head == null)
            return false; // No se puede eliminar de una lista vacía

        // Si la cabeza de la lista cumple el predicado, la eliminamos
        if (Head.Data != null && predicate(Head.Data))
        {
            Head = Head.Next; // La nueva cabeza es el siguiente nodo
            Count--;
            return true;
        }

        Node<T>? current = Head;
        while (current != null && current.Next != null)
        {
            // Si el siguiente nodo cumple el predicado, lo eliminamos
            if (current.Next.Data != null && predicate(current.Next.Data))
            {
                current.Next = current.Next.Next; // Salta el nodo a eliminar
                Count--;
                return true;
            }
            current = current.Next;
        }
        return false; // Retorna false si no se encontró o no se pudo eliminar
    }

    // Método para mostrar todos los elementos de la lista
    public void DisplayList()
    {
        if (Head == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Node<T>? current = Head;
        while (current != null)
        {
            // Usa el operador de anulación de nulos ?. para llamar a ToString() de forma segura
            Console.WriteLine(current.Data?.ToString());
            current = current.Next;
        }
    }

    // Implementación de IEnumerable<T> para permitir el uso de 'foreach'
    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = Head;
        while (current != null)
        {
            if (current.Data != null)
            {
                yield return current.Data;
            }
            current = current.Next;
        }
    }

    // Implementación explícita para la interfaz no genérica
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Clase para representar un vehículo
public class Vehicle
{
    public string LicensePlate { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public decimal Price { get; set; }

    public Vehicle(string licensePlate, string brand, string model, int year, decimal price)
    {
        // Usa el operador de coalescencia nula (??) para asegurar que las cadenas no sean nulas.
        // Si Console.ReadLine() devuelve null (poco probable en una app de consola interactiva, pero posible),
        // se asignará string.Empty en su lugar. Esto evita la advertencia CS8604.
        LicensePlate = licensePlate ?? string.Empty;
        Brand = brand ?? string.Empty;
        Model = model ?? string.Empty;
        Year = year;
        Price = price;
    }

    public override string ToString()
    {
        return $"Placa: {LicensePlate}, Marca: {Brand}, Modelo: {Model}, Año: {Year}, Precio: {Price:C}";
    }
}

public class Ejercicio7
{
    // Instancia estática de la lista enlazada de vehículos
    private static LinkedList<Vehicle> vehicleList = new LinkedList<Vehicle>();

    // EL MÉTODO MAIN FALTANTE: Punto de entrada de la aplicación
    public static void Main(string[] args)
    {
        Run(); // Llama al método Run para iniciar la lógica del programa
    }

    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 7: Registro de Vehículos ---");
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Menú de Opciones ---");
            Console.WriteLine("a. Agregar vehículo");
            Console.WriteLine("b. Buscar vehículo por placa");
            Console.WriteLine("c. Ver vehículos por año");
            Console.WriteLine("d. Ver todos los vehículos registrados");
            Console.WriteLine("e. Eliminar carro registrado");
            Console.WriteLine("f. Salir");
            Console.Write("Seleccione una opción: ");

            // Usa el operador de coalescencia nula (??) para manejar el posible null de Console.ReadLine()
            // Y luego .ToLower() para hacer la comparación de opciones insensible a mayúsculas/minúsculas.
            string? optionInput = Console.ReadLine();
            string option = optionInput?.ToLower() ?? string.Empty;

            switch (option)
            {
                case "a":
                    AddVehicle();
                    break;
                case "b":
                    SearchVehicleByLicensePlate();
                    break;
                case "c":
                    ViewVehiclesByYear();
                    break;
                case "d":
                    ViewAllVehicles();
                    break;
                case "e":
                    DeleteVehicle();
                    break;
                case "f":
                    exit = true;
                    Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                    break;
            }
        }
    }

    private static void AddVehicle()
    {
        Console.WriteLine("\n--- Agregar Nuevo Vehículo ---");
        Console.Write("Placa: ");
        string licensePlate = Console.ReadLine() ?? string.Empty; // Maneja posible null

        // Validar si la placa ya existe
        // Usa el método Find de tu LinkedList personalizada
        if (vehicleList.Find(v => v.LicensePlate.Equals(licensePlate, StringComparison.OrdinalIgnoreCase)) != null)
        {
            Console.WriteLine("Error: Ya existe un vehículo con esa placa.");
            return;
        }

        Console.Write("Marca: ");
        string brand = Console.ReadLine() ?? string.Empty; // Maneja posible null
        Console.Write("Modelo: ");
        string model = Console.ReadLine() ?? string.Empty; // Maneja posible null

        int year;
        Console.Write("Año: ");
        string? yearInput = Console.ReadLine();
        // Bucle para validación de entrada numérica
        while (!int.TryParse(yearInput, out year) || year <= 0)
        {
            Console.WriteLine("Año inválido. Por favor, ingrese un número entero positivo.");
            Console.Write("Año: ");
            yearInput = Console.ReadLine();
        }

        decimal price;
        Console.Write("Precio: ");
        string? priceInput = Console.ReadLine();
        // Bucle para validación de entrada numérica
        while (!decimal.TryParse(priceInput, out price) || price <= 0)
        {
            Console.WriteLine("Precio inválido. Por favor, ingrese un número positivo.");
            Console.Write("Precio: ");
            priceInput = Console.ReadLine();
        }

        Vehicle newVehicle = new Vehicle(licensePlate, brand, model, year, price);
        vehicleList.AddLast(newVehicle); // Agrega el nuevo vehículo a la lista
        Console.WriteLine("Vehículo agregado exitosamente.");
    }

    private static void SearchVehicleByLicensePlate()
    {
        Console.WriteLine("\n--- Buscar Vehículo por Placa ---");
        Console.Write("Ingrese la placa del vehículo a buscar: ");
        string searchPlate = Console.ReadLine() ?? string.Empty; // Maneja posible null

        // Usa el método Find de tu LinkedList con un predicado lambda
        Node<Vehicle>? foundNode = vehicleList.Find(v => v.LicensePlate.Equals(searchPlate, StringComparison.OrdinalIgnoreCase));

        if (foundNode != null)
        {
            Console.WriteLine("Vehículo encontrado:");
            // Usa el operador de anulación de nulos ?. para acceder a Data de forma segura
            Console.WriteLine(foundNode.Data?.ToString());
        }
        else
        {
            Console.WriteLine("Vehículo con la placa '{0}' no encontrado.", searchPlate);
        }
    }

    private static void ViewVehiclesByYear()
    {
        Console.WriteLine("\n--- Ver Vehículos por Año ---");
        Console.Write("Ingrese el año a buscar: ");
        int searchYear;
        string? yearInput = Console.ReadLine();
        if (!int.TryParse(yearInput, out searchYear) || searchYear <= 0)
        {
            Console.WriteLine("Año inválido. Por favor, ingrese un número entero positivo.");
            return;
        }

        Node<Vehicle>? current = vehicleList.Head; // 'current' puede ser nulo, por eso se hace anulable
        bool foundAny = false;
        Console.WriteLine($"\nVehículos del año {searchYear}:");
        while (current != null)
        {
            // Se verifica si current.Data no es nulo antes de acceder a Year
            if (current.Data != null && current.Data.Year == searchYear)
            {
                Console.WriteLine(current.Data);
                foundAny = true;
            }
            current = current.Next;
        }

        if (!foundAny)
        {
            Console.WriteLine($"No se encontraron vehículos registrados para el año {searchYear}.");
        }
    }

    private static void ViewAllVehicles()
    {
        Console.WriteLine("\n--- Todos los Vehículos Registrados ---");
        if (vehicleList.Count == 0)
        {
            Console.WriteLine("No hay vehículos registrados.");
            return;
        }
        vehicleList.DisplayList(); // Llama a tu método DisplayList de la LinkedList
    }

    private static void DeleteVehicle()
    {
        Console.WriteLine("\n--- Eliminar Vehículo ---");
        Console.Write("Ingrese la placa del vehículo a eliminar: ");
        string deletePlate = Console.ReadLine() ?? string.Empty; // Maneja posible null

        // Usa el método Remove de tu LinkedList con un predicado lambda
        if (vehicleList.Remove(v => v.LicensePlate.Equals(deletePlate, StringComparison.OrdinalIgnoreCase)))
        {
            Console.WriteLine("Vehículo con placa '{0}' eliminado exitosamente.", deletePlate);
        }
        else
        {
            Console.WriteLine("Vehículo con placa '{0}' no encontrado o no se pudo eliminar.", deletePlate);
        }
    }
}

