using Composite.Contracts;

namespace Composite;

public class Gift : IGift
{
    public Gift(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
        if (price <= 0) throw new ArgumentOutOfRangeException("Price cannot be less or equal to zero");
        this.Name = name;
        this.Price = price;
    }
    public string Name { get; }
    public decimal Price { get; }
}