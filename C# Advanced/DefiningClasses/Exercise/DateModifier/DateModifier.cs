using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier;

public class DateModifier
{
    public void DifferenceBetween2(string first, string second)
    {
        string[] dataFirst = first.Split();
        DateTime firstDate = new DateTime(
        
            int.Parse(dataFirst[0]),
            int.Parse(dataFirst[1]),
            int.Parse(dataFirst[2])
        );
        string[] dataSecond = second.Split();
        DateTime secondDate = new DateTime(
            int.Parse(dataSecond[0]),
            int.Parse(dataSecond[1]),
            int.Parse(dataSecond[2])
        );
        Console.WriteLine(Math.Abs((firstDate - secondDate).Days));
    }
}