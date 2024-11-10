/*int snowballs = int.Parse(Console.ReadLine());
long biggestSnowballValue = long.MinValue;
int biggestSnow;
int biggestTime;
int biggestQuality;

while(true)
{
int snow = int.Parse(Console.ReadLine());
int time = int.Parse(Console.ReadLine());
int quality = int.Parse(Console.ReadLine());
long value = (snow / time) * (snow/time) * (snow/time);
    if (biggestSnowballValue < value);
    {
        biggestSnowballValue = value;
        biggestSnow = snow;
        biggestTime = time;
        biggestQuality = quality;
    }
    snowballs--;
    if (snowballs == 0)
    {
        Console.WriteLine($"{snow} : {time} = {biggestSnowballValue} ({quality})");
        break;
    }
}*/

using System.Numerics;

int snowballs = int.Parse(Console.ReadLine());
BigInteger maxValue = 0;
int endSnow = 0;
int endTime = 0;
int endQuality = 0;

while (snowballs > 0)
{
    int snow = int.Parse(Console.ReadLine());
    int time = int.Parse(Console.ReadLine());
    int quality = int.Parse(Console.ReadLine());
    BigInteger value = BigInteger.Pow(snow/time, quality);
    if (value > maxValue)
    {
        maxValue = value;
        endSnow = snow;
        endTime = time;
        endQuality = quality;
    }
    snowballs--;
}
Console.WriteLine($"{endSnow} : {endTime} = {maxValue} ({endQuality})");











