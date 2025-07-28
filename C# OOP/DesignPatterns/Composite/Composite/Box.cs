using Composite.Contracts;

namespace Composite;

public class Box : IGift
{
    private readonly List<IGift> gifts = new List<IGift>();   
    public Box(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }
    public string Name { get; }
    public decimal Price { get; }
}