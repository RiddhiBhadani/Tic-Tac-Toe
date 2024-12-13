public class Player 
{
    public string Symbol { get; private set; }  // Player's symbol, "X" or "O"
    public string Name { get; private set; }

    public Player(string name, string symbol)
    {
        Name = name;
        Symbol = symbol;
    }
}
