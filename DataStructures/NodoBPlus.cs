// Nodos para el arbol B+
// Orden 4
// max claves = m-1 = 3
// max hijos = m = 4
// min claves = (m/2)-1 = 1
// min hijos = m/2 = 2

using System; 
class NodoBPlus 
{ 
    public bool EsHoja { get; set; } 
    public int NumClaves { get; set; } 
    public Libro[] Claves { get; set; } // En hojas guarda Libros y nodos internos guarda indices 
    public NodoBPlus[] Hijos { get; set; } // Apuntadores a nodos hijos (solo nodos internos) 
    public NodoBPlus Siguiente { get; set; }// Enlace entre hojas
 
    public NodoBPlus(bool esHoja) 
    { 
        EsHoja = esHoja; 
        NumClaves = 0; 
        Claves = new Libro[3];  // Maximo 3 claves (m - 1) 
        Hijos = new NodoBPlus[4]; // Maximo 4 hijos (m) 
        Siguiente = null; 
    } 
}