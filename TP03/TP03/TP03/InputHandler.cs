namespace TP03;

public class InputHandler
{
    private string[] args;
    private const double MONTANT_MIN = 50000;
    private const double DUREE_MIN_MOIS = 9 * 12;
    private const double DUREE_MAX_MOIS = 25 * 12;
    private const double TAUX_MIN = 0;
    private const double TAUX_MAX = 100;

    public InputHandler(string[] args)
    {
        this.args = args;
    }

    public double InputMontant()
    {
        double montant = GetInput(0);

        if (montant < MONTANT_MIN)
        {
            throw new ArgumentException("Le montant doit être d'au moins " + MONTANT_MIN + "€");
        }

        return montant;
    }

    public int InputDuree()
    {
        int duree = (int)GetInput(1);

        if (duree < DUREE_MIN_MOIS || duree > DUREE_MAX_MOIS)
        {
            throw new ArgumentException("La durée doit être comprise entre " + DUREE_MIN_MOIS + " et " + DUREE_MAX_MOIS + " mois");
        }

        return duree;
    }

    public double InputTaux()
    {
        double taux = GetInput(2);

        if (taux <= TAUX_MIN || taux > TAUX_MAX)
        {
            throw new ArgumentException("Le taux d'intérêt annuel doit être compris entre 0 et 100%");
        }

        return taux;
    }

    private double GetInput(int index)
    {
        string input = args[index];

        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentNullException();
        }

        if (!double.TryParse(input, out double value))
        {
            throw new FormatException();
        }

        if (value < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        return value;
    }
}
