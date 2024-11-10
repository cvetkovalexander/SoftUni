using System.Numerics;

namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input.Split();

                Box box = new Box
                {
                    SerialNumber = command[0],
                    Item = new Item(command[1], double.Parse(command[3])),
                    ItemQuantity = int.Parse(command[2]),
                };

                boxes.Add(box);
            }

            List<Box> orderedBoxes = boxes.OrderByDescending(box => box.Price).ToList();

            foreach (Box box in orderedBoxes)
            {
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.Price:f2}");
            }
        }
    }

    class Item
    {
        public Item(string name, double price)
        {
            Name = name;
            Price = price;
        }
    
        public string Name { get; set; }
        public double Price { get; set; }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double Price
        {
            get
            {
                return ItemQuantity * Item.Price;
            }
        }
    }
}

