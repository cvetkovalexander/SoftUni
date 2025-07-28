using Singleton.Models;

namespace Singleton;

public class Program
{
    static void Main(string[] args)
    {
        var c1 = SingletonContainer.Instance;
        var c2 = SingletonContainer.Instance;
        var c3 = SingletonContainer.Instance;
        var c4 = SingletonContainer.Instance;
    }
}