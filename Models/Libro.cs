// plantilla para cada libro
using System;


class Libro
{
    public string codigo;
    public string titulo;
    public string autor;
    public string categoria;
    public int copiasDisponibles;
    public int vecesPrestado;

    // Se corrigen las asignaciones de variables
    public Libro(string codigo, string titulo, string autor, string categoria, int copiasDisponibles, int vecesPrestado)
    {
        this.codigo = codigo;
        this.titulo = titulo;
        this.autor = autor;
        this.categoria = categoria;
        this.copiasDisponibles = copiasDisponibles;
        this.vecesPrestado = vecesPrestado;
    }

   
    public void MostrarInformacion()
    {
        Console.WriteLine("Codigo: " + codigo + " | Titlo: " + titulo + " | Autor: " + autor + " | Categoria: " + categoria + " | Copias: " + copiasDisponibles + " | Veces Prestado: " + vecesPrestado);
    }
}