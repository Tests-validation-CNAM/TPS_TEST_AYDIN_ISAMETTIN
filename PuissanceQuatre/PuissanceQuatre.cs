namespace MorpionApp;

public class Puissance4
{
    private int gameMode;
    private Grid grid;
    private Player player1;
    private Player player2;
    
    public Puissance4()
    {
        grid = new Grid(4, 7);
        player1 = new Player(1, "A");
        player2 = new Player(2, "B");
    }
    
    public Player PlayRound()
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
    
    public void StartGame()
    {
        AskGameMode(); // demande le type de jeu
        Inputs.InputPlayersNames(player1, player2);
        Player potentialWinner = PlayRound(); // fait jouer les joueurs jusqu'a avoir un gagnant ou égalité
        EndGame(potentialWinner);
    }
    
    public void EndGame(Player PotentialWinner)
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

    public bool CheckEquality()
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
    
    public bool CheckWin(Player player)
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
    
    public void AskGameMode()
    {
        var input = Inputs.InputGameMode();
        if (input == 1)
        {
            SetGameMode(0);
        }
        else if (input == 2)
        {
            SetGameMode(1);
            player2.SetName("IA");
            player2.SetIsBot(1);
        }
    }

    public Player RoundGenerator(int round)
    {
        if (round % 2 == 0)
            return player1;
        return player2;
    }

    public void SetGameMode(int newSetting)
    {
        gameMode = newSetting;
    }
    
    public Grid GetGrid()
    {
        return grid;
    }

    public Player GetPlayer1()
    {
        return player1;
    }

    public Player GetPlayer2()
    {
        return player2;
    }
}
