using System;

class Program
{
    static void Main()
    {
        string opcion = "";

        do
        {
            Console.Clear(); 
            Console.WriteLine("=============================================");
            Console.WriteLine("                 Biblioteca                  ");
            Console.WriteLine("=============================================");
            Console.WriteLine("1. Buscar libro por codigo");
            Console.WriteLine("2. Prestar un libro");
            Console.WriteLine("3. Devolver un libro");
            Console.WriteLine("4. Ver Top 5 mas prestados");
            Console.WriteLine("5. Ver Top 5 menos prestados");
            Console.WriteLine("6. Salir");
            Console.WriteLine("=============================================");
            Console.Write("Ingrese una opcion (1-6): ");

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine("\n=== BUSCAR LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "2":
                    Console.WriteLine("\n=== PRESTAR LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "3":
                    Console.WriteLine("\n=== DEVOLVER LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "4":
                    Console.WriteLine("\n=== TOP 5 MAS PRESTADOS ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "5":
                    Console.WriteLine("\n=== TOP 5 MENOS PRESTADOS ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "6":
                    Console.WriteLine("\nSaliendo del programa... ¡Hasta luego!");
                    break;

                default:
                    Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                    break;
            }

            if (opcion != "6")
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != "6");
    }
}