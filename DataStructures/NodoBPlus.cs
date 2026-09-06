// Nodos para el arbol B+
// Orden 4
// max claves = m-1 = 3
// max hijos = m = 4
// min claves = (m/2)-1 = 1
// min hijos = m/2 = 2

using System;

class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
}

class NodoBPlus
{
    public bool EsHoja { get; set; }
    public int NumClaves { get; set; }
    public Libro[] Claves { get; set; }
    public NodoBPlus[] Hijos { get; set; }
    public NodoBPlus Siguiente { get; set; }

    public NodoBPlus(bool esHoja)
    {
        EsHoja = esHoja;
        NumClaves = 0;
        Claves = new Libro[3];
        Hijos = new NodoBPlus[4];
        Siguiente = null;
    }
}

class Program
{
    static void Main()
    {
        NodoBPlus hoja = new NodoBPlus(true);
        NodoBPlus interno = new NodoBPlus(false);

        Console.WriteLine("Hoja: " + hoja.EsHoja);
        Console.WriteLine("Interno: " + interno.EsHoja);
    }
}