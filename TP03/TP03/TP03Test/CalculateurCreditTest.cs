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

}
