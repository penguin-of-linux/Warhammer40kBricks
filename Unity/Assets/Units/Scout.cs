using Extensibility;

public class Scout : CombatMovableUnit
{
    public Scout(int id) : base(id)
    {
    }

    public override int FireRadius
    {
        get { return 5; }
    }

    public override int Damage
    {
        get { return 1; }
    }

    public override double Speed
    {
        get { return 0.3; }
    }

    public override double RotationSpeed
    {
        get { return 0.5; }
    }
}