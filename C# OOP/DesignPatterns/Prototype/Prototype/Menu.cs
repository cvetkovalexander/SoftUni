using Prototype.Abstraction;

namespace Prototype;

public class Menu
{
    private readonly Dictionary<string, ISandwich> _sandwiches = new();

    public ISandwich this[string name]
    {
        get => this._sandwiches[name];
        set => this._sandwiches[name] = value;  
    }
}