namespace TP03;

public class CreditTest
{
    // inline data
    [Theory]
    [InlineData(300000, 300000)]
    [InlineData(50000, 50000)]
    [InlineData(100000, 100000)]
    public void TestCredit_ValidMontant(double montant, double result)
    {
        // Arrange
        Credit credit = new Credit(montant, 0, 0);

        // Act
        double montantResult = credit.Montant;

        // Assert
        Assert.Equal(result, montantResult);
    }

    [Theory]
    [InlineData(9 * 12, 9 * 12)]
    [InlineData(25 * 12, 25 * 12)]
    [InlineData(12 * 12, 12 * 12)]
    public void TestCredit_ValidDuree(int duree, int result)
    {
        // Arrange
        Credit credit = new Credit(0, duree, 0);

        // Act
        int dureeResult = credit.Duree;

        // Assert
        Assert.Equal(result, dureeResult);
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    public void TestCredit_ValidTaux(double taux, double result)
    {
        // Arrange
        Credit credit = new Credit(0, 0, taux);

        // Act
        double tauxResult = credit.Taux;

        // Assert
        Assert.Equal(result, tauxResult);
    }
}
