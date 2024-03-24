﻿namespace TP03;

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
        CalculateurCredit calculator = new CalculateurCredit(credit);

        // Act
        double mensualite = calculator.CalculMensualite();

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
        CalculateurCredit calculator = new CalculateurCredit(credit);

        // Act
        double mensualite = calculator.CalculMensualite();

        // Assert
        Assert.NotEqual(result, mensualite, 2);
    }

}