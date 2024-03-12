namespace MorpionApp;

public class Checks
{
    public static bool IsPlayerBot(Player player)
    {
        return player.GetIsBot() == 1;
    }

    public static bool IsInputByCellValid(int input, int maxInput)
    {
        return input <= maxInput && input > 0;
    }
    
    public static bool IsInputByColumnValid(int input, int maxInput)
    {
        return input >= 1 && input <= maxInput;
    }

    public static bool IsInputValidGameModes(int input)
    {
        return input < 3 && input > 0;
    }
}