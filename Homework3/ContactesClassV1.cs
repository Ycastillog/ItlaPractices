Console.WriteLine("Bienvenido a mi lista de Contactes");


//names, lastnames, addresses, telephones, emails, ages, bestfriend
bool runing = true;
List<int> ids = new List<int>();
Dictionary<int, string> names = new Dictionary<int, string>();
Dictionary<int, string> lastnames = new Dictionary<int, string>();
Dictionary<int, string> addresses = new Dictionary<int, string>();
Dictionary<int, string> telephones = new Dictionary<int, string>();
Dictionary<int, string> emails = new Dictionary<int, string>();
Dictionary<int, int> ages = new Dictionary<int, int>();
Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();


while (runing)
{
    Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   6. Eliminar Contacto    6. Salir");
    Console.WriteLine("Digite el número de la opción deseada");

    int typeOption = Convert.ToInt32(Console.ReadLine());

    switch (typeOption)
    {
        case 1:
            {
                //Console.WriteLine("Digite el nombre de la persona");
                //string name = Console.ReadLine();
                //Console.WriteLine("Digite el apellido de la persona");
                //string lastname = Console.ReadLine();
                //Console.WriteLine("Digite la dirección");
                //string address = Console.ReadLine();
                //Console.WriteLine("Digite el telefono de la persona");
                //string phone = Console.ReadLine();
                //Console.WriteLine("Digite el email de la persona");
                //string email = Console.ReadLine();
                //Console.WriteLine("Digite la edad de la persona en números");
                //int age = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
                ////var temp = Convert.ToInt32(Console.ReadLine());
                ////bool isBestFriend;
                ////if (temp == 1)
                ////{ isBestFriend = true; }
                ////else
                ////{ isBestFriend = false; }
                //bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

                //var id = ids.Count + 1;
                //ids.Add(id);
                //names.Add(id, name);
                //lastnames.Add(id, lastname);
                //addresses.Add(id, address);
                //telephones.Add(id, phone);
                //emails.Add(id, email);
                //ages.Add(id, age);
                //bestFriends.Add(id, isBestFriend);

                AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);

            }
            break;
        case 2: //extract this to a method
            {
                Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                Console.WriteLine($"____________________________________________________________________________________________________________________________");
                foreach (var id in ids)
                {
                    var isBestFriend  = bestFriends[id];

                    //string isBestFriendStr;
                     
                    //if (isBestFriend == true)
                    //{
                    //    isBestFriendStr = "Si";
                    //}
                    //else {
                    //    isBestFriendStr = "No";
                    //}

                    string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                    Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                }

            }
            break;
        case 3: //search
            {
                Console.WriteLine("¿Cómo deseas buscar al contacto? Ingresa 1 para nombre, 2 para apellido, 3 para teléfono:");
                int searchOption = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Introduce el valor de búsqueda:");
                string searchValue = Console.ReadLine().ToLower(); // Para hacer la búsqueda insensible a mayúsculas

                bool found = false;
                foreach (var id in ids)
                {
                    bool match = false;
                    switch (searchOption)
                    {
                        case 1:
                            match = names[id].ToLower().Contains(searchValue);
                            break;
                        case 2:
                            match = lastnames[id].ToLower().Contains(searchValue);
                            break;
                        case 3:
                            match = telephones[id].ToLower().Contains(searchValue);
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            return;
                    }

                    if (match)
                    {
                        string isBestFriendStr = bestFriends[id] ? "Sí" : "No";
                        Console.WriteLine($"ID: {id}, Nombre: {names[id]}, Apellido: {lastnames[id]}, Teléfono: {telephones[id]}, Email: {emails[id]}, Edad: {ages[id]}, Mejor Amigo: {isBestFriendStr}");
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("No se encontraron contactos con ese valor.");
                }
            }
            break;
        case 4: //modify
            {
                Console.WriteLine("Introduce el ID del contacto que deseas modificar:");
                int contactId = Convert.ToInt32(Console.ReadLine());

                if (ids.Contains(contactId))
                {
                    Console.WriteLine("¿Qué deseas modificar?");
                    Console.WriteLine("1. Nombre   2. Apellido   3. Dirección   4. Teléfono   5. Email   6. Edad   7. Mejor Amigo");
                    int modifyOption = Convert.ToInt32(Console.ReadLine());

                    switch (modifyOption)
                    {
                        case 1:
                            Console.WriteLine("Nuevo nombre (presiona Enter para mantener el valor actual):");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName)) names[contactId] = newName;
                            break;
                        case 2:
                            Console.WriteLine("Nuevo apellido (presiona Enter para mantener el valor actual):");
                            string newLastname = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newLastname)) lastnames[contactId] = newLastname;
                            break;
                        case 3:
                            Console.WriteLine("Nueva dirección (presiona Enter para mantener el valor actual):");
                            string newAddress = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newAddress)) addresses[contactId] = newAddress;
                            break;
                        case 4:
                            Console.WriteLine("Nuevo teléfono (presiona Enter para mantener el valor actual):");
                            string newPhone = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newPhone)) telephones[contactId] = newPhone;
                            break;
                        case 5:
                            Console.WriteLine("Nuevo email (presiona Enter para mantener el valor actual):");
                            string newEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newEmail)) emails[contactId] = newEmail;
                            break;
                        case 6:
                            Console.WriteLine("Nueva edad (presiona Enter para mantener el valor actual):");
                            string newAge = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newAge) && int.TryParse(newAge, out int age)) ages[contactId] = age;
                            break;
                        case 7:
                            Console.WriteLine("Es mejor amigo (1 para sí, 2 para no):");
                            string isBestFriendInput = Console.ReadLine();
                            if (!string.IsNullOrEmpty(isBestFriendInput))
                                bestFriends[contactId] = isBestFriendInput == "1";
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }

                    Console.WriteLine("Contacto modificado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se encontró un contacto con ese ID.");
                }
            }
            break;
        case 5: //delete
            {
                Console.WriteLine("Introduce el ID del contacto que deseas eliminar:");
                int contactId = Convert.ToInt32(Console.ReadLine());

                if (ids.Contains(contactId))
                {
                    ids.Remove(contactId);
                    names.Remove(contactId);
                    lastnames.Remove(contactId);
                    addresses.Remove(contactId);
                    telephones.Remove(contactId);
                    emails.Remove(contactId);
                    ages.Remove(contactId);
                    bestFriends.Remove(contactId);

                    Console.WriteLine("Contacto eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("No se encontró un contacto con ese ID.");
                }
            }
            break;
            break;
        case 6:
            runing = false;
            break;
        default:
            Console.WriteLine("Tu eres o te haces el idiota?");
            break;
    }
}


static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames, Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails, Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
{
    Console.WriteLine("Digite el nombre de la persona");
    string name = Console.ReadLine();
    Console.WriteLine("Digite el apellido de la persona");
    string lastname = Console.ReadLine();
    Console.WriteLine("Digite la dirección");
    string address = Console.ReadLine();
    Console.WriteLine("Digite el telefono de la persona");
    string phone = Console.ReadLine();
    Console.WriteLine("Digite el email de la persona");
    string email = Console.ReadLine();
    Console.WriteLine("Digite la edad de la persona en números");
    int age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");

    bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

    var id = ids.Count + 1;
    ids.Add(id);
    names.Add(id, name);
    lastnames.Add(id, lastname);
    addresses.Add(id, address);
    telephones.Add(id, phone);
    emails.Add(id, email);
    ages.Add(id, age);
    bestFriends.Add(id, isBestFriend);
}