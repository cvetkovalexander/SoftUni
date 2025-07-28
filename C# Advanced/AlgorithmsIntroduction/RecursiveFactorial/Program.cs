
Console.WriteLine(Factorial(int.Parse(Console.ReadLine())));


static long Factorial(int n)
{
    if (n == 1) return 1;

    long rest = Factorial(n - 1);
    long factorial = n * rest;

    return factorial;
}