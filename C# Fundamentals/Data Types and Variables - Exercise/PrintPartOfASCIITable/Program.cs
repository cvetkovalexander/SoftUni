

int startIndex = int.Parse(Console.ReadLine());
int endIndex = int.Parse(Console.ReadLine());

for (int i = startIndex; i <= endIndex; i++)
{
    string asciiChar = ((char)i).ToString();
    Console.Write(asciiChar + " ");
}
