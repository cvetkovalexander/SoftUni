using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EqualityLogic;

public class Person : IComparable<Person>, IEquatable<Person>
{
    private readonly string _name;
    private readonly int _age;

    public Person(string name, int age)
    {
        this._name = name;
        this._age = age;
    }

    public int CompareTo(Person? other)
    {
        int nameComparison = Comparer<string>.Default.Compare(this._name, other._name);
        if (nameComparison != 0) return nameComparison;

        int ageComparison = Comparer<int>.Default.Compare(this._age, other._age);
        return ageComparison;
    }

    public bool Equals(Person? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;

        return EqualityComparer<string>.Default.Equals(this._name, other._name) && EqualityComparer<int>.Default.Equals(this._age, other._age);
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Person p) return false;
        return this.Equals(p);
    }

    public override int GetHashCode()
        => HashCode.Combine(this._name, this._age);
}