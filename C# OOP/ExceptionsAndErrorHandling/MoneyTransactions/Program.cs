


using System.Security.Principal;

string[] data = Console.ReadLine().Split(new[] { '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
Dictionary<int, double> bankAccounts = GetBankAccounts(data);

string command;
while ((command = Console.ReadLine()) != "End")
{
    try
    {
        string[] tokens = command.Split(" ");
        if (!bankAccounts.ContainsKey(int.Parse(tokens[1]))) throw new ArgumentException("Invalid account!");
        switch (tokens[0])
        {
            case "Deposit":
                bankAccounts[int.Parse(tokens[1])] += double.Parse(tokens[2]);
                break;
            case "Withdraw":
                if (bankAccounts[int.Parse(tokens[1])] < double.Parse(tokens[2]))
                {
                    throw new ArgumentException("Insufficient balance!");
                }
                bankAccounts[int.Parse(tokens[1])] -= double.Parse(tokens[2]);
                break;
            default:
                throw new InvalidOperationException("Invalid command!");
        }

        Console.WriteLine($"Account {int.Parse(tokens[1])} has new balance: {bankAccounts[int.Parse(tokens[1])]:F2}");
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
}




static Dictionary<int, double> GetBankAccounts(string[] data)
{
    Dictionary<int, double> bankAccounts = new();
    for (int i = 0; i < data.Length; i += 2)
    {
        bankAccounts[int.Parse(data[i])] = double.Parse(data[i + 1]);
    }
    return bankAccounts;
}