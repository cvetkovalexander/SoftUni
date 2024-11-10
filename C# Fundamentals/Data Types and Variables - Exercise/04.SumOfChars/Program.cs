int lines = int.Parse(Console.ReadLine());
string symbol;
int sum = 0;

while (lines > 0)
{
    symbol = Console.ReadLine();
    foreach(char c in symbol)
    {
        sum += c;
    }    
    lines--;
}
Console.WriteLine($"The sum equals: {sum}");