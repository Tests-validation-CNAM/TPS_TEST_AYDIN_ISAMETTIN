namespace MorpionApp;

public class SerializableGame
{
    public int gameMode { get; set; }
    public SerializableGrid grid { get; set; }
    public Player player1 { get; set; }
    public Player player2 { get; set; }
    
    public SerializableGame(int gameMode, SerializableGrid grid, Player player1, Player player2)
    {
        this.gameMode = gameMode;
        this.grid = grid;
        this.player1 = player1;
        this.player2 = player2;
    }
    
    public SerializableGame()
    {
    }
}