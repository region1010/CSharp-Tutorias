namespace stringInterpolatiuon;

public class  InterpolationP{

    public static void Main(){
        
        //  &%  Introduction
        
        Console.WriteLine("Hello Interpolation program");
        double a  =  3;
        double b  =  4;
        Console.WriteLine($"Area with the right triangle with legs of"+ 
        $" {a} and {b} is {0.5*a*b}");
        Console.WriteLine($"Length of the hipotenusa "+
        $"of the right triangle whith legs of {a} and {b}, "+
        $"{CalculateHypotenusa(a,b)}");
        double CalculateHypotenusa(double leg1,double leg2)
        =>  Math.Sqrt(leg1*leg1+leg2*leg2);
        
        
        //  &%  How to specify a format string for an interpolation expression
        
        var  date  =  new  DateTime(1731, 11, 25);
        Console.WriteLine($"On {date:dddd,MMMM dd, yyyy} L. Euler introduced the letter e "+
        $"to denote {Math.E:F5}");
        
        
        
        //  &%  How to control the field width and alignment of the formatted interpolation expression
        
        const int NameAlignment  =  -9;
        const int ValueAlignment  =  7;
        double  c  =  3;
        double  d  =  4;
        Console.WriteLine($"Three classical Pythagorean means of "+
        $"{c} and {d}: \n"+$"|{"Arithmetic", NameAlignment}|{0.5*(c+d),ValueAlignment:F1}");
        Console.WriteLine($"Three classical Pythagorean means of "+
        $"{c} and {d}: \n"+$"|{"Geometric",NameAlignment}|{Math.Sqrt(c*d),ValueAlignment:F1}");
        Console.WriteLine($"Three classical Pythagorean means of "+
        $"{c} and {d}: \n"+$"|{"Harmonic",NameAlignment}|{2/(1/c+1/d),ValueAlignment:F1}");
        
        //  &%  How to use escape sequences in an interpolation string
        
        var  xs  =  new  int[]  {1,2,7,9};
        var  ys  =  new  int[]  {7,9,12};
        Console.WriteLine($"Find the interpolation of the {{{string.Join(", ", xs)}}} and {{{string.Join(", ", ys)}}} sets.");
        
        var  userName  =  "aleja";
        var  stringWithEscapes  =  $"C:\\Users\\{userName}\\OneDrive\\Documentos";
        var  verbatimInterpolation  =  @$"C:\Users\{userName}\OneDrive\Documentos";
        Console.WriteLine(stringWithEscapes);
        Console.WriteLine(verbatimInterpolation);
        
        //  &%  How to use a ternary condition operator
        //  ?: in an interpolation expression
        
        var rand  =  new  Random();
        for(int  i=0;  i<7;  i++){
        
            Console.WriteLine($"Coin file: {(rand.NextDouble()<0.5 ? "heads" :"tails")}");
        
        }
        
        //  &%  How to create a culture-specific result string
        //  with string interpolation
        
        var cultures  =  new  System.Globalization.CultureInfo[]{
        
            System.Globalization.CultureInfo.GetCultureInfo("en-US"),
            System.Globalization.CultureInfo.GetCultureInfo("en-GB"),
            System.Globalization.CultureInfo.GetCultureInfo("nl-NL"),
            System.Globalization.CultureInfo.InvariantCulture
        
        };
        
        var  date1  =    DateTime.Now;
        var  number  =  31_415_926.536;
        foreach(var  culture  in  cultures){
        
            var  cultureSpecificMessage  =  string.Create(
                culture,  $"{date,23}{number,20:N3}");
            Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
        
        }
        
        FormattableString  message  =  $"{date,23}{number,20:N3}";
        foreach(var  culture  in  cultures){
        
            var  cultureSpecificMessage  =  message.ToString(culture);
            Console.WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
        
        }
        
        //  &%  How to create a result string using the invariant culture
        
        string message2  =  string.Create(System.Globalization.CultureInfo.InvariantCulture,
            $"Date and time in invariant Culture: {DateTime.Now}"
        );
        Console.WriteLine(message2);
        
        string message3  =  FormattableString.Invariant(
        
            $"Date and time in invariant culture: {DateTime.Now}"
        
        );
        Console.WriteLine(message3);
    }

}