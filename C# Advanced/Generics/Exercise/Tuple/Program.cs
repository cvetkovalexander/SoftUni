using System;
using Tuple;










string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
string name = data[0] + " " + data[1];
string address = data[2];
string town = "";
if (data.Length > 4)
{
    town = data[3] + " " + data[4];
}
else
{
    town = data[3];
}
CustomTuple<string, string, string> first = new(name, address, town);
Console.WriteLine(first.ToString());

data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
CustomTuple<string, int, string> second = new(data[0], int.Parse(data[1]), "");
if (data[2] == "drunk")
{
    second = new(data[0], int.Parse(data[1]), "True");
}
else
{
    second = new(data[0], int.Parse(data[1]), "False");
}
Console.WriteLine(second.ToString());

data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
CustomTuple<string, double, string> third = new(data[0], double.Parse(data[1]), data[2]);
Console.WriteLine(third.ToString());


