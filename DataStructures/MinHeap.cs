// Min heap

using System;

class MinHeap
{
    private Libro[] arreglo;
    private int tamanio;

    public MinHeap(int capacidad)
    {
        arreglo = new Libro[capacidad];
        tamanio = 0;
    }



    // Insertar nuevo libro
    public void Insertar(Libro libro)
    {
        if (tamanio >= arreglo.Length)
        {
            Console.WriteLine("El MinHeap esta lleno.");
            return;
        }

        arreglo[tamanio] = libro;

        tamanio++;
        HeapifyUp(tamanio - 1);
    }



    // Heapify Up
    private void HeapifyUp(int indice)
    {
        while (indice > 0)
        {
            int indicePadre = (indice - 1) / 2;

            if (arreglo[indice].VecesPrestado < arreglo[indicePadre].VecesPrestado)
            {
                Libro temp = arreglo[indice];
                arreglo[indice] = arreglo[indicePadre];
                arreglo[indicePadre] = temp;

                indice = indicePadre;
            }
            else
            {
                break;
            }
        }
    }



    // Reorganizar el Heap cuando cambia la cantidad de prestamos
    public void Reorganizar()
    {
        for (int i = (tamanio / 2) - 1; i >= 0; i--)
        {
            HeapifyDown(i);
        }
    }



    // Obtener top libros menos prestados
    public void MostrarTop(int cantidad)
    {
        Console.WriteLine("\n=== TOP " + cantidad + " LIBROS MENOS PRESTADOS ===");

        // copia local para no destruir el Heap original
        MinHeap copia = new MinHeap(tamanio);

        for (int i = 0; i < tamanio; i++)
        {
            copia.Insertar(arreglo[i]);
        }

        // Extraemos la raiz para obtener los libros menos prestados
        int limite = Math.Min(cantidad, tamanio);

        for (int i = 0; i < limite; i++)
        {
            Libro menosPrestado = copia.ExtraerRaiz();

            if (menosPrestado != null)
            {
                Console.WriteLine((i + 1) + ". " + menosPrestado.Titulo + " (" + menosPrestado.VecesPrestado + " prestamos)");
            }
        }
    }



    // EXTRAER RAIZ (elemento menor)
    public Libro ExtraerRaiz()
    {
        if (tamanio == 0)
            return null;

        Libro raiz = arreglo[0];

        arreglo[0] = arreglo[tamanio - 1];
        tamanio--;

        HeapifyDown(0);

        return raiz;
    }



    // Heapify Down
    private void HeapifyDown(int indice)
    {
        while (indice < tamanio)
        {
            int hijoIzquierdo = (2 * indice) + 1;
            int hijoDerecho = (2 * indice) + 2;
            int menor = indice;

            if (hijoIzquierdo < tamanio &&
                arreglo[hijoIzquierdo].VecesPrestado < arreglo[menor].VecesPrestado)
            {
                menor = hijoIzquierdo;
            }

            if (hijoDerecho < tamanio &&
                arreglo[hijoDerecho].VecesPrestado < arreglo[menor].VecesPrestado)
            {
                menor = hijoDerecho;
            }

            if (menor != indice)
            {
                Libro temp = arreglo[indice];
                arreglo[indice] = arreglo[menor];
                arreglo[menor] = temp;

                indice = menor;
            }
            else
            {
                break;
            }
        }
    }
}