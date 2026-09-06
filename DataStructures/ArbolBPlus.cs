// arbol b (orden 4)

using System;
class ArbolBPlus
{
    private NodoBPlus raiz;

    public ArbolBPlus()
    {
        raiz = new NodoBPlus(true);
    }

    // BUSCAR LIBRO POR CODIGO
    public Libro Buscar(string codigo)
    {
        return BuscarEnNodo(raiz, codigo);
    }

    private Libro BuscarEnNodo(NodoBPlus nodo, string codigo)
    {
        int i = 0;

        while (i < nodo.NumClaves &&
               string.Compare(
                   codigo,
                   nodo.Claves[i].Codigo,
                   StringComparison.OrdinalIgnoreCase) > 0)
        {
            i++;
        }

        if (nodo.EsHoja)
        {
            if (i < nodo.NumClaves &&
                string.Compare(
                    codigo,
                    nodo.Claves[i].Codigo,
                    StringComparison.OrdinalIgnoreCase) == 0)
            {
                return nodo.Claves[i];
            }

            return null;
        }

        return BuscarEnNodo(nodo.Hijos[i], codigo);
    }

    // INSERTAR LIBRO
    public void Insertar(Libro libro)
    {
        NodoBPlus r = raiz;

        if (r.NumClaves == 3)
        {
            NodoBPlus nuevaRaiz = new NodoBPlus(false);
            nuevaRaiz.Hijos[0] = raiz;

            DividirHijo(nuevaRaiz, 0, raiz);

            raiz = nuevaRaiz;
            InsertarNoLleno(raiz, libro);
        }
        else
        {
            InsertarNoLleno(r, libro);
        }
    }

    private void InsertarNoLleno(NodoBPlus nodo, Libro libro)
    {
        int i = nodo.NumClaves - 1;

        if (nodo.EsHoja)
        {
            while (i >= 0 &&
                   string.Compare(
                       libro.Codigo,
                       nodo.Claves[i].Codigo,
                       StringComparison.OrdinalIgnoreCase) < 0)
            {
                nodo.Claves[i + 1] = nodo.Claves[i];
                i--;
            }

            nodo.Claves[i + 1] = libro;
            nodo.NumClaves++;
        }
        else
        {
            while (i >= 0 &&
                   string.Compare(
                       libro.Codigo,
                       nodo.Claves[i].Codigo,
                       StringComparison.OrdinalIgnoreCase) < 0)
            {
                i--;
            }

            i++;

            if (nodo.Hijos[i].NumClaves == 3)
            {
                DividirHijo(nodo, i, nodo.Hijos[i]);

                if (string.Compare(
                    libro.Codigo,
                    nodo.Claves[i].Codigo,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    i++;
                }
            }

            InsertarNoLleno(nodo.Hijos[i], libro);
        }
    }

    // DIVIDIR NODO (SPLIT)
    private void DividirHijo(NodoBPlus padre, int i, NodoBPlus hijo)
    {
        NodoBPlus nuevoNodo = new NodoBPlus(hijo.EsHoja);

        if (hijo.EsHoja)
        {
            nuevoNodo.Claves[0] = hijo.Claves[2];
            nuevoNodo.NumClaves = 1;

            hijo.NumClaves = 2;

            nuevoNodo.Siguiente = hijo.Siguiente;
            hijo.Siguiente = nuevoNodo;

            for (int j = padre.NumClaves; j > i; j--)
            {
                padre.Claves[j] = padre.Claves[j - 1];
                padre.Hijos[j + 1] = padre.Hijos[j];
            }

            padre.Claves[i] = nuevoNodo.Claves[0];
            padre.Hijos[i + 1] = nuevoNodo;
            padre.NumClaves++;
        }
        else
        {
            nuevoNodo.Claves[0] = hijo.Claves[2];
            nuevoNodo.NumClaves = 1;

            nuevoNodo.Hijos[0] = hijo.Hijos[2];
            nuevoNodo.Hijos[1] = hijo.Hijos[3];

            Libro clavePromovida = hijo.Claves[1];

            hijo.NumClaves = 1;

            for (int j = padre.NumClaves; j > i; j--)
            {
                padre.Claves[j] = padre.Claves[j - 1];
                padre.Hijos[j + 1] = padre.Hijos[j];
            }

            padre.Claves[i] = clavePromovida;
            padre.Hijos[i + 1] = nuevoNodo;
            padre.NumClaves++;
        }
    }
}