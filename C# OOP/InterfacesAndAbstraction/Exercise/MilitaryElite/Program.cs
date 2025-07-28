using MilitaryElite.Classes;
using MilitaryElite.Interfaces;

namespace MilitaryElite;

public class Program
{
    public static void Main()
    {
        Dictionary<string, ISoldier> soldiers = ReadSoldiers();

        foreach (var soldier in soldiers.Values)
        {
            Console.WriteLine(soldier);
        }
    }

    private static Dictionary<string, ISoldier> ReadSoldiers()
    {
        Dictionary<string, ISoldier> soldiers = new();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            try
            {
                ISoldier current = ReadSoldier(data, soldiers);
                soldiers[current.Id] = current;
            }
            catch
            {
                /* swallow all kind of exceptions */
            }
        }
        return soldiers;
    }

    private static ISoldier ReadSoldier(string[] data, Dictionary<string, ISoldier> soldiers)
    {
        string soldier = data[0];
        switch (soldier)
        {
            case nameof(Private):
                return ReadPrivateSoldier(data);
            case nameof(LieutenantGeneral):
                return ReadLieutenantGeneral(data, soldiers);
            case nameof(Engineer):
                return ReadEngineer(data);
            case nameof(Commando):
                return ReadCommando(data);
            case nameof(Spy):
                return ReadSpy(data);
            default:
                throw new InvalidOperationException("Invalid soldier type");
        }
    }

    private static IPrivate ReadPrivateSoldier(string[] data)
        => new Private(data[1], data[2], data[3], decimal.Parse(data[4]));

    private static ILieutenantGeneral ReadLieutenantGeneral(string[] data, Dictionary<string, ISoldier> soldiers)
    {
        LieutenantGeneral lieutenantGeneral = new(data[1], data[2], data[3], decimal.Parse(data[4]));

        for (int i = 5; i < data.Length; i++)
            lieutenantGeneral.AddSoldierInCommand(soldiers[data[i]]);

        return lieutenantGeneral;
    }

    private static IEngineer ReadEngineer(string[] data)
    {
        Engineer engineer = new(data[1], data[2], data[3], decimal.Parse(data[4]), data[5]);

        for (int i = 6; i < data.Length; i += 2)
        {
            Repair repair = new(data[i], int.Parse(data[i + 1]));
            engineer.AddRepair(repair);
        }

        return engineer;
    }

    private static ICommando ReadCommando(string[] data)
    {
        Commando commando = new(data[1], data[2], data[3], decimal.Parse(data[4]), data[5]);

        foreach (var mission in ReadMissions(data[6..]))
            commando.AddMission(mission);

        return commando;
    }

    private static IEnumerable<IMission> ReadMissions(string[] data)
    {
        for (int i = 0; i < data.Length; i += 2)
        {
            IMission? mission = null;
            try
            {
                mission = new Mission(data[i], data[i + 1]);
            }
            catch
            {
                /* swallow all kind of exceptions */
            }
            
            if (mission is not null)
                yield return mission;
        }
    }

    private static ISpy ReadSpy(string[] data)
        => new Spy(data[1], data[2], data[3], int.Parse(data[4]));
}