using System;
using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        Dictionary<string, List<string>> companyMap = new();
//        string input;
//        while ((input = Console.ReadLine()) != "End")
//        {
//            string[] arguments = input.Split(" -> ");
//            string company = arguments[0];
//            string id = arguments[1];

//            if (!companyMap.ContainsKey(company))
//            {
//                companyMap[company] = new List<string>();
//                companyMap[company].Add(id);
//            }
//            else if (companyMap.ContainsKey(company) && !companyMap[company].Contains(id))
//            {
//                companyMap[company].Add(id);
//            }
//        }

//        foreach ((string company, List<string> ids) in companyMap)
//        {
//            Console.WriteLine(company);
//            for (int i = 0; i < ids.Count; i++)
//            {
//                Console.WriteLine($"-- {ids[i]}");
//            }
//        }
//    }
//}
class Company
{
    public Company(string name)
    {
        Name = name;
        Id = new List<string>();
    }
    public string Name { get; set; }
    public List<string> Id { get; set; }

    public void AddId(string id)
    {
        if (!Id.Contains(id))
        {
            Id.Add(id);
        }
    }

    public override string ToString()
    {
        string result = $"{Name}\n";

        for (int i = 0; i < Id.Count; i++)
        {
            result += $"-- {Id[i]}\n";
        }

        return result.Trim();
    }
}
class Program
{
    static void Main()
    {
        Dictionary<string, Company> companyMap = new();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] arguments = input.Split(" -> ");
            string name = arguments[0];
            string id = arguments[1];

            if (!companyMap.ContainsKey(name))
            {
                Company company = new Company(name);
                companyMap.Add(name, company);
            }

            companyMap[name].AddId(id);
        }

        foreach (Company company in companyMap.Values)
        {
            Console.WriteLine(company);
        }
    }
}
