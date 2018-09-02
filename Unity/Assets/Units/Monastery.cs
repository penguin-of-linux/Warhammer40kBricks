using Extensibility;

public class Monastery : BuildingUnit
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

    public override int FramesToProduce
    {
        get { return 10; }
    }
}