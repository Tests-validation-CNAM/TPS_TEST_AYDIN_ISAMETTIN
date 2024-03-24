namespace TP03;

public class CSVManagerTest
{
    [Theory]
    [InlineData(1000, 50, 0.05)]
    [InlineData(5000, 100, 0.1)]
    [InlineData(10000, 200, 0.15)]
    public void WriteCSVTest(double montant, int duree, double taux)
    {
        // Arrange
        string path = "../../../../test.csv";
        Credit credit = new(montant, duree, taux);
        CSVManager.WriteCSV(path, credit);

        // Act
        string[] lines = File.ReadAllLines(path);

        // Assert
        Assert.Equal("Montant total du credit : " + Math.Round(credit.Montant, 2), lines[0]);
        Assert.Equal("Duree du credit : " + credit.Duree, lines[1]);
        Assert.Equal("Taux du credit : " + credit.Taux, lines[2]);
        Assert.Equal("Cout total du credit : " + Math.Round(CalculateurCredit.CalculCoutTotal(credit), 2), lines[3]);
        Assert.Equal(CSVManager.HEADER, lines[4]);
        Assert.Equal(credit.Mensualites[0].Numero + ";" + Math.Round(credit.Mensualites[0].CapitalRembourse, 2) + ";" + Math.Round(credit.Mensualites[0].CapitalRestantDu, 2), lines[5]);
        Assert.Equal(credit.Mensualites[1].Numero + ";" + Math.Round(credit.Mensualites[1].CapitalRembourse, 2) + ";" + Math.Round(credit.Mensualites[1].CapitalRestantDu, 2), lines[6]);
        Assert.Equal(credit.Mensualites[2].Numero + ";" + Math.Round(credit.Mensualites[2].CapitalRembourse, 2) + ";" + Math.Round(credit.Mensualites[2].CapitalRestantDu, 2), lines[7]);
        Assert.Equal(credit.Mensualites.Last().Numero + ";" + Math.Round(credit.Mensualites.Last().CapitalRembourse, 2) + ";" + Math.Round(credit.Mensualites.Last().CapitalRestantDu, 2), lines.Last());
    }
}
