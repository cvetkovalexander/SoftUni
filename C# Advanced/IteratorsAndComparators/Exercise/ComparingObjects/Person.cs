using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparingObjects;

public class Person : IComparable<Person>
{
    private readonly string _name;
    private readonly int _age;
    private readonly string _town;

    public Person(string name, int age, string town)
    {
        this._name = name;
        this._age = age;
        this._town = town;
    }
    public int CompareTo(Person? other)
    {
        // -1 -> this < other
        // 0 -> this = other
        // +1 -> this > other

        int nameComparison = Comparer<string>.Default.Compare(this._name, other._name);
        if (nameComparison != 0) return nameComparison;

        int ageComparison = Comparer<int>.Default.Compare(this._age, other._age);
        if (ageComparison != 0) return ageComparison;

        int townComparison = Comparer<string>.Default.Compare(this._town, other._town);
        return townComparison;
    }
}