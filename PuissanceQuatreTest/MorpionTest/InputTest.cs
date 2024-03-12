namespace MorpionApp.Tests;

public class InputTest
{
    [Fact]
    public void IsInputByCellValid_InputIsGreaterThanMaxInput_ReturnsFalse()
    {
        // Arrange
        int input = 10;
        int maxInput = 9;

        // Act
        bool result = MorpionApp.Checks.IsInputByCellValid(input, maxInput);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsInputByCellValid_InputIsLessThanMaxInput_ReturnsTrue()
    {
        // Arrange
        int input = 5;
        int maxInput = 9;

        // Act
        bool result = MorpionApp.Checks.IsInputByCellValid(input, maxInput);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsInputByColumnValid_InputIsGreaterThanMaxInput_ReturnsFalse()
    {
        // Arrange
        int input = 10;
        int maxInput = 9;

        // Act
        bool result = MorpionApp.Checks.IsInputByColumnValid(input, maxInput);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsInputByColumnValid_InputIsLessThanMaxInput_ReturnsTrue()
    {
        // Arrange
        int input = 5;
        int maxInput = 9;

        // Act
        bool result = MorpionApp.Checks.IsInputByColumnValid(input, maxInput);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsInputValidGameModes_InputIsGreaterThanMaxInput_ReturnsFalse()
    {
        // Arrange
        int input = 3;

        // Act
        bool result = MorpionApp.Checks.IsInputValidGameModes(input);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void IsInputValidGameModes_InputIsLessThanMaxInput_ReturnsTrue()
    {
        // Arrange
        int input = 2;

        // Act
        bool result = MorpionApp.Checks.IsInputValidGameModes(input);

        // Assert
        Assert.True(result);
    }
    
}