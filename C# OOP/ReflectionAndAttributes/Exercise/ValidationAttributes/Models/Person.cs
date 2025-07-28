using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models;

public class Person
{
    [MyRequired, MyLength(5)]
    public string FullName { get; }

    [MyRange(12, 90)]
    public int Age { get; }

    [MyRequired, MyValidCollection]
    public IImmutableList<Pet> Pets { get; }
    public Person(string fullName, int age, IImmutableList<Pet> pets)
    {
        FullName = fullName;
        Age = age;
        this.Pets = pets;
    }

}