using NA.Game.Entity;
using NA.UI.Blocks;

namespace NA.GamePlay.Screen;

public static class ScreenGenerator 
{
    public static IScreen Generate(IScreen? previousScreen, Player player)
    {
        if (previousScreen is null)
            return new StartScreen(
                block: new NormalBlock { ContentType = ContentType.START },
                options: new List<Option> {
                    new Option("Start Game", null),
                    new Option("Exit", () => Environment.Exit(0)) },
                player: player
            );

        if (previousScreen is StartScreen)
            return new StartInputScreen(
                    block: new CustomBlock {  ContentType = ContentType.CHARACTER_CUSTOMIZATION, Content = "A great story starts as always with a hero, and hero's always bare a name" },
                    question: "Name your character: ",
                    player: player
                );

        if (previousScreen is StartInputScreen)
            return new BasicChoiceScreen(
                    block: new CustomBlock { ContentType = ContentType.CHARACTER_CUSTOMIZATION, Content = "Choose your weapon" },
                    options: new List<Option>
                    {
                        new Option("Long Sword", () => player.Inventory.Add(new Weapon(name: "Long Sword", description: "A long sword, good for killing trolls", damage: 10, durability: 100))),
                        new Option("Axe", () => player.Inventory.Add(new Weapon(name: "Axe", description: "Strong but fragile", damage: 20, durability: 50)))
                    },
                    player: player
                );

        Console.WriteLine("");
        Console.WriteLine(player.Name);
        Console.WriteLine(player.Inventory[0].Name);
        throw new NotImplementedException();
    }
}