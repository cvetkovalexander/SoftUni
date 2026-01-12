using P02_FootballBetting.Data;

namespace P02_FootballBetting;

public class StartUp
{
    static void Main(string[] args)
    {
		try
		{
            using FootballBettingContext context = new FootballBettingContext();

			context.Database.EnsureDeleted();

			context.Database.EnsureCreated();

            Console.WriteLine("Database is created successfully");
		}
		catch (Exception e)
		{
            Console.WriteLine(e);
			throw;
		}
    }
}
