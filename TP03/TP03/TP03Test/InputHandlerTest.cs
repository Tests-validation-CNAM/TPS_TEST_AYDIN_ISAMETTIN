namespace TP03;

public class InputHandlerTest
{
    [Theory]
    [InlineData(null, null, null)]
    [InlineData(null, "240", "3,5")]
    [InlineData("300000", null, "3,5")]
    [InlineData("300000", "240", null)]
    public void TestInputHandler_InvalidInput(string montant, string duree, string taux)
    {
        // Arrange
        string[] args = { montant, duree, taux };

        // Act
        Action action = () => new InputHandler(args);

        // Assert
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Expected 3 arguments: montant, duree, taux", exception.Message);
    }

    [Theory]
    [InlineData("300000", 300000)]
    [InlineData("50000", 50000)]
    [InlineData("  100000  ", 100000)]
    public void TestInputMontant_ValidMontant(string input, double result)
    {
        // Arrange
        string[] args = {input, "108", "4.1" };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        double montant = inputHandler.InputMontant();

        // Assert
        Assert.Equal(result, montant);
    }

    [Fact]
    public void TestInputMontant_InvalidStringFormat()
    {
        // Arrange
        string[] args = {"InvalidInput", "108", "4.1" };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        Action Action = () => inputHandler.InputMontant();

        // Assert
        var exception = Assert.Throws<FormatException>(Action);
        Assert.Equal("One of the identified items was in an invalid format.", exception.Message);
    }

    [Fact]
    public void TestInputMontant_InvalidMontantMin()
    {
        // Arrange
        string[] args = { "49000", "108", "4.1" };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        Action Action = () => inputHandler.InputMontant();

        // Assert
        var exception = Assert.Throws<ArgumentException>(Action);
        Assert.Equal("Le montant doit être d'au moins 50000€", exception.Message);
    }

    [Fact]
    public void TestInputMontant_InvalidMontantNegatif()
    {
        // Arrange
        string[] args = { "-50000", "108", "4.1" };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        Action Action = () => inputHandler.InputMontant();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);
        Assert.Equal("Specified argument was out of the range of valid values.", exception.Message);
    }

    [Fact]
    public void TestInputDuree_ValidDuree()
    {
        // Arrange
        string[] args = { "50000", "108", "4.1" };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        int duree = InputHandler.InputDuree();

        // Assert
        Assert.Equal(108, duree);
    }

    [Fact]
    public void TestInputDuree_InvalidStringFormat()
    {
        // Arrange
        string[] args = { "50000", "InvalidInput", "4.1"};
        InputHandler InputHandler = new InputHandler(args);

        // Act
        Action action = () => InputHandler.InputDuree();

        // Assert
        var exception = Assert.Throws<FormatException>(action);
        Assert.Equal("One of the identified items was in an invalid format.", exception.Message);
    }

    [Fact]
    public void TestInputDuree_InvalidDuree()
    {
        // Arrange
        string[] args = { "50000", "107", "4.1" };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        Action action = () => InputHandler.InputDuree();

        // Assert
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("La durée doit être comprise entre 108 et 300 mois", exception.Message);
    }

    [Fact]
    public void TestInputTaux_ValidTaux()
    {
        // Arrange
        string[] args = { "50000", "240", "3,5" };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        double taux = InputHandler.InputTaux();

        // Assert
        Assert.Equal(3.5, taux);
    }

    [Fact]
    public void TestInputTaux_InvalidTaux()
    {
        // Arrange
        string[] args = { "50000", "240", "122" };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        Action action = () => InputHandler.InputTaux();

        // Assert
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("Le taux d'intérêt annuel doit être compris entre 0% et 100%", exception.Message);
    }
}