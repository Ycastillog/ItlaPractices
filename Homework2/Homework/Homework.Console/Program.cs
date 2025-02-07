using System;

class Program
{
    // Yeison Castillo 2023-1688
    static void Main()
    {
        // Solicitar al usuario un número
        Console.Write("Introduce un número: ");
        int numero = int.Parse(Console.ReadLine());

        // Verificar si el número es par o impar
        if (numero % 2 == 0)
        {
            Console.WriteLine($"El número {numero} es par.");
        }
        else
        {
            Console.WriteLine($"El número {numero} es impar.");

            Console.WriteLine("\n Aqui se acaba to'");
            Console.ReadLine();
   
        }
    }
}
