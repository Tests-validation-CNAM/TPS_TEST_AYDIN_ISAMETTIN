namespace MorpionApp;

public class Cell
{
    private int idCell;
    private int owner;
    
    public Cell(int IdCell)
    {
        idCell = IdCell;
        owner = 0;
    }

    public int GetIdCell()
    {
        return idCell;
    }

    public int GetOwner()
    {
        return owner;
    }

    public void SetIdCell(int newIdCell)
    {
        idCell = newIdCell;
    }

    public void SetOwner(int newOwner)
    {
        owner = newOwner;
    }
}

