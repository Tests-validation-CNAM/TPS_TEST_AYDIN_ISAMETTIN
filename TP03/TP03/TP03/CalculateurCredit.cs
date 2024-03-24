namespace TP03;

public class CalculateurCredit
{
    public Credit Credit { get; private set; }

    public CalculateurCredit(Credit credit)
    {
        this.Credit = credit;
    }

    public double CalculMensualite()
    {
        double tauxMensuel = Credit.Taux / 100 / 12;
        int duree = Credit.Duree;
        double mensualite = Credit.Montant * (tauxMensuel / (1 - Math.Pow(1 + tauxMensuel, -duree)));

        return Math.Round(mensualite, 2);
    }
}
