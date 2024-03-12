namespace MorpionApp;

public class Outputs
{
    public static void DisplayGameChoices()
    {
        Console.WriteLine("1. Morpion");
        Console.WriteLine("2. Puissance 4");
        Console.WriteLine("3. Quitter\n");
        Console.Write("Choix : ");
    }

    public static void DisplayGameMorpion(Grid grid, Player player1, Player player2, Player currentPlayer)
    {
        Console.Clear();
        DisplayPlayersMorpion(player1, player2);
        DisplayGridMorpion(grid);
        DisplayInputMessageMorpion(currentPlayer);
    }
    
    public static void DisplayGamePuissance4(Grid grid, Player player1, Player player2, Player currentPlayer)
    {
        Console.Clear();
        DisplayPlayersPuissance4(player1, player2);
        DisplayGridPuissance4(grid);
        DisplayInputMessagePuissance4(currentPlayer);
    }

    public static void DisplayPlayersMorpion(Player player1, Player player2)
    {
        Console.WriteLine(GetRedText("Joueur " + player1.GetName() + " (X)") + "  -  " +
                          GetGreenText("Joueur " + player2.GetName() + " (O)") + "\n");
    }
    
    
    public static void DisplayPlayersPuissance4(Player player1, Player player2)
    {
        Console.WriteLine(GetRedText("Joueur " + player1.GetName()) + "  -  " + GetGreenText("Joueur " + player2.GetName()) + "\n");
    }

    public static void DisplayGridMorpion(Grid grid)
    {
        Console.WriteLine();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  " + DisplayCellMorpion(grid.GetCell(i * 3)) + "  |  " + DisplayCellMorpion(grid.GetCell(i * 3 + 1)) +
                              "  |  " + DisplayCellMorpion(grid.GetCell(i * 3 + 2)));
            if (i < 2)
                Console.WriteLine("_____|_____|_____");
            else
                Console.WriteLine("     |     |     \n");
        }
    }
    
    public static void DisplayGridPuissance4(Grid grid)
    {
        Console.WriteLine();
        Console.WriteLine("|  1  |  2  |  3  |  4  |  5  |  6  |  7  |");
        Console.WriteLine(" _________________________________________");

        for (int i = 21; i >= 0; i -= 7)
        {
            Console.WriteLine("|     |     |     |     |     |     |     |");
            Console.Write("|");
            for (int j = 0; j < 7; j++)
            {
                Console.Write($"  {DisplayCellPuissance4(grid.GetCell(i + j))}  |");
            }
            Console.WriteLine();
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|");
        }
        Console.WriteLine();
    }
    
    public static void DisplayInputMessageMorpion(Player player)
    {
        if (player.GetId() == 1)
        {
            Console.WriteLine("Tour " + GetRedText("joueur " + player.GetName()) +
                              ", dans quelle case voulez-vous jouer ?");
        }
        else
        {
            if (player.GetIsBot() == 0)
            {
                Console.WriteLine("Tour " + GetGreenText("joueur " + player.GetName()) +
                                  ", dans quelle case voulez-vous jouer ?");
            }
            else
            {
                Console.WriteLine("Le " + GetGreenText("joueur " + player.GetName()) + " joue son tour");
                Thread.Sleep(500);
            }
        }
    }
    
    public static void DisplayInputMessagePuissance4(Player player)
    {
        if (player.GetId() == 1)
        {
            Console.WriteLine("Tour " + GetRedText("joueur " + player.GetName()) + ", dans quelle colonne voulez-vous jouer ? ");
        }
        else
        {
            if (player.GetIsBot() == 0)
            {
                Console.WriteLine("Tour " + GetGreenText("joueur " + player.GetName()) + ", dans quelle colonne voulez-vous jouer ? ");
            }
            else
            {
                Console.WriteLine("Le " + GetGreenText("joueur " + player.GetName()) + " joue son tour");
                Thread.Sleep(500);
            }
        }
    }

    public static string GetRedText(string text)
    {
        return "\u001b[1;31m" + text + "\u001b[0m";
    }

    public static string GetGreenText(string text)
    {
        return "\u001b[1;32m" + text + "\u001b[0m";
    }

    public static string DisplayCellMorpion(Cell cell)
    {
        var str = (cell.GetIdCell() + 1).ToString();
        if (cell.GetOwner() == 1)
            str = GetRedText("X");
        else if (cell.GetOwner() == 2) str = GetGreenText("O");
        return str;
    }
    
    public static string DisplayCellPuissance4(Cell cell)
    {
        string str = " ";
        if (cell.GetOwner() == 1)
        {
            str = GetRedText("O");
        }
        else if (cell.GetOwner() == 2)
        {
            str = GetGreenText("O");
        }
        return str;
    }

    public static void DisplayInputMessagePlayer1Name()
    {
        Console.Clear();
        Console.WriteLine("Entrez le nom du joueur 1");
        Console.Write("-> ");
    }

    public static void DisplayInputMessagePlayer2Name()
    {
        Console.WriteLine("\nEntrez le nom du joueur 2");
        Console.Write("-> ");
    }

    public static void DisplayGameResultWinMorpion(Grid grid, Player player1, Player player2, Player winner)
    {
        Console.Clear();
        DisplayPlayersMorpion(player1, player2);
        DisplayGridMorpion(grid);
        DisplayWinMessage(winner);
    }
    
    public static void DisplayGameResultWinPuissance4(Grid grid, Player player1, Player player2, Player winner)
    {
        Console.Clear();
        DisplayPlayersPuissance4(player1, player2);
        DisplayGridPuissance4(grid);
        DisplayWinMessage(winner);
    }

    public static void DisplayWinMessage(Player winner)
    {
        Console.WriteLine("Le joueur " + GetPlayerNameColored(winner) + " a gagné");
    }

    public static string GetPlayerNameColored(Player player)
    {
        if (player.GetId() == 1)
            return GetRedText(player.GetName());
        return GetGreenText(player.GetName());
    }

    public static void DisplayGameResultEqualityMorpion(Grid grid, Player player1, Player player2)
    {
        Console.Clear();
        DisplayPlayersMorpion(player1, player2);
        DisplayGridMorpion(grid);
        DisplayEqualityMessage();
    }
    
    public static void DisplayGameResultEqualityPuissance4(Grid grid, Player player1, Player player2)
    {
        Console.Clear();
        DisplayPlayersPuissance4(player1, player2);
        DisplayGridPuissance4(grid);
        DisplayEqualityMessage();
    }

    public static void DisplayEqualityMessage()
    {
        Console.WriteLine("Le jeu se termine sur une égalité");
    }

    public static void DisplayInputtedCellIsNotValid(int maxInput)
    {
        Console.WriteLine("Veuillez saisir un chiffre entre 1 et " + maxInput);
    }

    public static void DisplayCellIsNotEmptyErrorMessageMorpion()
    {
        Console.WriteLine("La case est déjà occupée, veuillez choisir une autre case");
    }

    public static void DisplayGameModes()
    {
        Console.WriteLine("\nA quelle mode de jeu voulez-vous jouer ?");
        Console.WriteLine("1 - Joueur contre Joueur");
        Console.WriteLine("2 - Joueur contre IA\n");
        Console.Write("Choix : ");
    }

    public static void DisplayInputIsNotValidErrorMessageGameModes()
    {
        Console.Clear();
        Console.WriteLine("Veuillez saisir un choix valide");
    }
    
    public static void DisplayColumnIsFullErrorMessagePuissance4()
    {
        Console.WriteLine("La colonne est pleine, veuillez choisir une autre colonne");
    }
}