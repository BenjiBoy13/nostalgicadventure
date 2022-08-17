namespace NA.GameRuntime;

using NA.Game.Entity;
using NA.UI.Menu;

public static class GameRuntime
{
    public static void Start()
    {
        List<Option> options = new List<Option>
        {
            new Option("Start Game", () => Console.WriteLine("STARTING GAME")),
            new Option("Exit", () => Console.WriteLine("CLOSE"))
        };

        Menu.Generate(options);
    }
}