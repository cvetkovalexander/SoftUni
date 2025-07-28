using System;
using System.Collections.Immutable;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Pet dog = new("Dog #1", "dog");
            Pet cat = new("Cat #1", "cat");
            Pet invalidPet = new(null, null);

            Person person = new("Alex", 13, ImmutableArray.Create(dog, cat, invalidPet));


           
            foreach (string error in Validator.Validate(person))
                Console.WriteLine(error);
        }
    }
}
