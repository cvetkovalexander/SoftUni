using System;

namespace GenericBoxOfString;

public class Program
{
    public static void Main(string[] args)
    {
        ListOfBoxes<double> boxes = new();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            //Box<string> box = new(Console.ReadLine());
            Box<double> box = new(double.Parse(Console.ReadLine()));
            boxes.Boxes.Add(box);
        }

        double element = double.Parse(Console.ReadLine());

        //string[] indexes = Console.ReadLine().Split();
        //boxes.Swap(int.Parse(indexes[0]), int.Parse(indexes[1]));

        //boxes.PrintBoxes();

        Console.WriteLine(boxes.Compare(element));
        
    }
}
