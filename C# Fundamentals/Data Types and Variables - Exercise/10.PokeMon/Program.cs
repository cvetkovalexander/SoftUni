int N = int.Parse(Console.ReadLine());
int M = int.Parse(Console.ReadLine());
int Y  = int.Parse(Console.ReadLine());
int N2 = N;
int targets = 0;

while (true)
{
    
    N2 -= M;
    targets++;
    if (N2 == N / 2 && Y > 0)
    {
        N2 /= Y;            
    }
    if (N2 < M)
    {
        break;
    }
}
Console.WriteLine(N2);
Console.WriteLine(targets);