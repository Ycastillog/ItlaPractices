using BLL;
using Models;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Registrar Propiedad");
                Console.WriteLine("2. Registrar Inquilino");
                Console.WriteLine("3. Registrar Contrato");
                Console.WriteLine("4. Registrar Pago");
                Console.WriteLine("5. Salir");

                string opcion = Console.ReadLine();

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

                    try
                    {
                        propiedadBLL.AgregarPropiedad(propiedad);
                        Console.WriteLine($"Propiedad registrada exitosamente con ID: {propiedad.PropiedadID}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al registrar la propiedad: {ex.Message}");
                    }
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

                    try
                    {
                        inquilinoBLL.AgregarInquilino(inquilino);
                        Console.WriteLine($"Inquilino registrado exitosamente con ID: {inquilino.InquilinoID}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al registrar el inquilino: {ex.Message}");
                    }
                }
                else if (opcion == "3")
                {
                    // Registrar Contrato
                    ContratoBLL contratoBLL = new ContratoBLL();

                    Console.WriteLine("Registro de Contrato");
                    Console.WriteLine("ID de Propiedad:");
                    int propiedadID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("ID de Inquilino:");
                    int inquilinoID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Fecha de inicio (YYYY-MM-DD):");
                    DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Fecha de fin (YYYY-MM-DD):");
                    DateTime fechaFin = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("Monto mensual:");
                    decimal montoMensual = Convert.ToDecimal(Console.ReadLine());

                    Contrato contrato = new Contrato
                    {
                        PropiedadID = propiedadID,
                        InquilinoID = inquilinoID,
                        FechaInicio = fechaInicio,
                        FechaFin = fechaFin,
                        MontoMensual = montoMensual
                    };

                    try
                    {
                        contratoBLL.AgregarContrato(contrato);
                        Console.WriteLine($"Contrato registrado exitosamente con ID: {contrato.ContratoID}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al registrar el contrato: {ex.Message}");
                    }
                }
                else if (opcion == "4")
                {
                    // Registrar Pago
                    PagoBLL pagoBLL = new PagoBLL();

                    Console.WriteLine("Registro de Pago");
                    Console.WriteLine("ID de Contrato:");
                    int contratoID = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Monto de pago:");
                    decimal monto = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Fecha de pago (YYYY-MM-DD):");
                    DateTime fechaPago = DateTime.Parse(Console.ReadLine());

                    Pago pago = new Pago
                    {
                        ContratoID = contratoID,
                        Monto = monto,
                        FechaPago = fechaPago
                    };

                    try
                    {
                        pagoBLL.AgregarPago(pago);
                        Console.WriteLine($"Pago registrado exitosamente con ID: {pago.PagoID}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al registrar el pago: {ex.Message}");
                    }
                }

                else if (opcion == "5")
                {
                    // Salir
                    Console.WriteLine("Gracias por usar el sistema.");
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                }
            }

            Console.ReadKey();
        }
    }
}