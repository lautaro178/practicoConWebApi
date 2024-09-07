using DAL.DALs;
using DAL.IDALs;
using Shared;
using DAL;
using DAL.Models;

// dal = new DAL_Personas_Mock();
DBContext dBContext = new DBContext();
IDAL_Personas dal = new DAL_Personas_EF(dBContext);
IDAL_Vehiculo dalVehiuclos = new DAL_Vehiculo_EF(dBContext);

string comando = "NUEVA";
string opcion = "";
Console.WriteLine("Bienvenido a mi primera app .NET!!!");

do
{
    Console.WriteLine("Ingrese comando (NUEVA/IMPRIMIR/ELIMINAR/ACTUALIZAR/ASOCIAR/EXIT): ");

    try
    {
        comando = Console.ReadLine().ToUpper();

        switch (comando)
        {
            case "NUEVA":

                Persona persona = new Persona();
                Console.WriteLine("Ingrese el documento de la persona: ");
                persona.Documento = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre de la persona: ");
                persona.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el apellido de la persona: ");
                persona.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese la edad de la persona: ");
                persona.Edad = int.Parse(Console.ReadLine());
                dal.AddPersona(persona);
                break;

            case "IMPRIMIR":

                Console.WriteLine("UNA PERSONA (1) / TODAS (*): ");
                opcion = Console.ReadLine().ToUpper();
                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Ingrese la cedula: ");
                        string cedula2 = Console.ReadLine();
                        Persona persona2 = dal.GetPersona(cedula2);
                        if (persona2 != null)
                        {
                            //Console.WriteLine(persona2.GetStringConVehiculo());
                        }
                        else
                        {
                            Console.WriteLine("Persona no encontrada.");
                        }
                        break;

                    case "*":
                        foreach (Persona p in dal.GetPersonas())
                        {
                            //Console.WriteLine(p.GetStringConVehiculo());
                        }
                        break;

                    default:
                        Console.WriteLine("Opcion no reconocida.");
                        break;
                }
                break;

            case "ACTUALIZAR":

                Console.WriteLine("Ingrese la cedula: ");
                string cedula = Console.ReadLine();
                Persona persona3 = dal.GetPersona(cedula);
                Console.WriteLine(persona3.GetString());
                Console.WriteLine("Que quieres actualizar?");
                Console.WriteLine("DOCUMENTO/NOMBRE/APELLIDO/EDAD");
                string opcionActualizar = "";
                opcionActualizar = Console.ReadLine().ToUpper();
                switch (opcionActualizar)

                {
                    case "DOCUMENTO":
                        Console.WriteLine("Ingrese el documento de la persona: ");
                        persona3.Documento = Console.ReadLine();
                        break;

                    case "NOMBRE":
                        Console.WriteLine("Ingrese el nombre de la persona: ");
                        persona3.Nombre = Console.ReadLine();
                        break;

                    case "APELLIDO":
                        Console.WriteLine("Ingrese el apellido de la persona: ");
                        persona3.Apellido = Console.ReadLine();
                        break;

                    case "EDAD":
                        Console.WriteLine("Ingrese la edad de la persona: ");
                        persona3.Edad = int.Parse(Console.ReadLine());
                        break;

                    default:
                        Console.WriteLine("Opcion no reconocida.");
                        break;
                }
                dal.UpdatePersona(persona3);
                break;

            case "ELIMINAR":

                Console.WriteLine("Ingrese la cedula: ");
                string cedula3 = Console.ReadLine();
                dal.DeletePersona(cedula3);
                break;

            case "ASOCIAR":

                Console.WriteLine("Ingrese la cedula: ");
                string cedula4 = Console.ReadLine();
                Persona persona4 = dal.GetPersona(cedula4);
                Console.WriteLine(persona4.GetString());
                Console.WriteLine("Ingrese la matricula del vehiculo: ");
                string matricula = Console.ReadLine();
                Vehiculo vehiculo = dalVehiuclos.GetVehiculo(matricula);
                Console.WriteLine(vehiculo.GetString());
                break;

            case "EXIT":
                break;

            default:
                Console.WriteLine("Comando no reconocido.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}
while (comando != "EXIT");

Console.WriteLine("Hasta luego!!!");
Console.ReadLine();