using BLL;
using Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PropiedadBLL propiedadBLL = new PropiedadBLL();

            Console.WriteLine("Ingrese dirección de la propiedad:");
            string direccion = Console.ReadLine();

            Console.WriteLine("Ingrese tipo de propiedad (Apartamento, Casa, etc):");
            string tipo = Console.ReadLine();

            Console.WriteLine("Ingrese precio:");
            decimal precio = Convert.ToDecimal(Console.ReadLine());

            Propiedad propiedad = new Propiedad
            {
                Direccion = direccion,
                Tipo = tipo,
                Precio = precio
            };

            propiedadBLL.AgregarPropiedad(propiedad);
            Console.WriteLine("✅ Propiedad registrada exitosamente.");
        }
    }
}

