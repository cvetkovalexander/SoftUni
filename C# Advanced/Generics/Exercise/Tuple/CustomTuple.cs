using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuple;

public class CustomTuple<T1, T2, T3>
{
    public T1 FirstItem { get; set; }
    public T2 SecondItem { get; set; }
    public T3 ThirdItem { get; set; }

    public CustomTuple(T1 first, T2 second, T3 third)
    {
        FirstItem = first; SecondItem = second; ThirdItem = third;
    }

    public override string ToString()
    {
        return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
    }
}