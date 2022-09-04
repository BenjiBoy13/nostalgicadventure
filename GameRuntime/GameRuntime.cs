namespace NA.GameRuntime;

using NA.Game.Entity;
using NA.GamePlay.Screen;

public static class GameRuntime
{
    public static void Start()
    {
        Console.Title = "Nostalgia Adventure";
        Player player = new Player(name: "", description: "", health: 100, damage: 1, defense: 0, level: 0, damageMultiplier: 1);

        IScreen? screen = null;

        while (true)
        {
            screen = ScreenGenerator.Generate(screen, player);
            screen.Load();
        }
    }
}