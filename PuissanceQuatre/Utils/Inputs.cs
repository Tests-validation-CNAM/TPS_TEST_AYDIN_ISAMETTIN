namespace MorpionApp;

public class Inputs
{
    public static string InputGameChoice()
    {
        Outputs.DisplayGameChoices();
        var choice = Console.ReadLine();
        return choice;
    }

    public static void InputBotPlayerMorpion(Grid grid, Player player)
    {
        grid.GetCell(BotRandomInputGeneratorMorpion(grid)).SetOwner(player.GetId());
    }

    public static int BotRandomInputGeneratorMorpion(Grid grid)
    {
        var rand = new Random();
        var randomPlay = rand.Next(0, 9);

        while (grid.GetCell(randomPlay / grid.GetColumnSize(), randomPlay % grid.GetColumnSize()).GetOwner() != 0)
            randomPlay = rand.Next(0, 9);

        return randomPlay;
    }

    public static void InputByCellPlayer(Grid grid, Player player, int maxInput)
    {
        var input = GetNumericInput();
        SetInputByCell(grid, player, input, maxInput);
    }
    
    public static void SetInputByCell(Grid grid, Player player, int input, int maxInput)
    {
        if (Checks.IsInputByCellValid(input, maxInput))
        {
            SetInputtedCell(grid, player, input, maxInput);
        }
        else
        {
            Outputs.DisplayInputtedCellIsNotValid(maxInput);
            InputByCellPlayer(grid, player, maxInput);
        }
    }
    
    public static void SetInputtedCell(Grid grid, Player player, int input, int maxInput)
    {
        if (!grid.SetCellOwnerIfEmpty(input - 1, player.GetId()))
        {
            Outputs.DisplayCellIsNotEmptyErrorMessageMorpion();
            InputByCellPlayer(grid, player, maxInput);
        }
    }
    
    public static void InputByCell(Grid grid, Player player, int maxInput)
    {
        if (Checks.IsPlayerBot(player))
            InputBotPlayerMorpion(grid, player);
        else
            InputByCellPlayer(grid, player, maxInput);
    }
    
    public static void InputByColumn(Grid grid, Player player, int maxInput)
    {
        if (Checks.IsPlayerBot(player))
        {
            InputBotPlayerMPuissance4(grid, player);
        }
        else
        {
            InputByColumnPlayer(grid, player, maxInput);
        }
    }
    
    public static void InputBotPlayerMPuissance4(Grid grid, Player player)
    {
        Cell randomInput = BotRandomInputGeneratorPuissance4(grid);
        grid.SetCellOwnerIfEmpty(randomInput.GetIdCell(), player.GetId());
    }
    
    public static void InputByColumnPlayer(Grid grid, Player player, int maxInput)
    {
        int input = GetNumericInput();
        SetInputByColumn(grid, player, input, maxInput);
    }
    
    public static void SetInputByColumn(Grid grid, Player player, int input, int maxInput)
    {
        if (Checks.IsInputByColumnValid(input, maxInput))
        {
            SetInputtedColumn(grid, player, input, maxInput);
        }
        else
        {
            Outputs.DisplayInputtedCellIsNotValid(maxInput);
            InputByColumnPlayer(grid, player, maxInput);
        }
    }
    
    public static void SetInputtedColumn(Grid grid, Player player, int input, int maxInput)
    {
        for (int ligne = 0; ligne < grid.GetLineSize(); ligne++)
        {
            if (grid.IsCellFree(ligne, input - 1))
            {
                grid.SetCellOwnerIfEmpty(ligne, input - 1, player.GetId());
                break;
            }
            else if (ligne == grid.GetLineSize() - 1)
            {
                Outputs.DisplayColumnIsFullErrorMessagePuissance4();
                InputByColumnPlayer(grid, player, maxInput);
            }
        }
    }
    
    public static Cell BotRandomInputGeneratorPuissance4(Grid grid)
    {
        Random random = new Random();
        int randomColumn;
        while (true)
        {
            randomColumn = random.Next(grid.GetColumnSize());
            for (int ligne = 0; ligne < grid.GetLineSize(); ligne++)
            {
                if(grid.IsCellFree(ligne, randomColumn))
                {
                    return grid.GetCell(ligne, randomColumn);
                }
            }
        }
    }
    
    public static int GetNumericInput()
    {
        var input = 0;
        var isValid = int.TryParse(Console.ReadLine(), out input);

        while (!isValid)
        {
            Console.WriteLine("Entrée non numérique. Veuillez réessayer.");
            isValid = int.TryParse(Console.ReadLine(), out input);
        }

        return input;
    }

    public static void InputPlayersNames(Player player1, Player player2)
    {
        InputPlayer1Name(player1);
        InputPlayer2Name(player2);
    }

    public static void InputPlayer1Name(Player player1)
    {
        Outputs.DisplayInputMessagePlayer1Name();
        var namePlayer = GetStringInput();
        player1.SetName(namePlayer);
    }

    public static void InputPlayer2Name(Player player2)
    {
        if (0 == player2.GetIsBot())
        {
            Outputs.DisplayInputMessagePlayer2Name();
            var namePlayer = GetStringInput();
            player2.SetName(namePlayer);
        }
    }

    public static int InputGameMode()
    {
        Outputs.DisplayGameModes();
        var input = GetNumericInput();

        if (!Checks.IsInputValidGameModes(input))
        {
            Outputs.DisplayInputIsNotValidErrorMessageGameModes();
            return InputGameMode();
        }

        return input;
    }

    public static string GetStringInput()
    {
        return Console.ReadLine();
    }
}