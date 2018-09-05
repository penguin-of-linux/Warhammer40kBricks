using Extensibility;

namespace Tests
{
    public class SimpleCombatMovableUnit : CombatMovableUnit
    {
        public SimpleCombatMovableUnit(int id) : base(id)
        {
        }

        public override string Name => "lalala";
        public override int FireRadius => 5;
        public override int Damage => 1;
        public override double Speed => 5;
        public override double RotationSpeed => 1;
        public override int FramesToProduce => 100;
    }
}