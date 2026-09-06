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

        if (r.NumClaves < 3) 
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
    }
}