namespace MorpionApp;

public class Program
{ 
    private static void Start()
    {
        var choice = Inputs.InputGameChoice();

        if (choice == "1")
        {
            var game = new Morpion();
            game.StartGame();
        }
        else if (choice == "2")
        {
            Console.WriteLine("A bientot !");
            Environment.Exit(0);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Choix incorrect\n");
            Start();
        }
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenue, à quoi souhaitez-vous jouer ?");
        while (true)
        {
            Start();
            Console.WriteLine("\nVoulez-vous rejouer ? Si oui, choisissez un jeu, sinon tapez 3");
        }
    }
}