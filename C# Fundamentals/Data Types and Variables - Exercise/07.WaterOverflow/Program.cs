int lines = int.Parse(Console.ReadLine());
int water;
int liters = 0;

while (lines > 0)
{
    water = int.Parse(Console.ReadLine());
    lines--;
    liters += water;
    if (liters <= 255)
    { 
        continue;
    }
    else
    {
        Console.WriteLine("Insufficient capacity!");
        liters -= water;
        
    }       
}
Console.WriteLine(liters);
