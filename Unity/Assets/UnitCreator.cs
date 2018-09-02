using Extensibility;

public class UnitCreator : IUnitCreator
{
    private int _counter = 0;

    public Unit CreateUnit(string unitName)
    {
        return new Scout(_counter++);
    }
}