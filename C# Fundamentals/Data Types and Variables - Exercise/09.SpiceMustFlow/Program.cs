int startingYield = int.Parse(Console.ReadLine());
int leastYield = 100;
int sumSpices = 0;
int days = 0;


while (true)
{
    int Yield = startingYield;
    Yield -= 26;
    sumSpices += Yield;
    startingYield -= 10;
    days++;
    if (startingYield < leastYield)
    {
        break;
    }
    
}
sumSpices -= 26;
Console.WriteLine(days);
Console.WriteLine(sumSpices);