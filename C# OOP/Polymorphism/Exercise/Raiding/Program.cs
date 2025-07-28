using System;
using System.Collections.Generic;
using Raiding.Classes;

namespace Raiding;

public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<IHero> heroes = new List<IHero>(capacity: n);
        while (heroes.Count < n)
        {
            string heroName = Console.ReadLine();
            string heroType = Console.ReadLine();

            IHero hero = heroType switch
            {
                nameof(Druid) => new Druid(heroName),
                nameof(Rogue) => new Rogue(heroName),
                nameof(Warrior) => new Warrior(heroName),
                nameof(Paladin) => new Paladin(heroName),
                _ => null
            };

            if (hero is null) Console.WriteLine("Invalid hero!");
            else heroes.Add(hero);
        }

        int totalHeroPower = 0;
        int bossPower = int.Parse(Console.ReadLine());
        foreach (IHero hero in heroes)
        {
            Console.WriteLine(hero.CastAbility());
            totalHeroPower += hero.Power;
        }

        Console.WriteLine(totalHeroPower >= bossPower ? "Victory!" : "Defeat...");
    }

    //private static List<IHero> GetHeroList(int n)
    //{
    //    List<IHero> heroes = new List<IHero>(capacity: n);
    //    while (heroes.Count < n)
    //    {
    //        string heroName = Console.ReadLine();
    //        string heroType = Console.ReadLine();

    //        IHero hero = heroType switch
    //        {
    //            nameof(Druid) => new Druid(heroName),
    //            nameof(Rogue) => new Rogue(heroName),
    //            nameof(Warrior) => new Warrior(heroName),
    //            nameof(Paladin) => new Paladin(heroName),
    //            _ => null
    //        };

    //        if (hero is null) Console.WriteLine("Invalid hero!");
    //        else heroes.Add(hero);
    //    }

    //    return heroes;
    //}
}