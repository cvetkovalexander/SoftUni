using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> Members;

        public Family()
        {
            Members = new List<Person>();
        }

        public void AddMember(Person person)
        {
            Members.Add(person);
        }

        public Person GetOldestMember()
        {
            int max = int.MinValue;
            Person oldest = null;
            foreach (Person person in Members)
            {
                if (person.Age > max)
                {
                    max = person.Age;
                    oldest = person;
                }
            }
            return oldest;
        }

        public void PrintMembersOver30()
        {
            foreach (var p in Members.OrderBy(x => x.Name))
            {
                if (p.Age > 30)
                {
                    Console.WriteLine($"{p.Name} - {p.Age}");
                }
            }
        }
    }
}
