namespace SimpleSnake.GameObjects;

public class Food
{
    public Food(char symbol, int points)
    {
        this.Symbol = symbol;
        this.Points = points;
    }

    public char Symbol { get; }
    public int Points { get; }
}