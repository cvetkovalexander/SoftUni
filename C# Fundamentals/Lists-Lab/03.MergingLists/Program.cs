namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> list2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> mergedList = new();

            int list1Count = list1.Count;
            int list2Count = list2.Count;

            if (list1.Count > list2.Count)
            {
                for (int i = 0; i < list1Count; i++)
                {
                    if (list1.Count > i)
                    {
                        mergedList.Add(list1[i]);
                    }
                    if (list2.Count > i)
                    {
                        mergedList.Add(list2[i]);
                    }
                }
            }
            else if (list1.Count < list2.Count)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    if (list1.Count > i)
                    {
                        mergedList.Add(list1[i]);
                    }
                    if (list2.Count > i)
                    {
                        mergedList.Add(list2[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < list1Count; i++)
                {
                    if (list1.Count > i)
                    {
                        mergedList.Add(list1[i]);
                    }
                    if (list2.Count > i)
                    {
                        mergedList.Add(list2[i]);
                    }
                }
            }
            
            Console.WriteLine(string.Join(" ", mergedList));
        }
    }
}
