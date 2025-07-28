
Console.OutputEncoding = System.Text.Encoding.UTF8;

string[] data = Console.ReadLine().Split(new []{", ", " "}, StringSplitOptions.RemoveEmptyEntries);
List<Card> cards = new();

for (int i = 0; i < data.Length; i += 2)
{
    try
    {
        Card card = new(data[i], data[i + 1]);
        cards.Add(card);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}

Console.WriteLine(string.Join(" ", cards));




class Card
{
    private readonly HashSet<string> _validFaces = new() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

    private readonly Dictionary<string, string> _validSuits = new()
    {
        ["S"] = "\u2660",
        ["H"] = "\u2665",
        ["D"] = "\u2666",
        ["C"] = "\u2663"

    };
    public string Face { get; }
    public string Suit { get; }

    public Card(string face, string suit)
    {
        if (!_validFaces.Contains(face) || !_validSuits.ContainsKey(suit))
            throw new ArgumentException("Invalid card!");
        this.Face = face;
        this.Suit = this._validSuits[suit];
    }

    public override string ToString()
        => $"[{this.Face}{this.Suit}]";
}