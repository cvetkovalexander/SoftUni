using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods().Where(m => m.GetCustomAttributes<AuthorAttribute>().Count() > 0).ToArray();

        foreach (MethodInfo method in methods)
        {
            AuthorAttribute[] authorAttributes = method.GetCustomAttributes<AuthorAttribute>().ToArray();
            foreach (AuthorAttribute authorAttribute in authorAttributes)
            {
                Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
            }
        }
    }
}