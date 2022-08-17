namespace NA.UI.Menu;

public static class Menu
{
    public static void Generate(List<Option> options)
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

        Console.WriteLine("OUT");

        void Draw(Option selectedOption)
        {
            Console.Clear();

            foreach (Option option in options)
            {
                if (option == selectedOption) Console.Write("> ");
                else Console.Write(" ");

                Console.WriteLine(option.Name);
            }
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