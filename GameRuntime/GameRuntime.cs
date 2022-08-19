namespace NA.GameRuntime;

using NA.UI.Blocks;
using NA.UI.Menu;

public static class GameRuntime
{
    public static void Start()
    {
        
        Console.Title = "Nostalgia Adventure";

        List<Option> options = new List<Option>
        {
            new Option("Start Game", () => Console.WriteLine("STARTING GAME")),
            new Option("Exit", () => Environment.Exit(0))
        };

        Screen.Generate(options, new NormalBlock { ContentType = ContentType.START });
    }
}