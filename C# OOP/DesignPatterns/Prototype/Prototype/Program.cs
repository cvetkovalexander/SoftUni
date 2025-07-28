using Microsoft.Win32.SafeHandles;
using Prototype.Abstraction;

namespace Prototype;

public class Program
{
    public static void Main(string[] args)
    {
        Menu menu = new();
        menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");
        menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
        
        Sandwich blt = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
        Sandwich bltCopy = blt.ShallowCopy();       
        ISandwich s1 = menu["BLT"].ShallowCopy();
        ISandwich s2 = menu["Turkey"].ShallowCopy(); 
    }
}