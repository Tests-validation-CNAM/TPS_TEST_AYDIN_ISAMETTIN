namespace TP03;

public class InputHandlerTest
{
    [Fact]
    public void TestGetMontant()
    {
        // Arrange
        double[] args = new double[] { 300000 };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        double montant = inputHandler.getMontant();

        // Assert
        Assert.Equal(300000, montant);
    }
}