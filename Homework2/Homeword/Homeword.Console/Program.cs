using System;

class Program
{
    // Yeison Castillo 2023-1688
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Introduce el numero: ");
            int numero = int.Parse(Console.ReadLine());

            if (numero % 2 == 0)
            {
                Console.WriteLine($"El numero {numero} es par. ");
            }
            else
            {
                Console.WriteLine($"El numero {numero} es impar. ");
            }
            Console.WriteLine("¿Quieres ingresar otro numero? (s/n): ");
            string respuesta = Console.ReadLine().ToLower();

            if (respuesta != "s")
            {
                Console.WriteLine("Pues largate");
                break;
            }
        }

    }
}