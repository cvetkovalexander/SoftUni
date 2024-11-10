using System;

namespace _2_zad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
               .Split(' ').Select(int.Parse).ToList();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] parts = command.Split(' ');

                switch (parts[0])
                {
                    case "add":
                        int count = 0;
                        List<int> nums = new List<int>();
                        for (int i = 3; i < parts.Length; i++)
                        {
                            nums.Add(int.Parse(parts[i]));

                        }

                        for (int i = 0; i < nums.Count; i++)
                        {

                            numbers.Insert(count, nums[i]);
                            count++;
                        }
                        break;


                    case "remove":
                        if (parts[1] == "greater" && parts[2] == "than")
                        {
                            int value = int.Parse(parts[3]);
                            for (int j = 0; j < numbers.Count; j++)
                            {
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] >= value)
                                    {
                                        numbers.RemoveAt(i);
                                    }
                                }
                            }
                        }
                        else if (parts[1] == "at" && parts[2] == "index")
                        {
                            int index = int.Parse(parts[3]);
                            if (index >= 0 && index < numbers.Count)
                            {
                                numbers.RemoveAt(index);
                            }
                        }
                        break;
                    case "replace":
                        {
                            int numbertoreplace = int.Parse(parts[1]);
                            bool containsNumber = numbers.Any(n => n == numbertoreplace);
                            if (!containsNumber)
                            {
                                break;
                            }
                            int newnum = int.Parse(parts[2]);
                            int index = numbers.IndexOf(numbertoreplace);
                            numbers[index] = numbertoreplace;
                        }
                        break;

                    case "find":
                        {
                            if (parts[1] == "even")
                            {
                                List<int> even = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] % 2 == 0)
                                    {
                                        even.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", even));

                            }
                            else if (parts[1] == "odd")
                            {
                                List<int> odds = new List<int>();
                                for (int i = 0; i < numbers.Count; i++)
                                {
                                    if (numbers[i] % 2 == 1)
                                    {
                                        odds.Add(numbers[i]);
                                    }
                                }
                                Console.WriteLine(string.Join(" ", odds));

                            }
                        }
                        break;
                }

            }
            Console.WriteLine(string.Join(", ", numbers));

        }
    }
}
