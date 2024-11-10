/*int counter = int.Parse(Console.ReadLine());
string biggestBeer = "";
double volume = 0;
double biggestKeg = double.MinValue;

while (counter > 0)
{
    string model = Console.ReadLine();
    double radius = double.Parse(Console.ReadLine());
    int  height = int.Parse(Console.ReadLine());
    volume = Math.PI * (radius * 2) * height;
    if (volume > biggestKeg)
    {
        biggestKeg = volume;
        biggestBeer = model;
    }
    counter--;
}

Console.WriteLine(biggestBeer);*/

int numKegs = int.Parse(Console.ReadLine());
string biggestKeg = "";
double biggestVolume = double.MinValue;

for (int i = 0; i < numKegs; i++)
{
    string model = Console.ReadLine();
    double radius = double.Parse(Console.ReadLine());
    int height = int.Parse(Console.ReadLine());
    double volume = Math.PI * radius * radius * height;
    if (volume > biggestVolume)
    {
        biggestVolume = volume;
        biggestKeg = model;
    }
}
Console.WriteLine(biggestKeg);








