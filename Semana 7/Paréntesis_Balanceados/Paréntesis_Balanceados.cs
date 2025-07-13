using System;
using System.Collections.Generic;

public class ParenthesisChecker
{
    public static void Main(string[] args)
    {
        bool continueChecking = true; // Variable para controlar el bucle.

        while (continueChecking)
        {
            Console.WriteLine("=== Verificación de Paréntesis Balanceados ===");
            Console.Write("Ingrese una expresión matemática: ");
            string? expression = Console.ReadLine();

            if (string.IsNullOrEmpty(expression))
            {
                Console.WriteLine("No se ingresó ninguna expresión. Por favor, intente de nuevo.");
            }
            else
            {
                if (IsBalanced(expression))
                {
                    Console.WriteLine("Fórmula balanceada.");
                }
                else
                {
                    Console.WriteLine("Fórmula NO balanceada.");
                }
            }

            Console.WriteLine("\n¿Desea verificar otra expresión? (s/n)");
            string? response = Console.ReadLine()?.ToLower(); // Lee la respuesta y la convierte a minúsculas.

            if (response != "s")
            {
                continueChecking = false; // Si la respuesta no es 's', sale del bucle.
            }
            Console.Clear(); // Limpia la consola para la siguiente iteración.
        }

        Console.WriteLine("¡Gracias por usar el verificador de paréntesis!");
    }

    /// <summary>
    /// Verifica si los paréntesis, llaves y corchetes en una expresión están balanceados.
    /// </summary>
    /// <param name="expression">La expresión matemática a verificar.</param>
    /// <returns>True si la expresión está balanceada, False en caso contrario.</returns>
    public static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }

                char openChar = stack.Pop();

                if (!Matches(openChar, c))
                {
                    return false;
                }
            }
        }
        return stack.Count == 0;
    }

    /// <summary>
    /// Verifica si un caracter de apertura y uno de cierre forman una pareja válida.
    /// </summary>
    /// <param name="open">Caracter de apertura.</param>
    /// <param name="close">Caracter de cierre.</param>
    /// <returns>True si forman una pareja válida, False en caso contrario.</returns>
    private static bool Matches(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '{' && close == '}') ||
               (open == '[' && close == ']');
    }
}