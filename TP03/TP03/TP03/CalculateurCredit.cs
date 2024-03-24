namespace TP03;

static public class CalculateurCredit
{
    public static double CalculMensualite(Credit Credit)
    {
        double tauxMensuel = Credit.Taux / 100 / 12;
        double mensualite = Credit.Montant * tauxMensuel / (1 - Math.Pow(1 + tauxMensuel, -Credit.Duree));
        return mensualite;
    }

    public static List<Mensualite> CalculMensualites(Credit Credit)
    {
        double tauxMensuel = Credit.Taux / 100 / 12;
        double mensualite = Credit.Montant * tauxMensuel / (1 - Math.Pow(1 + tauxMensuel, -Credit.Duree));
        double resteApayer = Credit.Montant;
        List<Mensualite> mensualites = new List<Mensualite>();

        for (int i = 1; i <= Credit.Duree; i++)
        {
            if (resteApayer < mensualite)
            {
                mensualite = resteApayer * (1 + tauxMensuel);
            }
            double interetPaye = resteApayer * tauxMensuel;
            double capitalPaye = mensualite - interetPaye;
            resteApayer -= capitalPaye;

            mensualites.Add(new Mensualite(i, Credit.Montant - resteApayer, resteApayer));
        }

        return mensualites;
    }


    public static double CalculCoutTotal(Credit Credit)
    {
        double mensualite = CalculMensualite(Credit);
        double coutTotal = mensualite * Credit.Duree - Credit.Montant;

        return coutTotal;
    }
}
