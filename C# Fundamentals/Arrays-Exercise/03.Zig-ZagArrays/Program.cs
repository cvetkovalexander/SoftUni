namespace _03.Zig_ZagArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] firstArray = new int[lines];
            int[] secondArray = new int[lines];
            bool zigZag = false;

            for (int i = 0; i < lines; i++)
            {
                int[] array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
                

                if (zigZag == false)
                {
                    firstArray[i] = array1[0];
                    secondArray[i] = array1[1];
                }
                else if (zigZag == true)
                {
                    firstArray[i] = array1[1];
                    secondArray[i] = array1[0];
                }
                zigZag =! zigZag;
            }
            Console.WriteLine(string.Join(" ", firstArray));
            Console.WriteLine(string.Join(" ", secondArray));
        }
    }
}
