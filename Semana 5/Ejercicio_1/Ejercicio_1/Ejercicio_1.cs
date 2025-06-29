// Archivo: Ejercicio1.cs
using System;
using System.Collections.Generic;

// Clase para representar un Curso
public class Curso
{
    // Propiedad para almacenar las asignaturas
    public List<string> Asignaturas { get; set; }

    // Constructor que inicializa la lista de asignaturas
    public Curso()
    {
        Asignaturas = new List<string>();
    }

    // Método para agregar una asignatura
    public void AgregarAsignatura(string asignatura)
    {
        Asignaturas.Add(asignatura);
    }

    // Método para mostrar todas las asignaturas
    public void MostrarAsignaturas()
    {
        Console.WriteLine("Asignaturas del curso:");
        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine($"- {asignatura}");
        }
    }
}

public class Ejercicio1
{
    // Cambiado de Run() a Main()
    public static void Main(string[] args) // Main puede tomar opcionalmente string[] args
    {
        Console.WriteLine("\n===Ejercicio 1: Mostrar Asignaturas===");
        // Crear una instancia de la clase Curso
        Curso miCurso = new Curso();

        // Agregar asignaturas
        miCurso.AgregarAsignatura("ADMINISTRACION DE SISTEMAS OPERATIVOS");
        miCurso.AgregarAsignatura("ESTRUCTURA DE DATOS");
        miCurso.AgregarAsignatura("FUNDAMENTOS DE SISTEMAS DIGITALES");
        miCurso.AgregarAsignatura("INSTALACIONES ELECTRICAS Y DE CABLEADO ESTRUCTURADO");
        miCurso.AgregarAsignatura("METODOLOGIA DE LA INVESTIGACION");

        // Mostrar las asignaturas
        miCurso.MostrarAsignaturas();
        Console.WriteLine();
    }
}