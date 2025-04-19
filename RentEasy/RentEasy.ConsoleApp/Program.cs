using BLL;
using Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Mostrar el menú
            Console.WriteLine("1. Registrar Propiedad");
            Console.WriteLine("2. Registrar Inquilino");
            Console.WriteLine("3. Registrar Contrato");
            Console.WriteLine("4. Registrar Pago");

            // Leer opción
            var opcion = Console.ReadLine();

            if (opcion == "1")
            {
                // Registrar Propiedad
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
            else if (opcion == "2")
            {
                // Registrar Inquilino
                InquilinoBLL inquilinoBLL = new InquilinoBLL();

                Console.WriteLine("Registro de Inquilino");
                Console.WriteLine("Ingrese nombre del inquilino:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese cédula:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese teléfono:");
                string telefono = Console.ReadLine();

                Inquilino inquilino = new Inquilino
                {
                    Nombre = nombre,
                    Cedula = cedula,
                    Telefono = telefono
                };

                inquilinoBLL.AgregarInquilino(inquilino);
                Console.WriteLine("✅ Inquilino registrado correctamente.");
            }
            else if (opcion == "3")
            {
                // Registrar Contrato
                ContratoBLL contratoBLL = new ContratoBLL();
                Console.Write("ID Propiedad: ");
                int propId = int.Parse(Console.ReadLine());

                Console.Write("ID Inquilino: ");
                int inqId = int.Parse(Console.ReadLine());

                Console.Write("Fecha Inicio (yyyy-mm-dd): ");
                DateTime ini = DateTime.Parse(Console.ReadLine());

                Console.Write("Fecha Fin (yyyy-mm-dd): ");
                DateTime fin = DateTime.Parse(Console.ReadLine());

                contratoBLL.AgregarContrato(new Contrato
                {
                    PropiedadId = propId,
                    InquilinoId = inqId,
                    FechaInicio = ini,
                    FechaFin = fin
                });

                Console.WriteLine("✅ Contrato registrado.");
            }
            else if (opcion == "4")
            {
                // Registrar Pago
                PagoBLL pagoBLL = new PagoBLL();

                Console.Write("ID Contrato: ");
                int contratoId = int.Parse(Console.ReadLine());

                Console.Write("Fecha de Pago (yyyy-mm-dd): ");
                DateTime fecha = DateTime.Parse(Console.ReadLine());

                Console.Write("Monto: ");
                decimal monto = decimal.Parse(Console.ReadLine());

                pagoBLL.RegistrarPago(new Pago
                {
                    ContratoId = contratoId,
                    FechaPago = fecha,
                    Monto = monto
                });

                Console.WriteLine("✅ Pago registrado.");
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}


