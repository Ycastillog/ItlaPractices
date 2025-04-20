using BLL;
using Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("1. Propiedad");
                Console.WriteLine("2. Inquilino");
                Console.WriteLine("3. Contrato");
                Console.WriteLine("4. Pago");
                Console.WriteLine("5. Salir");

                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.WriteLine("\n1. Crear Propiedad");
                    Console.WriteLine("2. Modificar Propiedad");
                    Console.WriteLine("3. Eliminar Propiedad");

                    string opcionPropiedad = Console.ReadLine();
                    PropiedadBLL propiedadBLL = new PropiedadBLL();

                    if (opcionPropiedad == "1")
                    {
                        // Crear Propiedad
                        Console.WriteLine("\nIngrese dirección de la propiedad:");
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
                            Console.WriteLine($"\nPropiedad registrada exitosamente con ID: {propiedad.PropiedadID}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al registrar la propiedad: {ex.Message}");
                        }
                    }
                    else if (opcionPropiedad == "2")
                    {
                        // Modificar Propiedad
                        Console.WriteLine("\nIngrese ID de la propiedad a modificar:");
                        int propiedadID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese nueva dirección de la propiedad:");
                        string direccion = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo tipo de propiedad (Apartamento, Casa, etc):");
                        string tipo = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo precio:");
                        decimal precio = Convert.ToDecimal(Console.ReadLine());

                        Propiedad propiedad = new Propiedad
                        {
                            PropiedadID = propiedadID,
                            Direccion = direccion,
                            Tipo = tipo,
                            Precio = precio
                        };

                        try
                        {
                            propiedadBLL.ModificarPropiedad(propiedad);
                            Console.WriteLine("\nPropiedad modificada exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al modificar la propiedad: {ex.Message}");
                        }
                    }
                    else if (opcionPropiedad == "3")
                    {
                        // Eliminar Propiedad
                        Console.WriteLine("\nIngrese ID de la propiedad a eliminar:");
                        int propiedadID = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            propiedadBLL.EliminarPropiedad(propiedadID);
                            Console.WriteLine("\nPropiedad eliminada exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al eliminar la propiedad: {ex.Message}");
                        }
                    }
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("\n1. Crear Inquilino");
                    Console.WriteLine("2. Modificar Inquilino");
                    Console.WriteLine("3. Eliminar Inquilino");

                    string opcionInquilino = Console.ReadLine();
                    InquilinoBLL inquilinoBLL = new InquilinoBLL();

                    if (opcionInquilino == "1")
                    {
                        // Crear Inquilino
                        Console.WriteLine("\nIngrese nombre del inquilino:");
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
                            Console.WriteLine($"\nInquilino registrado exitosamente con ID: {inquilino.InquilinoID}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al registrar el inquilino: {ex.Message}");
                        }
                    }
                    else if (opcionInquilino == "2")
                    {
                        // Modificar Inquilino
                        Console.WriteLine("\nIngrese ID del inquilino a modificar:");
                        int inquilinoID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese nuevo nombre:");
                        string nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese nueva cédula:");
                        string cedula = Console.ReadLine();

                        Console.WriteLine("Ingrese nuevo teléfono:");
                        string telefono = Console.ReadLine();

                        Inquilino inquilino = new Inquilino
                        {
                            InquilinoID = inquilinoID,
                            Nombre = nombre,
                            Cedula = cedula,
                            Telefono = telefono
                        };

                        try
                        {
                            inquilinoBLL.ModificarInquilino(inquilino);
                            Console.WriteLine("\nInquilino modificado exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al modificar el inquilino: {ex.Message}");
                        }
                    }
                    else if (opcionInquilino == "3")
                    {
                        // Eliminar Inquilino
                        Console.WriteLine("\nIngrese ID del inquilino a eliminar:");
                        int inquilinoID = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            inquilinoBLL.EliminarInquilino(inquilinoID);
                            Console.WriteLine("\nInquilino eliminado exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al eliminar el inquilino: {ex.Message}");
                        }
                    }
                }
                else if (opcion == "3")
                {
                    Console.WriteLine("\n1. Crear Contrato");
                    Console.WriteLine("2. Modificar Contrato");
                    Console.WriteLine("3. Eliminar Contrato");

                    string opcionContrato = Console.ReadLine();
                    ContratoBLL contratoBLL = new ContratoBLL();

                    if (opcionContrato == "1")
                    {
                        // Crear Contrato
                        Console.WriteLine("\nIngrese ID de Propiedad:");
                        int propiedadID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese ID de Inquilino:");
                        int inquilinoID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese fecha de inicio (YYYY-MM-DD):");
                        DateTime fechaInicio = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese fecha de fin (YYYY-MM-DD):");
                        DateTime fechaFin = DateTime.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese monto mensual:");
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
                            Console.WriteLine($"\nContrato registrado exitosamente con ID: {contrato.ContratoID}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al registrar el contrato: {ex.Message}");
                        }
                    }
                    else if (opcionContrato == "2")
                    {
                        // Modificar Contrato
                        Console.WriteLine("\nIngrese ID del contrato a modificar:");
                        int contratoID = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Ingrese nuevo monto mensual:");
                        decimal montoMensual = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Ingrese nueva fecha de fin (YYYY-MM-DD):");
                        DateTime fechaFin = DateTime.Parse(Console.ReadLine());

                        Contrato contrato = new Contrato
                        {
                            ContratoID = contratoID,
                            MontoMensual = montoMensual,
                            FechaFin = fechaFin
                        };

                        try
                        {
                            contratoBLL.ModificarContrato(contrato);
                            Console.WriteLine("\nContrato modificado exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al modificar el contrato: {ex.Message}");
                        }
                    }
                    else if (opcionContrato == "3")
                    {
                        // Eliminar Contrato
                        Console.WriteLine("\nIngrese ID del contrato a eliminar:");
                        int contratoID = Convert.ToInt32(Console.ReadLine());

                        try
                        {
                            contratoBLL.EliminarContrato(contratoID);
                            Console.WriteLine("\nContrato eliminado exitosamente.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error al eliminar el contrato: {ex.Message}");
                        }
                    }
                }
                else if (opcion == "4")
                {
                    // Salir
                    Console.WriteLine("\nGracias por usar el sistema.");
                    continuar = false;
                }
                else
                {
                    Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                }
            }
        }
    }
}


