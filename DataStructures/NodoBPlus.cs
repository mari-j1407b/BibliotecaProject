using System;

class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
}

class NodoBPlus
{
    public bool EsHoja { get; set; }
    public Libro[] Claves { get; set; }
}

class Program
{
    static void Main()
    {
        NodoBPlus nodo = new NodoBPlus();

        Console.WriteLine("Nodo creado");
    }
}