namespace TP03;

public class InputHandlerTest
{
    // inline data
    [Theory]
    [InlineData("300000", 300000)]
    [InlineData("50000", 50000)]
    [InlineData("  100000  ", 100000)]
    public void TestInputMontant_ValidMontant(string input, double result)
    {
        // Arrange
        string[] args = { input };
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
        string[] args = { "InvalidInput" };
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
        string[] args = { "49000" };
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
        string[] args = { "-50000" };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        Action Action = () => inputHandler.InputMontant();

        // Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);
        Assert.Equal("Specified argument was out of the range of valid values.", exception.Message);
    }

    [Fact]
    public void TestInputMontant_InvalidMontantNull()
    {
        // Arrange
        string[] args = { null };
        InputHandler inputHandler = new InputHandler(args);

        // Act
        Action action = () => inputHandler.InputMontant();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("Value cannot be null.", exception.Message);
    }

    [Fact]
    public void TestInputDuree_ValidDuree()
    {
        // Arrange
        string[] args = { "50000", "108" };
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
        string[] args = { "50000", "InvalidInput" };
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
        string[] args = { "50000", "107" };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        Action action = () => InputHandler.InputDuree();

        // Assert
        var exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("La durée doit être comprise entre 108 et 300 mois", exception.Message);
    }

    [Fact]
    public void TestInputDuree_InvalidDureeNull()
    {
        // Arrange
        string[] args = { "50000", null };
        InputHandler InputHandler = new InputHandler(args);

        // Act
        Action action = () => InputHandler.InputDuree();

        // Assert
        var exception = Assert.Throws<ArgumentNullException>(action);
        Assert.Equal("Value cannot be null.", exception.Message);
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