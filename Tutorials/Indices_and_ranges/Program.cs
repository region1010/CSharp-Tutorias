using BIBLIOTECA;

namespace Indices_and_ranges;

public class Indicesandranges{

    public static void Main()
    {

        Indice index = new Indice();

        var dato = index.Liststring();
        Console.WriteLine();
        Console.WriteLine(dato);
        dato = index.Listint();
        Console.WriteLine(dato);
        Console.WriteLine();
        dato = index.Implicit_Range(); 
        Console.Write(dato);
        Console.WriteLine();
        dato = index.Sup_Indices_ranges();
        Console.Write(dato);
    }

}