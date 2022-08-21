namespace NA.GameRuntime;

using NA.GamePlay.Screen;

public static class GameRuntime
{
    public static void Start()
    {
        Console.Title = "Nostalgia Adventure";

        IScreen? screen = null;

        while (true)
        {
            screen = ScreenGenerator.Generate(screen);
            screen.Load();
        }
    }
}