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
                    Console.Write("Ingrese el codigo del libro: ");
                    string codigoBuscar = Console.ReadLine();

                    Libro libroEncontrado = arbolBiblioteca.Buscar(codigoBuscar);

                    if (libroEncontrado != null)
                    {
                        Console.WriteLine("\n¡Libro encontrado!");
                        libroEncontrado.MostrarInformacion();
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontro ningun libro con el codigo: " + codigoBuscar);
                    }
                    break;

                case "2": // si la opción es 2 prestamos un libro
                    Console.WriteLine("\n=== PRESTAR LIBRO ===");
                    Console.Write("Ingrese el codigo del libro a prestar: ");
                    string codigoPrestar = Console.ReadLine();

                    Libro libroPrestar = arbolBiblioteca.Buscar(codigoPrestar);

                    if (libroPrestar != null)
                    {
                        if (libroPrestar.CopiasDisponibles > 0)
                        {
                            libroPrestar.CopiasDisponibles = libroPrestar.CopiasDisponibles - 1;
                            libroPrestar.VecesPrestado = libroPrestar.VecesPrestado + 1;

                            Console.WriteLine("\n¡Prestamo realizado con exito!");
                            Console.WriteLine("Libro: " + libroPrestar.Titulo);
                            Console.WriteLine("Copias restantes: " + libroPrestar.CopiasDisponibles);
                        }
                        else
                        {
                            Console.WriteLine("\nLo sentimos, no hay copias disponibles de este libro para prestar.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontro ningun libro con el codigo: " + codigoPrestar);
                    }
                    break;

                case "3": // si la opción es 3 devolvemos un libro
                    Console.WriteLine("\n=== DEVOLVER LIBRO ===");
                    Console.Write("Ingrese el codigo del libro a devolver: ");
                    string codigoDevolver = Console.ReadLine();

                    Libro libroDevolver = arbolBiblioteca.Buscar(codigoDevolver);

                    if (libroDevolver != null)
                    {
                        libroDevolver.CopiasDisponibles = libroDevolver.CopiasDisponibles + 1;

                        Console.WriteLine("\n¡Devolucion realizada con exito!");
                        Console.WriteLine("Libro: " + libroDevolver.Titulo);
                        Console.WriteLine("Copias disponibles ahora: " + libroDevolver.CopiasDisponibles);
                    }
                    else
                    {
                        Console.WriteLine("\nNo se encontro ningun libro con el codigo: " + codigoDevolver);
                    }
                    break;

                case "4": // si la opción es 4 mostramos el top 5 de libros más prestados de la biblioteca
                    maxHeap.MostrarTop(5);
                    break;

                case "5": // si la opción es 5 mostramos el top 5 de libros menos prestados de la biblioteca
                    minHeap.MostrarTop(5);
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