using NA.UI.Blocks;

namespace NA.GamePlay.Screen;

public static class ScreenGenerator 
{
    public static IScreen Generate(IScreen? previousScreen)
    {
        if (previousScreen == null)
            return new StartScreen(
                new NormalBlock { ContentType = ContentType.START },
                new List<Option> {
                    new Option("Start Game", null),
                    new Option("Exit", () => Environment.Exit(0)) }
            );

        throw new NotImplementedException();
    }
}