namespace Telephony;

public class Program
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] websites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        CallNumbers(numbers);
        BrowseWebSites(websites);
    }

    private static void CallNumbers(string[] numbers)
    {
        var smartphone = new Smartphone();
        ICaller stationaryPhone = new StationaryPhone();
        foreach (string num in numbers) 
        {
            if (num.Length == 10) Console.WriteLine(smartphone.Call(num));
            else Console.WriteLine(stationaryPhone.Call(num));
        }

    }
    private static void BrowseWebSites(string[] websites)
    {
        var smartphone = new Smartphone();
        foreach (string site in websites)
            Console.WriteLine(smartphone.Browse(site));
    }
}