namespace TP03;

public class CalculateurCreditTest
{
    [Theory]
    [InlineData(300000, 300, 4.15, 1608.46)]
    [InlineData(50000, 300, 4.15, 268.08)]
    [InlineData(100000, 300, 4.15, 536.15)]
    public void TestCalculateurCredit_ValidCalculMensualite(double montant, int duree, double taux, double result)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        double mensualite = CalculateurCredit.CalculMensualite(credit);

        // Assert
        Assert.Equal(result, mensualite, 2);
    }

    [Theory]
    [InlineData(300000, 300, 4.15, 1608.45)]
    [InlineData(50000, 300, 4.15, 268.07)]
    [InlineData(100000, 300, 4.15, 536.14)]
    public void TestCalculateurCredit_InvalidCalculMensualite(double montant, int duree, double taux, double result)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        double mensualite = CalculateurCredit.CalculMensualite(credit);

        // Assert
        Assert.NotEqual(result, mensualite, 2);
    }

    [Theory]
    [InlineData(300000, 300, 4.15, 182538.85)]
    [InlineData(50000, 300, 4.15, 30423.14)]
    [InlineData(100000, 300, 4.15, 60846.28)]
    public void TestCalculateurCredit_ValidCalculCoutTotal(double montant, int duree, double taux, double result)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        double coutTotal = CalculateurCredit.CalculCoutTotal(credit);

        // Assert
        Assert.Equal(result, coutTotal, 2);
    }

    [Theory]
    [InlineData(300000, 300, 4.15, 182538.84)]
    [InlineData(50000, 300, 4.15, 30423.13)]
    [InlineData(100000, 300, 4.15, 60846.27)]
    public void TestCalculateurCredit_InvalidCalculCoutTotal(double montant, int duree, double taux, double result)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        double coutTotal = CalculateurCredit.CalculCoutTotal(credit);

        // Assert
        Assert.NotEqual(result, coutTotal, 2);
    }

    [Theory]
    [InlineData(300000, 300, 4.15, 0, 300000)]
    [InlineData(50000, 300, 4.15, 0, 50000)]
    [InlineData(100000, 300, 4.15, 0, 100000)]
    public void TestCalculateurCredit_ValidCalculMensualites(double montant, int duree, double taux, double result, double result2)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        List<Mensualite> mensualites = CalculateurCredit.CalculMensualites(credit);

        // Assert
        Assert.Equal(result, mensualites.Last().CapitalRestantDu, 2);
        Assert.Equal(result2, mensualites.Last().CapitalRembourse, 2);
    }

    [Theory]

    [InlineData(300000, 300, 4.15, 1, 300001)]
    [InlineData(50000, 300, 4.15, 1, 50001)]
    [InlineData(100000, 300, 4.15, 1, 100001)]

    public void TestCalculateurCredit_InvalidCalculMensualites(double montant, int duree, double taux, double result, double result2)
    {
        // Arrange
        Credit credit= new Credit(montant, duree, taux);

        // Act
        List<Mensualite> mensualites = CalculateurCredit.CalculMensualites(credit);

        // Assert
        Assert.NotEqual(result, mensualites.Last().CapitalRestantDu, 2);
        Assert.NotEqual(result2, mensualites.Last().CapitalRembourse, 2);
    }

}
