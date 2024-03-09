namespace MorpionApp;

public class Morpion
{
    private int gameMode;
    private readonly Grid grid;
    private readonly Player player1;
    private readonly Player player2;
    
    public Morpion()
    {
        grid = new Grid(3, 3);
        player1 = new Player(1, "A");
        player2 = new Player(2, "B");
    }

    public void StartGame()
    {
        AskGameMode();
        Inputs.InputPlayersNames(player1, player2);
        var potentialWinner = PlayRound();
        EndGame(potentialWinner);
    }
    
    public Player PlayRound()
    {
        var round = 0;
        var currentPlayer = player1;

        while (!CheckWin(currentPlayer) && !CheckEquality())
        {
            currentPlayer = RoundGenerator(round);
            Outputs.DisplayGameMorpion(GetGrid(), GetPlayer1(), GetPlayer2(), currentPlayer);
            Inputs.InputByCell(grid, currentPlayer, grid.GetSize());
            round++;
        }

        return currentPlayer;
    }

    public void EndGame(Player potentialWinner)
    {
        if (CheckWin(potentialWinner))
            Outputs.DisplayGameResultWinMorpion(GetGrid(), GetPlayer1(), GetPlayer2(), potentialWinner);
        else if (CheckEquality()) Outputs.DisplayGameResultEqualityMorpion(GetGrid(), GetPlayer1(), GetPlayer2());
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

    public bool CheckEquality()
    {
        for (var cellPosition = 0; cellPosition < grid.GetSize(); cellPosition++)
            if (grid.GetCell(cellPosition).GetOwner() == 0)
                return false;

        return true;
    }

    public bool CheckWin(Player player)
    {
        return CheckWinByLine(player) || CheckWinByColumn(player) || CheckWinByDiagonal(player);
    }

    public bool CheckWinByLine(Player player)
    {
        int count;
        for (var line = 0; line < grid.GetLineSize(); line++)
        {
            count = 0;
            for (var column = 0; column < grid.GetColumnSize(); column++)
                if (grid.GetCell(line, column).GetOwner() == player.GetId())
                    count++;
            if (count == 3) return true;
        }

        return false;
    }

    public bool CheckWinByColumn(Player player)
    {
        int count;
        for (var column = 0; column < grid.GetColumnSize(); column++)
        {
            count = 0;
            for (var line = 0; line < grid.GetLineSize(); line++)
                if (grid.GetCell(line, column).GetOwner() == player.GetId())
                    count++;
            if (count == 3) return true;
        }

        return false;
    }

    public bool CheckWinByDiagonal(Player player)
    {
        var countAsc = 0;
        var countDesc = 0;
        for (var line = 0; line < 3; line++)
        {
            if (grid.GetCell(line, line).GetOwner() == player.GetId()) countAsc++;
            if (grid.GetCell(line, 2 - line).GetOwner() == player.GetId()) countDesc++;
        }

        return countAsc == 3 || countDesc == 3;
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