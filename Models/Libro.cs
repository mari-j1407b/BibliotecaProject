// plantilla para un libro
using System;

class Libro
{
    public string codigo;
    public string titulo;
    public string autor;
    public string categoria;
    public int copiasDisponibles;
    public int vecesPrestado;

    public Libro(string codigo, string titulo, string autor, string categoria, int copiasDisponibles, int vecesPrestado)
    {
    }

    public void MostrarInformacion()
    {
        Console.WriteLine("Codigo: " + codigo + " | Titlo: " + titulo + " | Autor: " + autor + " | Categoria: " + categoria + " | Copias: " + copiasDisponibles + " | Veces Prestado: " + vecesPrestado);
    }
}