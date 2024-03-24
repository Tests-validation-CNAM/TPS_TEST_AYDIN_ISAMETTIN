namespace TP03;

public class CreditTest
{
    [Theory]
    [InlineData(300000, 240, 4.15)]
    [InlineData(100000, 120, 4.15)]
    [InlineData(50000, 60, 4.15)]
    public void TestCredit(double montant, int duree, double taux)
    {
        Credit credit = new Credit(montant, duree, taux);
        List<Mensualite> mensualites = CalculateurCredit.CalculMensualites(credit);

        Assert.Equal(montant, credit.Montant);
        Assert.Equal(duree, credit.Duree);
        Assert.Equal(taux, credit.Taux);
        Assert.Equal(mensualites.Count, credit.Mensualites.Count);
        for (int i = 0; i < mensualites.Count; i++)
        {
            Assert.Equal(mensualites[i].Numero, credit.Mensualites[i].Numero);
            Assert.Equal(mensualites[i].CapitalRembourse, credit.Mensualites[i].CapitalRembourse);
            Assert.Equal(mensualites[i].CapitalRestantDu, credit.Mensualites[i].CapitalRestantDu);
        }
    }
}
