using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace MorpionApp;

public class Morpion : Game
{
    public Morpion()
    {
        grid = new Grid(3, 3);
        player1 = new Player(1, "A");
        player2 = new Player(2, "B");
    }
    
    public override Player PlayRound()
    {
        int round = 0;
        Player currentPlayer = GetCurrentPlayer(round);
  
        while (!CheckWin(currentPlayer) && !CheckEquality())
        {
            currentPlayer = GetCurrentPlayer(round);
            Outputs.DisplayGameMorpion(GetGrid(), GetPlayer1(), GetPlayer2(), currentPlayer);
            Inputs.InputByCell(grid, currentPlayer, grid.GetSize());
            round++;
            this.SaveGameToFile("C:/Users/Isamet/Desktop/saved_game.json");
        }
        return currentPlayer;
    }

    public override  bool CheckEquality()
    {
        for (var cellPosition = 0; cellPosition < grid.GetSize(); cellPosition++)
            if (grid.GetCell(cellPosition).GetOwner() == 0)
                return false;

        return true;
    }

    public override bool CheckWin(Player player)
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
    
    public override void EndGame(Player potentialWinner)
    {
        if (CheckWin(potentialWinner))
        {
            Outputs.DisplayGameResultWinMorpion(GetGrid(), GetPlayer1(), GetPlayer2(), potentialWinner);

        }
        else if (CheckEquality())
        {
            Outputs.DisplayGameResultEqualityMorpion(GetGrid(), GetPlayer1(), GetPlayer2());
        }
    } 
    
    // Serialize the game to a file json
    public void SaveGameToFile(string path)
    {
        var jeu = new SerializableGame
        {
            gameMode = this.gameMode,
            grid = new SerializableGrid(),
            player1 = this.player1,
            player2 = this.player2
        };
        
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        var jsonString = JsonSerializer.Serialize(jeu, options);
        System.IO.File.WriteAllText(path, jsonString);
    }
}
