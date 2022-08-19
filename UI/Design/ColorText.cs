namespace NA.UI.Design;

public static class ColorText
{
    public static void WriteWithForeground(string text, ConsoleColor consoleColor, bool writeLine)
    {
        Console.ForegroundColor = consoleColor;
        
        if (writeLine) Console.WriteLine(text);
        else Console.Write(text);

        Console.ForegroundColor = ConsoleColor.White;
    }
}