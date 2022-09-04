namespace NA.UI.Blocks;

public interface IBlock
{
    public ContentType ContentType { get; init; }

    public void Show();

}

public enum ContentType { START, CHARACTER_CUSTOMIZATION, TUTORIAL }

public class NormalBlock : IBlock
{
    public ContentType ContentType { get; init; }

    public void Show()
    {
        switch (ContentType)
        {
            case ContentType.START:
                Console.WriteLine("-- Welcome to Nostaligia Adventure --");
                Console.WriteLine("");
                Console.WriteLine("This is a RPG Adventure Text-Based Game developed by me, Benjamin. I surely hope you enjoy your stay...");
                Console.WriteLine("");
                Console.WriteLine("");
                break;
        }
    }
}

public class CustomBlock : IBlock
{
    public ContentType ContentType { get; init; }

    public string Content{ get; init; }

    public void Show()
    {
        switch (ContentType)
        {
            case ContentType.CHARACTER_CUSTOMIZATION:
                Console.WriteLine("-- Customize your character --");
                Console.WriteLine(Content);
                Console.WriteLine("");
                break;
        }
    }
}