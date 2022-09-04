using NA.Game.Entity;
using NA.UI.Blocks;
using NA.UI.Design;

namespace NA.GamePlay.Screen;

public interface IScreen
{
    public void Load();

}

public abstract class ChoiceScreen : IScreen
{
    public abstract IBlock Block { get; init; }

    public abstract List<Option> Options { get; init; }

    public abstract Player Player { get; init; }

    public ChoiceScreen(IBlock block, List<Option> options, Player player)
    {
        Options = options;
        Block = block;
        Player = player;
    }

    public virtual void Load()
    {
        ConsoleKeyInfo keyInfo;
        int i = 0;

        Draw(Options[i]);

        do
        {
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
                if (i + 1 < Options.Count)
                    Draw(Options[++i]);

            if (keyInfo.Key == ConsoleKey.UpArrow)
                if (i - 1 >= 0)
                    Draw(Options[--i]);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Action? decision = Options[i].Decision;

                if (decision is not null) decision.Invoke();

                break;
            }
        } while (keyInfo.Key != ConsoleKey.X);

        void Draw(Option selectedOption)
        {
            Console.Clear();
            Block.Show();

            foreach (Option option in Options)
            {
                if (option == selectedOption)
                {
                    ColorText.WriteWithForeground("> ", ConsoleColor.Green, false);
                    ColorText.WriteWithForeground(option.Name, ConsoleColor.Green, true);
                    continue;
                }

                Console.Write(" ");
                ColorText.WriteWithForeground(option.Name, ConsoleColor.White, true);
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("-----");
            Console.WriteLine("You can move up and down the navegation menu's by using your arrow up and down keys, and ENTER to make a choice");
        }
    }
}

public abstract class InputScreen : IScreen
{
    public abstract IBlock Block { get; init; }

    public abstract string Question { get; init; }

    public abstract Player Player { get; init; }

    public abstract string Answer { get; protected set; }

    public InputScreen(IBlock block, string question, Player player)
    {
        Block = block;
        Question = question;
        Answer = "";
        Player = player;
    }

    public virtual void Load()
    {
        Console.Clear();

        Block.Show();

        Console.Write(Question + ": \t");
        Answer = Console.ReadLine() ?? throw new Exception("Must enter an answer");

        Console.WriteLine("");
        Console.WriteLine($"Press ENTER to continue");
        Console.ReadKey();
    }
}


public sealed class StartInputScreen : InputScreen, IScreen
{
    public override IBlock Block { get; init; }

    public override string Question { get; init; }

    public override string Answer { get; protected set; }

    public override Player Player { get; init; }

    public StartInputScreen(IBlock block, string question, Player player) : base(block, question, player)
    {
        Block = block;
        Question = question;
        Answer = "";
        Player = player;
    }

    public override void Load()
    {
        Console.Clear();

        Block.Show();

        Console.Write(Question + ": \t");
        Answer = Console.ReadLine() ?? throw new Exception("Must enter an answer");
        
        Player.Name = Answer;

        Console.WriteLine("");
        Console.WriteLine($"Press ENTER to start {Answer}'s adventure");
        Console.ReadKey();
    }
}

public sealed class StartScreen : ChoiceScreen, IScreen
{
    public override IBlock Block { get; init; }

    public override List<Option> Options { get; init; }

    public override Player Player { get; init; }

    public StartScreen(IBlock block, List<Option> options, Player player) : base(block, options, player)
    {
        Block = block;
        Options = options;
        Player = player;
    }
}

public sealed class BasicChoiceScreen : ChoiceScreen, IScreen
{
    public override IBlock Block { get; init; }

    public override List<Option> Options { get; init; }

    public override Player Player { get; init; }

    public BasicChoiceScreen(IBlock block, List<Option> options, Player player) : base(block, options, player)
    {
        Block = block;
        Options = options;
        Player = player;
    }
}

public class Option
{
    public string Name { get; set; }

    public Action? Decision { get; set; }

    public Option(string name, Action? decision)
    {
        Name = name;
        Decision = decision;
    }
}