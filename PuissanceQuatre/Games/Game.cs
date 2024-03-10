namespace MorpionApp;

public abstract class Game
{
    protected int gameMode;
    protected Grid grid;
    protected Player player1;
    protected Player player2;
    
    public void StartGame()
    {
        AskGameMode();
        Inputs.InputPlayersNames(player1, player2);
        var potentialWinner = PlayRound();
        EndGame(potentialWinner);
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
    
    public void SetGameMode(int newSetting)
    {
        gameMode = newSetting;
    }
    
    public Player GetCurrentPlayer(int round)
    {
        if (round % 2 == 0)
            return player1;
        return player2;
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

    public abstract Player PlayRound();
    public abstract void EndGame(Player PotentialWinner);
    public abstract bool CheckWin(Player player);
    public abstract bool CheckEquality();
}