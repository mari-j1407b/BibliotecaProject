using System;
using System.IO; // para trabajar con archivos

class BibliotecaService // clase con los métodos para que funcione la biblioteca
{

// MÉTODO PARA CARGAR LOS DATOS DEL ARCHIVO CSV
    public static void CargarDatosCSV(
        string rutaArchivo,
        ArbolBPlus arbol,
        MaxHeap maxHeap,
        MinHeap minHeap)
    {
        
        if (!File.Exists(rutaArchivo))// verificamos si el archivo existe en la ruta indicada
        {
            // si no existe el archivo
            Console.WriteLine("Error: El archivo CSV no existe en la ruta especificada: " + rutaArchivo);
            return; // el proceso continúa sin el archivo
        }

        try
        {
            // leemos todas las líneas del archivo y las guardamos en un arreglo
            string[] lineas = File.ReadAllLines(rutaArchivo);

            // inicializamos un contador para saber cuántos libros se cargaron
            int librosCargados = 0;

            // Empezamos en i = 1 para saltar la linea de encabezados del CSV
            for (int i = 1; i < lineas.Length; i++)
            {
                // guardamos la línea actual del archivo
                string linea = lineas[i];

                // verificamos si la línea está vacía
                if (string.IsNullOrWhiteSpace(linea))
                    continue; // si está vacía pasamos a la siguiente línea

                // separamos los datos de la línea usando la coma
                string[] datos = linea.Split(',');

                // verificamos que la línea tenga los 6 datos necesarios
                if (datos.Length >= 6)
                {
                    // obtenemos el código del libro y quitamos espacios innecesarios
                    string codigo = datos[0].Trim();

                    // obtenemos el título del libro
                    string titulo = datos[1].Trim();

                    // obtenemos el autor del libro
                    string autor = datos[2].Trim();

                    // obtenemos la categoría del libro
                    string categoria = datos[3].Trim();

                    // convertimos las copias disponibles a número entero
                    int copiasDisponibles = int.Parse(datos[4].Trim());

                    // convertimos la cantidad de préstamos a número entero
                    int vecesPrestado = int.Parse(datos[5].Trim());

                    // Instanciar el libro con sus 6 parámetros correspondientes
                    Libro nuevoLibro = new Libro(
                        codigo,
                        titulo,
                        autor,
                        categoria,
                        copiasDisponibles,
                        vecesPrestado);

                    // Insertar en las tres estructuras
                    arbol.Insertar(nuevoLibro); // insertamos el libro en el árbol B+
                    maxHeap.Insertar(nuevoLibro); // insertamos el libro en el Max Heap
                    minHeap.Insertar(nuevoLibro); // insertamos el libro en el Min Heap

                    // aumentamos el contador de libros cargados
                    librosCargados++;
                }
            }

            // mostramos la cantidad de libros que se cargaron correctamente
            Console.WriteLine("\n¡Exito! Se cargaron " + librosCargados + " libros correctamente.");
        }
        catch (Exception ex)
        {
            // mostramos el error que ocurrió si no se pudo leer o procesar el archivo
            Console.WriteLine("Ocurrio un error al leer el archivo CSV: " + ex.Message);
        }
    }
}