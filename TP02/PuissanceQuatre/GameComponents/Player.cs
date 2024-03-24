namespace MorpionApp;

public class Player
{
    private readonly int id;
    private int isBot;
    private string name;

    public Player(int id, string name)
    {
        this.id = id;
        this.name = name;
        isBot = 0;
    }
    
    public Player(int id, string name, int isBot)
    {
        this.id = id;
        this.name = name;
        this.isBot = isBot;
    }

    public int GetId()
    {
        return id;
    }

    public string GetName()
    {
        return name;
    }

    public int GetIsBot()
    {
        return isBot;
    }

    public void SetName(string newName)
    {
        name = newName;
    }

    public void SetIsBot(int newSetting)
    {
        isBot = newSetting;
    }
}