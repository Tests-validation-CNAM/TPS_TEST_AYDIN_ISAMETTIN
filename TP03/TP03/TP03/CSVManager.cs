namespace TP03;

public static class CSVManager
{
    public static string HEADER = "Mensualite;Capital Rembourse;Capital Restant Du";

    public static void WriteCSV(string path, Credit credit)
    {

        using (StreamWriter writer = new(path))
        {
            writer.WriteLine("Montant total du credit : " + Math.Round(credit.Montant), 2);
            writer.WriteLine("Duree du credit : " + credit.Duree);
            writer.WriteLine("Taux du credit : " + credit.Taux);
            writer.WriteLine("Cout total du credit : " + Math.Round(CalculateurCredit.CalculCoutTotal(credit), 2));
            writer.WriteLine(HEADER);
            foreach (Mensualite mensualite in credit.Mensualites)
            {
                writer.WriteLine(mensualite.Numero + ";" + Math.Round(mensualite.CapitalRembourse, 2) + ";" + Math.Round(mensualite.CapitalRestantDu, 2)) ;  
            }
        }
    }
}
