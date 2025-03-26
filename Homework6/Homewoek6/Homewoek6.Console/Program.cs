using System;
using System.Collections.Generic;

class Contacto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public string Direccion { get; set; }
}
// Yeison Castillo 2023-1688 Viernes 6-10 pm
class Agenda
{
    private List<Contacto> contactos = new List<Contacto>();
    private int contadorId = 1;

    public void AgregarContacto()
    {
        Contacto nuevoContacto = new Contacto { Id = contadorId };
        Console.Write("Digite el Nombre: ");
        nuevoContacto.Nombre = Console.ReadLine();
        Console.Write("Digite el Teléfono: ");
        nuevoContacto.Telefono = Console.ReadLine();
        Console.Write("Digite el Email: ");
        nuevoContacto.Email = Console.ReadLine();
        Console.Write("Digite la Dirección: ");
        nuevoContacto.Direccion = Console.ReadLine();

        contactos.Add(nuevoContacto);
        contadorId++;
    }

    public void VerContactos()
    {
        Console.WriteLine("Id   Nombre   Teléfono   Email   Dirección");
        Console.WriteLine("-----------------------------------------");
        foreach (var c in contactos)
        {
            Console.WriteLine($"{c.Id}   {c.Nombre}   {c.Telefono}   {c.Email}   {c.Direccion}");
        }
    }

    public void BuscarContacto()
    {
        Console.Write("Ingrese el ID del contacto a buscar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);
        if (contacto != null)
        {
            Console.WriteLine($"Nombre: {contacto.Nombre}, Teléfono: {contacto.Telefono}, Email: {contacto.Email}, Dirección: {contacto.Direccion}");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void EditarContacto()
    {
        Console.Write("Ingrese el ID del contacto a editar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);
        if (contacto != null)
        {
            Console.Write("Nuevo Nombre: ");
            contacto.Nombre = Console.ReadLine();
            Console.Write("Nuevo Teléfono: ");
            contacto.Telefono = Console.ReadLine();
            Console.Write("Nuevo Email: ");
            contacto.Email = Console.ReadLine();
            Console.Write("Nueva Dirección: ");
            contacto.Direccion = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }

    public void EliminarContacto()
    {
        Console.Write("Ingrese el ID del contacto a eliminar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var contacto = contactos.Find(c => c.Id == id);
        if (contacto != null)
        {
            contactos.Remove(contacto);
            Console.WriteLine("Contacto eliminado exitosamente.");
        }
        else
        {
            Console.WriteLine("Contacto no encontrado.");
        }
    }
}

class Program
{
    static void Main()
    {
        Agenda agenda = new Agenda();
        bool ejecutando = true;

        while (ejecutando)
        {
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            int opcion = Convert.ToInt32(Console.ReadLine());
            switch (opcion)
            {
                case 1:
                    agenda.AgregarContacto();
                    break;
                case 2:
                    agenda.VerContactos();
                    break;
                case 3:
                    agenda.BuscarContacto();
                    break;
                case 4:
                    agenda.EditarContacto();
                    break;
                case 5:
                    agenda.EliminarContacto();
                    break;
                case 6:
                    ejecutando = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}

