using System;

class Program
{
    // Yeison Castillo 2023-1688
    static void Main()
    {
        // Este es el que solicita al usuario un numero
        Console.Write("Introduce un numero: ");
        int numero = int.Parse(Console.ReadLine());

        // Este verifica si par o impar 
        if (numero % 2 == 0)
        {
            Console.WriteLine("El número {numero} es par.");
        }
        else
        {
            Console.WriteLine("El número {numero} es impar.");

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}

