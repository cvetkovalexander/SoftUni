using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony;

public class StationaryPhone : ICaller
{
    public string Call(string number)
    {
        if (number.Any(char.IsLetter))
            return "Invalid number!";
        
        return $"Dialing... {number}";
    }
}
