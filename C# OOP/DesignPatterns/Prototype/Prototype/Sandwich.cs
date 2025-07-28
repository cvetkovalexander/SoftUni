using Prototype.Abstraction;

namespace Prototype;

public class Sandwich : ISandwich, IMakeShallowCopy<Sandwich>, IMakeDeepCopy<Sandwich>
{
    private string _bread, _meat, _cheese, _veggetables;

    public Sandwich(string bread, string meat, string cheese, string veggetables)
    {
        this._bread = bread;
        this._meat = meat;
        this._cheese = cheese;
        this._veggetables = veggetables;
    }

    public Sandwich ShallowCopy()
    {
        Console.WriteLine($"Making shallow copy of a sandwich with ingredients: Bread - {this._bread}, Meat - {this._meat}, Cheese - {this._cheese}, Vegetables - {this._veggetables}");
        return new Sandwich(this._bread, this._meat, this._cheese, this._veggetables);
    }

    public Sandwich DeepCopy()
    {
        Console.WriteLine($"Making deep copy of a sandwich with ingredients: Bread - {this._bread}, Meat - {this._meat}, Cheese - {this._cheese}, Vegetables - {this._veggetables}");
        return new Sandwich(new string(this._bread), new string(this._meat), new string(this._veggetables), this._meat);    
    }

    ISandwich IMakeShallowCopy<ISandwich>.ShallowCopy() => this.ShallowCopy();
    ISandwich IMakeDeepCopy<ISandwich>.DeepCopy() => this.DeepCopy();
}