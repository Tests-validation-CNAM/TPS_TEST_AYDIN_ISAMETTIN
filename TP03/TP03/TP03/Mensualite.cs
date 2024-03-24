namespace TP03;

public class Mensualite
{
    public int Numero { get; private set; }
    public double CapitalRembourse { get; private set; }
    public double CapitalRestantDu { get; private set; }

    public Mensualite(int numero, double montantPaye, double resteAPayer)
    {
        this.Numero = numero;
        this.CapitalRembourse = montantPaye;
        this.CapitalRestantDu = resteAPayer;
    }
}
