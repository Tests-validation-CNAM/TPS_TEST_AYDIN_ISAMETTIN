namespace TP03;

public class Program
{
    public static void Main(string[] args)
    {
        InputHandler inputHandler = new InputHandler(args);

        double montant = inputHandler.InputMontant();
        int duree = inputHandler.InputDuree();
        double taux = inputHandler.InputTaux();

        Credit credit = new Credit(montant, duree, taux);

        CSVManager.WriteCSV("mensualités.csv", credit);
    }
}