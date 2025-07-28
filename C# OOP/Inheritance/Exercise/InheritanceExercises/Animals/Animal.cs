using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals;

public class Animal
{
    public Animal(string name, int age, string gender)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Animal should not have empty name.", nameof(name));
        if (age < 0) throw new ArgumentException("Animal should not have negative age.", nameof(age));
        if (string.IsNullOrWhiteSpace(gender))
            throw new ArgumentException("Animal should not have empty gender.", nameof(gender));

        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name { get; }
    public int Age { get; }
    public string Gender { get; }

    public virtual string ProduceSound() => "";

    public override string ToString()
    {
        StringBuilder output = new();
        output.AppendLine(this.GetType().Name);
        output.AppendLine($"{this.Name} {this.Age} {this.Gender}");
        output.AppendLine(this.ProduceSound());
        return output.ToString().Trim();
    }
}