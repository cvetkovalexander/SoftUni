int countNumbers = int.Parse(Console.ReadLine());
decimal sum = 0;

while (countNumbers > 0)
{
    decimal number = decimal.Parse(Console.ReadLine());
    sum += number;
    countNumbers--;
}
Console.WriteLine(sum);