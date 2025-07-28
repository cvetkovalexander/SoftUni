using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models;

public class Pet
{
    [MyRequired, MyLength(10)]
    public string Name { get; }
    [MyRequired]
    public string Breed { get; }

    public Pet(string name, string breed)
    {
        this.Name = name;
        this.Breed = breed;
    }
}