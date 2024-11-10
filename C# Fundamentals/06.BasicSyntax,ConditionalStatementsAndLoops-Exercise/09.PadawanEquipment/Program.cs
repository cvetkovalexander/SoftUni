namespace _09.PadawanEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double amountMoney = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double priceSabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());

            double allSabers = priceSabers * (students + (Math.Ceiling(students * 0.1)));
            double allRobes = students * priceRobes;
            double belts = students - (students / 6);
            double allBelts = priceBelts * belts;

            double equipment = allSabers + allRobes + allBelts;

            if (equipment <= amountMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {equipment:F2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {equipment - amountMoney:F2}lv more.");
            }
            
        }
    }
}
