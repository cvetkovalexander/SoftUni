using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl;

public class Citizen : INamed, ISoldier, IBirthable
{
    public Citizen(string name, int age, string id, string birthDay)
    {
        Name = name;
        Age = age;
        Id = id;
        BirthDate = birthDay;
    }

    public string Name { get; }
    public int Age { get; }
    public string Id { get; }
    public string BirthDate { get; }
}
