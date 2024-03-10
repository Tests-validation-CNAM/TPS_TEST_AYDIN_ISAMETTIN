namespace MorpionApp;

public class Puissance4 : Game
{
    public Puissance4()
    {
        grid = new Grid(4, 7);
        player1 = new Player(1, "A");
        player2 = new Player(2, "B");
    }
    
    public override Player PlayRound()
    {
        int round = 0;
        Player currentPlayer = player1;

        while(!CheckWin(currentPlayer) && !CheckEquality())
        {
            currentPlayer = RoundGenerator(round);
            Outputs.DisplayGamePuissance4(GetGrid(), GetPlayer1(), GetPlayer2(), currentPlayer);
            Inputs.InputByColumn(grid, currentPlayer, grid.GetColumnSize());
            round++;
        }
        return currentPlayer;
    }

    public override bool CheckEquality()
    {
        for (int cellPosition = 0; cellPosition < grid.GetSize(); cellPosition++)
        {
            if (grid.GetCell(cellPosition).GetOwner() == 0)
            {
                return false;
            }
        }
        return true;
    }
    
    public override bool CheckWin(Player player)
    {
        return CheckWinByLine(player) || CheckWinByColumn(player) || CheckWinByDiagonal(player);
    }
    
    public bool CheckWinByLine(Player player)
    {
        int count = 0;

        for (int line = 0; line < grid.GetLineSize(); line++)
        {
            for (int column = 0; column < grid.GetColumnSize(); column++)
            {
                if (grid.GetCell(line, column).GetOwner() == player.GetId())
                {
                    count++;
                    if (count == 4)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            count = 0;
        }
        return false;
    }
    
    public bool CheckWinByColumn(Player player)
    {
        int count = 0;

        for (int column = 0; column < grid.GetColumnSize(); column++)
        {
            for (int line = 0; line < grid.GetLineSize(); line++)
            {
                if (grid.GetCell(line, column).GetOwner() == player.GetId())
                {
                    count++;
                    if (count == 4)
                    {
                        return true;
                    }
                }
                else
                {
                    count = 0;
                }
            }
            count = 0;
        }
        return false;
    }
    
    public bool CheckWinByDiagonal(Player player) {
        int gridColumnNumber = grid.GetColumnSize() - 1;
        int line = 0;
        int column = 0;
        int totalCount = 0;
        int countDiagonal = 0;

        for (column = 0; column < 4; column++) {
            if (grid.GetCell(line, column).GetOwner() == player.GetId()) {
                for (countDiagonal = 0; countDiagonal < 4; countDiagonal++) {
                    if (grid.GetCell(line + countDiagonal, column + countDiagonal).GetOwner() == player.GetId()) {
                        totalCount++;
                    } else {
                        totalCount = 0;
                    }
                }
                if (totalCount == 4) {
                    return true;
                } else {
                    totalCount = 0;
                }

                for (countDiagonal = 0; countDiagonal < 4; countDiagonal++) {
                    if (grid.GetCell(line + countDiagonal, gridColumnNumber - column - countDiagonal).GetOwner() == player.GetId()) {
                        totalCount++;
                    } else {
                        totalCount = 0;
                    }
                }
                if (totalCount == 4) {
                    return true;
                } else {
                    totalCount = 0;
                }
            }
        }
        return false;
    }
    
    public override void EndGame(Player PotentialWinner)
    {
        if (CheckWin(PotentialWinner))
        {
            Outputs.DisplayGameResultWinPuissance4(GetGrid(), GetPlayer1(), GetPlayer2(), PotentialWinner);
        }
        else if (CheckEquality())
        {
            Outputs.DisplayGameResultEqualityPuissance4(GetGrid(), GetPlayer1(), GetPlayer2());
        }
    }
}
