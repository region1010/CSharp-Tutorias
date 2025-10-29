using System;

namespace BIBLIOTECA;

public class Vegetable
{
    public Vegetable(string name)  => Name = name;
    
    public string Name {get;}
    
    public override string ToString()  =>  Name;
}

