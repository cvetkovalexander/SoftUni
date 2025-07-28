namespace CustomLinkedList;


public class Program
{
    static void Main()
    {
        CustomGenericLinkedList<double> list = new();

        
        list.AddFirst(25.2);
        list.AddFirst(34.1);
        list.AddLast(42.9);

        
        double[] array = list.ToArray();

        foreach (var a in array)
        {
            Console.WriteLine(a);
        }

        list.RemoveFirst();
        list.RemoveLast();


        list.ForEach(x => Console.WriteLine(x));


    }
}