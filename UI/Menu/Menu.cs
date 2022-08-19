using NA.UI.Blocks;
using NA.UI.Design;

namespace NA.UI.Menu;

public static class Screen
{
    public static void Generate(List<Option> options, IBlock block)
    {
        ConsoleKeyInfo keyInfo;
        int i = 0;

        Draw(options[i]);

        do
        {
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.DownArrow)
                if (i + 1 < options.Count)
                    Draw(options[++i]);

            if (keyInfo.Key == ConsoleKey.UpArrow)
                if (i - 1 >= 0)
                    Draw(options[--i]);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                options[i].Decision.Invoke();
                break;
            }
        } while (keyInfo.Key != ConsoleKey.X);


        void Draw(Option selectedOption)
        {
            Console.Clear();

            block.Show();

            foreach (Option option in options)
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

public class Option
{
    public string Name { get; set; }

    public Action Decision { get; set; }

    public Option(string name, Action decision)
    {
        Name = name;
        Decision = decision;
    }
}