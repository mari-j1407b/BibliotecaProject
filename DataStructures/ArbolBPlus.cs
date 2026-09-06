// arbol b (orden 4)
// max claves = m-1 = 3
// max hijos = m = 4
// min claves = (m/2)-1 = 1
// min hijos = m/2 = 2

using System;

class ArbolBPlus // clase para el arbol b+
{
    private NodoBPlus raiz; // variable raíz con las características de un nodo del arbol b+

    public ArbolBPlus() // construimos el arbol
    {
        raiz = new NodoBPlus(true); // creamos la raíz como un nodo hoja
    }

    // MÉTODO BUSCAR LIBRO POR CODIGO
    public Libro Buscar(string codigo) // recibe un código de libro en fomra de cadena 
    {
        return BuscarEnNodo(raiz, codigo); // y devuelve el libro correspondiente si se encuentra en el árbol B+, o null si no se encuentra.
    }

    // MÉTODO PRIVADO PARA BUSCAR EN UN NODO
    private Libro BuscarEnNodo(NodoBPlus nodo, string codigo) // recibe un nodo del árbol B+ y un código de libro 
    {
        int i = 0; // inicializamos un índice i en 0 para recorrer las claves del nodo desde la posición 0

        // recorremos las claves mientras el código buscado sea mayor
        while (i < nodo.NumClaves && 
               string.Compare(
                   codigo,
                   nodo.Claves[i].Codigo,
                   StringComparison.OrdinalIgnoreCase) > 0)
        {
            i++; // aumentamos el índice para pasar a la siguiente clave
        }

        // verificamos si el nodo actual es una hoja
        if (nodo.EsHoja)
        {
            // comprobamos si encontramos el código buscado
            if (i < nodo.NumClaves &&
                string.Compare(
                    codigo,
                    nodo.Claves[i].Codigo,
                    StringComparison.OrdinalIgnoreCase) == 0)
            {
                return nodo.Claves[i]; // devolvemos el libro encontrado
            }

            return null; // si no encontramos el libro devolvemos null
        }

        // si no es una hoja bajamos al hijo correspondiente
        return BuscarEnNodo(nodo.Hijos[i], codigo);
    }

    // INSERTAR LIBRO
    public void Insertar(Libro libro)
    {
        NodoBPlus r = raiz; // guardamos la raíz actual en la variable r

        // verificamos si la raíz está llena
        if (r.NumClaves == 3)
        {
            // creamos una nueva raíz que será un nodo interno
            NodoBPlus nuevaRaiz = new NodoBPlus(false);

            // colocamos la raíz anterior como primer hijo de la nueva raíz
            nuevaRaiz.Hijos[0] = raiz;

            // dividimos la raíz anterior porque estaba llena
            DividirHijo(nuevaRaiz, 0, raiz);

            // actualizamos la raíz del árbol
            raiz = nuevaRaiz;

            // insertamos el nuevo libro en el árbol que ya tiene espacio
            InsertarNoLleno(raiz, libro);
        }
        else
        {
            // si la raíz no está llena insertamos directamente
            InsertarNoLleno(r, libro);
        }
    }

    // MÉTODO PARA INSERTAR EN UN NODO QUE NO ESTÁ LLENO
    private void InsertarNoLleno(NodoBPlus nodo, Libro libro)
    {
        int i = nodo.NumClaves - 1; // empezamos desde la última clave del nodo

        // verificamos si el nodo actual es una hoja
        if (nodo.EsHoja)
        {
            // buscamos la posición donde debe ir el nuevo libro
            while (i >= 0 &&
                   string.Compare(
                       libro.Codigo,
                       nodo.Claves[i].Codigo,
                       StringComparison.OrdinalIgnoreCase) < 0)
            {
                // movemos la clave una posición hacia la derecha
                nodo.Claves[i + 1] = nodo.Claves[i];

                i--; // retrocedemos para seguir comparando
            }

            // colocamos el nuevo libro en la posición encontrada
            nodo.Claves[i + 1] = libro;

            // aumentamos la cantidad de claves del nodo
            nodo.NumClaves++;
        }
        else
        {
            // buscamos cuál es el hijo donde debe ir el nuevo libro
            while (i >= 0 &&
                   string.Compare(
                       libro.Codigo,
                       nodo.Claves[i].Codigo,
                       StringComparison.OrdinalIgnoreCase) < 0)
            {
                i--; // retrocedemos para encontrar el hijo correcto
            }

            i++; // avanzamos a la posición del hijo correspondiente

            // verificamos si el hijo está lleno
            if (nodo.Hijos[i].NumClaves == 3)
            {
                // dividimos el hijo antes de insertar el nuevo libro
                DividirHijo(nodo, i, nodo.Hijos[i]);

                // verificamos si el libro debe ir en el nuevo hijo
                if (string.Compare(
                    libro.Codigo,
                    nodo.Claves[i].Codigo,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    i++; // pasamos al hijo de la derecha
                }
            }

            // insertamos el libro en el hijo correspondiente
            InsertarNoLleno(nodo.Hijos[i], libro);
        }
    }

    // DIVIDIR NODO (SPLIT)
    private void DividirHijo(NodoBPlus padre, int i, NodoBPlus hijo)
    {
        // creamos un nuevo nodo del mismo tipo que el hijo
        NodoBPlus nuevoNodo = new NodoBPlus(hijo.EsHoja);

        // verificamos si el nodo que vamos a dividir es una hoja
        if (hijo.EsHoja)
        {
            // copiamos la última clave del hijo al nuevo nodo
            nuevoNodo.Claves[0] = hijo.Claves[2];

            // el nuevo nodo comienza con una clave
            nuevoNodo.NumClaves = 1;

            // el nodo original se queda con las primeras dos claves
            hijo.NumClaves = 2;

            // conectamos el nuevo nodo con la siguiente hoja
            nuevoNodo.Siguiente = hijo.Siguiente;

            // hacemos que el nodo original apunte al nuevo nodo
            hijo.Siguiente = nuevoNodo;

            // movemos las claves y los hijos del padre para hacer espacio
            for (int j = padre.NumClaves; j > i; j--)
            {
                // movemos las claves del padre una posición a la derecha
                padre.Claves[j] = padre.Claves[j - 1];

                // movemos también los hijos una posición a la derecha
                padre.Hijos[j + 1] = padre.Hijos[j];
            }

            // copiamos al padre la primera clave del nuevo nodo
            padre.Claves[i] = nuevoNodo.Claves[0];

            // colocamos el nuevo nodo como hijo del padre
            padre.Hijos[i + 1] = nuevoNodo;

            // aumentamos la cantidad de claves del padre
            padre.NumClaves++;
        }
        else
        {
            // copiamos la última clave del hijo al nuevo nodo
            nuevoNodo.Claves[0] = hijo.Claves[2];

            // el nuevo nodo comienza con una clave
            nuevoNodo.NumClaves = 1;

            // copiamos los dos últimos hijos al nuevo nodo
            nuevoNodo.Hijos[0] = hijo.Hijos[2];
            nuevoNodo.Hijos[1] = hijo.Hijos[3];

            // guardamos la clave del medio que será promovida al padre
            Libro clavePromovida = hijo.Claves[1];

            // el nodo original se queda con una sola clave
            hijo.NumClaves = 1;

            // movemos las claves y los hijos del padre para hacer espacio
            for (int j = padre.NumClaves; j > i; j--)
            {
                // movemos las claves del padre una posición a la derecha
                padre.Claves[j] = padre.Claves[j - 1];

                // movemos los hijos del padre una posición a la derecha
                padre.Hijos[j + 1] = padre.Hijos[j];
            }

            // colocamos la clave promovida en el padre
            padre.Claves[i] = clavePromovida;

            // colocamos el nuevo nodo como hijo del padre
            padre.Hijos[i + 1] = nuevoNodo;

            // aumentamos la cantidad de claves del padre
            padre.NumClaves++;
        }
    }

    // Mostrar todos los libros
    public void MostrarTodos()
    {
        NodoBPlus actual = raiz; // empezamos el recorrido desde la raíz

        // bajamos por el primer hijo hasta llegar a la primera hoja
        while (!actual.EsHoja)
        {
            actual = actual.Hijos[0];
        }

        // mostramos un título antes de mostrar los libros
        Console.WriteLine("\nCatálogo de Libros:");

        // recorremos todas las hojas del árbol
        while (actual != null)
        {
            for (int i = 0; i < actual.NumClaves; i++) // recorremos las claves que tiene la hoja actual
            {

                actual.Claves[i].MostrarInformacion(); // mostramos la información de cada libro
            }


            actual = actual.Siguiente;  // pasamos a la siguiente hoja usando el enlace Siguiente
        }
    }
}