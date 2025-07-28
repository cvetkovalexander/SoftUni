using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person;

public class Person
{
    private readonly string _name;
    private readonly int _age;

    public string Name => this._name;
    public int Age => this._age;

    public Person(string name, int age)
    {
        this._name = name;
        this._age = age;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("{0} -> ",
            this.GetType().Name));
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
            this.Name,
            this.Age));

        return stringBuilder.ToString();
    }
}