// Programa principal de la biblioteca
using System;

class Program
{
    static void Main()
    {
        // Instanciar estructuras de datos
        ArbolBPlus arbolBiblioteca = new ArbolBPlus();
        MaxHeap maxHeap = new MaxHeap(100);
        MinHeap minHeap = new MinHeap(100);

        // Cargar datos del CSV al iniciar
        BibliotecaService.CargarDatosCSV("libros.csv", arbolBiblioteca, maxHeap, minHeap);

        string opcion = ""; // almacenamos la opcion elegida por el usuario

        do // mientras el usuario no elija salir, seguimos mostrando el menú
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

            opcion = Console.ReadLine(); // leer la opción del usuario

            switch (opcion) // evaluar la opción elegida
            {
                case "1": // si la opción es 1 buscamos un libro por código
                    Console.WriteLine("\n=== BUSCAR LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "2": // si la opción es 2 prestamos un libro
                    Console.WriteLine("\n=== PRESTAR LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "3": // si la opción es 3 devolvemos un libro
                    Console.WriteLine("\n=== DEVOLVER LIBRO ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "4": // si la opción es 4 mostramos el top 5 de libros más prestados de la biblioteca
                    Console.WriteLine("\n=== TOP 5 MAS PRESTADOS ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "5": // si la opción es 5 mostramos el top 5 de libros menos prestados de la biblioteca
                    Console.WriteLine("\n=== TOP 5 MENOS PRESTADOS ===");
                    Console.WriteLine("Funcion en construccion...");
                    break;

                case "6": // si la opción es 6 salimos del programa
                    Console.WriteLine("\nSaliendo del programa... ¡Hasta luego!");
                    break;

                default: // si no es ninguna de las opciones anteriores, mostramos un mensaje de error
                    Console.WriteLine("\nOpción no válida. Intenta de nuevo.");
                    break;
            }

            if (opcion != "6") // mientras la opcion elegida no sea salir el usuario podra presionar cualquier tecla para continuar 
                               // y volver al menu principal
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != "6"); // mientras la opcion elegida no sea salir seguimos mostrando el menú
    }
}