using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericBoxOfString;

public class Box<T>
{
    public override string ToString()
    {
        return $"{typeof(T).FullName}: {Value}";
    }

    public T Value { get; set; }

    public Box(T value)
    {
        this.Value = value;
    }
    
}