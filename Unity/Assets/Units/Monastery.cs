using Extensibility;

public class Monastery : Building
{
    public Monastery(int id) : base(id)
    {
    }

    public override int Width
    {
        get { return 40; }
    }

    public override int Height
    {
        get { return 40; }
    }
}