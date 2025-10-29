using System;
using System.Linq;

namespace BIBLIOTECA;

public class Indice
{

    private string[] words = [

        "first",
        "second",
        "third",
        "fourth",
        "fiveth",
        "sixth",
        "seventh",
        "eighth",
        "nineth",
        "ten",

    ];

    private int[] numbers = [
        ..Enumerable.Range(0,100)
    ];

    private Range explicitRange = new(
        start: new Index(value: 3, fromEnd: false),
        end: new Index(value: 5, fromEnd: false)
        );
    
    private int[][] jagged ={
    
        [0, 1, 2, 3, 4, 5, 6, 7, 8, 9],
        [10,11,12,13,14,15,16,17,18,19],
        [20,21,22,23,24,25,26,27,28,29],
        [30,31,32,33,34,35,36,37,38,39],
        [40,41,42,43,44,45,46,47,48,49],
        [50,51,52,53,54,55,56,57,58,59],
        [60,61,62,63,64,65,66,67,68,69],
        [70,71,72,73,74,75,76,77,78,79],
        [80,81,82,83,84,85,86,87,88,89],
        [90,91,92,93,94,95,96,97,98,99]
    
    };

    public string Liststring() {

        string[] secondThirdFourth = words[1..4];
        string[] lastwo = words[^2..^0];
        string[] allwords = words[..];
        string[] firstPhrase = words[..4];
        string[] lastPhrase = words[6..];

        foreach (var word in secondThirdFourth) Console.Write($"{word}");
        foreach (var word in lastwo) Console.Write($"{word}");
        Console.WriteLine();
        foreach (var word in allwords) Console.Write($"{word}");
        Console.WriteLine();
        foreach (var word in firstPhrase) Console.Write($"{word}");
        Console.WriteLine();
        foreach (var word in lastPhrase) Console.Write($"{word}");
        Console.WriteLine();
        Index thirdFromEnd = ^3;
        Console.WriteLine($"<{words[thirdFromEnd]}>");
        Range phrase = 1..4;
        string[] text = words[phrase];

        foreach (var word in text) Console.WriteLine($"{word}");
        return $"The last word is <{words[^1]}>";
    }

    public string Listint() {

        int x = 12;
        int y = 25;
        int z = 36;
        Console.WriteLine($"{numbers[x..y].Length} is the same as {y - x}");
        Console.WriteLine("numbers[x..y] and numbers[y..z] are consoecutive and disjoint:");
        Span<int> x_y = numbers[x..y];
        Span<int> y_z = numbers[y..z];
        Console.WriteLine($"\tnumbers[x..y] is {x_y[0]} through {x_y[^1]}, tnumbers[y..z] is {y_z[0]} through {y_z[^1]}, ");
        Console.WriteLine("numbers[x..^x] removesz x elements at each end:");
        Span<int> x_x = numbers[x..^x];
        Console.WriteLine($"\tnumbers[x..^x] starts with {x_x[0]} and ends with {x_x[^1]}");
        Console.WriteLine("numbers[..x] means numbers[0..x] and numbers[x..] means numbers[x..^0]");
        Span<int> start_x = numbers[..x];
        Span<int> zero_x = numbers[0..x];
        Console.WriteLine($"\t{start_x[0]}..{start_x[^1]} is the same as {zero_x[0]}..{zero_x[^1]}");
        Span<int> z_end = numbers[z..];
        Span<int> z_zero = numbers[z..^0];
        Console.WriteLine($"\t{z_end[0]}..{z_end[^1]} is the same as {z_zero[0]}..{z_zero[^1] }");
        return $"{numbers[^x]} is the same as {numbers[numbers.Length - x]}";
    }

    public string Implicit_Range() {

        Range implicitRange = 3..^5;

        if (implicitRange.Equals(explicitRange)) {

            Console.WriteLine(
                $"The implicit range '{implicitRange}' equals teh explicit range '{explicitRange}'"
            );
        }


        return "Implicit_Range";
    }
    
    public string Sup_Indices_ranges(){
    
        int[]  sequence = Sequence(1000);
    
        var  selectedRows = jagged[3..^3];
        
        foreach(var row in selectedRows){
        
            var  selectedColumns  =  row[2..^2];
            foreach(var  cell in selectedColumns){
            
                Console.Write($"{cell}, ");
            
            }
            Console.WriteLine();
        
        }
        
        for(int start = 0; start < sequence.Length; start += 100){
        
            Range r = start..(start+10);
            var (min, max, avarage) = MovingAvarage(sequence, r);
            Console.WriteLine($"From {r.Start} to {r.End}:  \tMin {min}, \tMax: {max}, \tAvarage: {avarage}");
        
        }
        
        for(int start  =  0; start < sequence.Length; start += 100){
          Range r = ^(start+10)..^start;
          var (min, max, avarage) = MovingAvarage(sequence, r);
          Console.WriteLine($"From {r.Start} to {r.End}:  \tMin {min}, \tMax: {max}, \tAvarage: {avarage}");
        
        }
        
        (int min, int max, double avarage) MovingAvarage(int[] subSequence, Range range)  =>  (
        
            subSequence[range].Min(),
            subSequence[range].Max(),
            subSequence[range].Average()
        
        );
        
        int[] Sequence(int count)  =>  [..Enumerable.Range(0, count).Select(x => (int)(Math.Sqrt(x) * 100))];
        
        return "Sup_Indices_ranges";
    }
    
    public string Indices_Arrays(){
    
        var  arrayOffiveItems  =  new[]{1, 2, 3, 4, 5};
        
        var  firstThreeItems  =  arrayOffiveItems[..3];
        firstThreeItems[0]  =  11;
        
        Console.WriteLine(string.Join(",", firstThreeItems));
        Console.WriteLine(string.Join(",", arrayOffiveItems));
        
        return  "Sup_Indices_ranges";
    
    }

    
}
