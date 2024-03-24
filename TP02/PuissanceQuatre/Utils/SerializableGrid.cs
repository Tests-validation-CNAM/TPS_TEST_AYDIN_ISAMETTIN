namespace MorpionApp;

public class SerializableGrid
{
    public Cell[,] gameGrid { get; set; }
    public Tuple<int, int> SizeGrid { get; set; }
        
    public SerializableGrid()
    {
    }
}