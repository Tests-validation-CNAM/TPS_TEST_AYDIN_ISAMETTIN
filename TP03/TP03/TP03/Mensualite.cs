namespace TP03;

public class Mensualite
{
    public int Numero { get; private set; }
    public double MontantPaye { get; private set; }
    public double ResteAPayer { get; private set; }

    public Mensualite(int numero, double montantPaye, double resteAPayer)
    {
        this.Numero = numero;
        this.MontantPaye = montantPaye;
        this.ResteAPayer = resteAPayer;
    }
}
