
/*int startingYield = int.Parse(Console.ReadLine());
int leastYield = 100;
int sumSpices = 0;
int days = 0;


while (startingYield >= leastYield) 
{
    if (startingYield < leastYield)
    {
        Console.WriteLine(days);
        Console.WriteLine(sumSpices);
        break;
    }
    int Yield = startingYield;
    Yield -= 26;
    sumSpices += Yield;
    startingYield -= 10;
    days++;
    

}
sumSpices -= 26;
Console.WriteLine(days);
Console.WriteLine(sumSpices);*/

int startingYield = int.Parse(Console.ReadLine());
int spices = 0;
int days = 0;

if (startingYield >= 100)
{
    while (startingYield >= 100)
    {
        days++;
        spices += startingYield;
        startingYield -= 10;
    }
    spices -= (days + 1) * 26;
    Console.WriteLine(days);
    Console.WriteLine(spices);
}
else
{
    Console.WriteLine(days);
    Console.WriteLine(spices);
} 
