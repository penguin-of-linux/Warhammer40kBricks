namespace Extensibility
{
    public abstract class CombatMovableUnit : Unit, ICombatUnit, IMovableUnit
    {
        protected CombatMovableUnit(int id) : base(id)
        {
        }

        public abstract int FireRadius { get; }
        public abstract int Damage { get; }
        public abstract double Speed { get; }
        public abstract double RotationSpeed { get; }
    }
}