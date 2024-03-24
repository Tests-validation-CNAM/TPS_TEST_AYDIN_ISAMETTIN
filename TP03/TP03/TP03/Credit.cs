namespace TP03;

public class Credit
{
    public double Montant { get; private set; }
    public int Duree { get; private set; }
    public double Taux { get; private set; }

    public Credit(double montant, int duree, double taux)
    {
          Montant = montant;
          Duree = duree;
          Taux = taux;
    }
}
