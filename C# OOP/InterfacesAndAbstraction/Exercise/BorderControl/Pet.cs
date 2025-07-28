using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl;

public class Pet : INamed, IBirthable
{
    public Pet(string name, string date)
    {
        Name = name;
        BirthDate = date;
    }
    public string Name { get; }
    public string BirthDate { get; }
}