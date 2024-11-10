using System.Globalization;

namespace _13.HolidaysBetweenTwoDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);

            DateTime endDate = DateTime.ParseExact(Console.ReadLine(),
                "d.M.yyyy", CultureInfo.InvariantCulture);

            int holidaysCount = 0;
            for (DateTime date = startDate; date <= endDate;)
            {
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                date.DayOfWeek == DayOfWeek.Sunday)
                {
                    holidaysCount++;
                }
                date = date.AddDays(1);
            }
            Console.WriteLine(holidaysCount);
        }
    }
}
