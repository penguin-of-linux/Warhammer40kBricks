using Extensibility;

namespace Warhammer40kBricks.Units
{
    public class Scout : MovableUnit, ICombatUnit
    {
        public Scout(int id) : base(id)
        {
        }

        public override string Name => "Scout";
        public override int MaxHeal => 100;
        public override int FramesToProduce => 15;
        public override double Speed => 0.5;
        public override double RotationSpeed => 1;
        public int FireRadius => 10;
        public int Damage => 10;
    }
}
