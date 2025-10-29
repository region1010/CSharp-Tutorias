using System;
using System.Collections.Generic;
using BIBLIOTECA;

namespace evi_string_interpl;

public class  ESInter{
    
    public enum Unit{item, kilogram, gram, dozen};
    
    public static void Main(){
    
        var  name  =  "Alejandro";
        Console.WriteLine($"Hello, {name}. It's a pleasure to meet you!");
        var  item  =  new  Vegetable("eggplant");
        var  date  =  DateTime.Now;
        var  price  =  1.99m;
        var  unit  =  Unit.item;
        Console.WriteLine($"On {date:d}, the price of {item} was {price:C2} per {unit}.");
        Console.WriteLine($"On {date:t}, the price of {item} was {price:e} per {unit}.");
        Console.WriteLine($"On {date:y}, the price of {item} was {price:F3} per {unit}.");
        Console.WriteLine($"On {date:yyyy}, the price of {item} was {price:C2} per {unit}.");
    
        /////////////////////////////////
        Dictionary<string,  string> titles  =  new  Dictionary<string,  string>() {
        
            ["Doyle, Arthur Connan"]  =   "Hound of the Baskervilles, The",
            ["London, Jack"]  =  "Call of the wild",
            ["Shakespear, william"]  =  "Tempest. The"
        
        };
        
        Console.WriteLine("Author and Title List");
        Console.WriteLine();
        Console.WriteLine($"|{"Author", 25}|{"Title", 30}|");
        foreach(var title in titles){
        
            Console.WriteLine($"|{title.Key, 25}|{title.Value, 30}|");
        }
        
        Console.WriteLine($"[{DateTime.Now,-25:d}] Hour [{DateTime.Now,-10:HH}][{1063.342,11:N2}] feet");
    } 

}

