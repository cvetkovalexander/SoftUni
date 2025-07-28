using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony;

public class Smartphone : ICaller, IBrowser
{
    public string Call(string number)
    {
        if (number.Any(char.IsLetter))
            return "Invalid number!";
        return $"Calling... {number}";
    }

    public string Browse(string website)
    {
        if (website.Any(char.IsDigit)) return "Invalid URL!";
        return $"Browsing: {website}!";
    }
}