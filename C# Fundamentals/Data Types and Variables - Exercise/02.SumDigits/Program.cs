int input = int.Parse(Console.ReadLine());
int sum = 0;
int currentNum = input;

for (int i = 0; i < input.ToString().Length; i++)
{
    
    sum += currentNum % 10;
    currentNum /= 10;
}

Console.WriteLine(sum);
