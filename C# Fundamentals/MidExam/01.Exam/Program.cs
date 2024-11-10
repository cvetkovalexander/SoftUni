namespace _01.Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split("|").ToList();

            string command;
            while ((command = Console.ReadLine()) != "Shop!")
            {
                string[] arguments = command.Split('%');
                switch (arguments[0])
                {
                    case "Important":
                        string importantProduct = arguments[1];
                        products = ImportantCommand(products, importantProduct);
                        break;
                    case "Add":
                        string addProduct = arguments[1];
                        products = AddCommand(products, addProduct);
                        break;
                    case "Swap":
                        string firstProduct = arguments[1];
                        string secondProduct = arguments[2];
                        products = SwapCommand(products, firstProduct, secondProduct);
                        break;
                    case "Remove":
                        string removeProduct = arguments[1];
                        products = RemoveCommand(products, removeProduct);
                        break;
                    case "Reversed":
                        products.Reverse();
                        break;
                }
            }

            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {products[i]}");
            }
        }

        static List<string> RemoveCommand(List<string> list, string product)
        {
            if (list.Contains(product))
            {
                list.Remove(product);
            }
            else
            {
                Console.WriteLine($"Product {product} isn't in the list.");
            }

            return list;
        }

        static List<string> SwapCommand(List<string> list, string first, string second)
        {
            if (list.Contains(first) && list.Contains((second)))
            {
                int firstIndex = list.IndexOf(first);
                int secondIndex = list.IndexOf(second);

                (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
            }
            else
            {
                if (!list.Contains(first))
                {
                    Console.WriteLine($"Product {first} missing!");
                }
                else if (!list.Contains(second))
                {
                    Console.WriteLine($"Product {second} missing!");
                }
            }
            return list;
        }

        static List<string> AddCommand(List<string> list, string product)
        {
            if (list.Contains(product))
            {
                Console.WriteLine("The product is already in the list.");
            }
            else
            {
                list.Add(product);
            }
            return list;
        }

        static List<string> ImportantCommand(List<string> list, string product)
        {
            if (list.Contains(product))
            {
                list.Remove(product);
                list.Insert(0, product);
            }
            else
            {
                list.Insert(0, product);
            }
            return list;
        }
    }
}
