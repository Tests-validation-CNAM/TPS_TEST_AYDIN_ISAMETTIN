namespace MorpionApp;

public class Grid
{
    private Cell[,] gameGrid;
    private Tuple<int, int> sizeGrid;

    public Grid(int line, int column)
    {
        InitializeSizeGrid(line, column);
        InitializeGameGrid(line, column);
    }
    
    public Cell GetCell(int idCell)
    {
        return gameGrid[idCell / gameGrid.GetLength(1), idCell % gameGrid.GetLength(1)];
    }

    public Cell GetCell(int line, int column)
    {
        return gameGrid[line, column];
    }

    public int GetSize()
    {
        return GetLineSize() * GetColumnSize();
    }

    public int GetLineSize()
    {
        return sizeGrid.Item1;
    }

    public int GetColumnSize()
    {
        return sizeGrid.Item2;
    }

    private void InitializeSizeGrid(int line, int column)
    {
        sizeGrid = Tuple.Create(line, column);
    }

    private void InitializeGameGrid(int line, int column)
    {
        gameGrid = new Cell[line, column];

        for (var i = 0; i < line * column; i++) gameGrid[i / column, i % column] = new Cell(i);
    }
    
    public bool SetCellOwnerIfEmpty(int idCell, int value)
    {
        if (IsCellFree(idCell))
        {
            GetCell(idCell).SetOwner(value);
            return true;
        }

        return false;
    }
    
    public bool SetCellOwnerIfEmpty(int line, int column, int value)
    {
        if (IsCellFree(line, column))
        {
            GetCell(line, column).SetOwner(value);
            return true;
        }
        return false;
    }

    public bool IsCellFree(int idCell)
    {
        return GetCellOwner(idCell) == 0;
    }
    
    public bool IsCellFree(int line, int column)
    {
        return GetCellOwner(line, column) == 0;
    }

    public int GetCellOwner(int idCell)
    {
        return GetCell(idCell).GetOwner();
    }
    
    public int GetCellOwner(int line, int column)
    {
        return GetCell(line, column).GetOwner();
    }
}