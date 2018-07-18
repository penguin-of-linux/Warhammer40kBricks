namespace Extensibility
{
    public abstract class CombatUnit : Unit, ICombatUnit
    {
        protected CombatUnit(int id) : base(id)
        {
        }

        public abstract int FireRadius { get; }
        public abstract int Damage { get; }
    }
}