using Extensibility;

namespace Tests
{
    public class SimpleCombatUnit : CombatUnit
    {
        public SimpleCombatUnit(int id) : base(id)
        {
        }

        public override int FireRadius => 5;
        public override int Damage => 1;
        public override int FramesToProduce => 100;
    }
}