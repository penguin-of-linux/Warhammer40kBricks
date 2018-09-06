using Extensibility;

namespace Warhammer40kBricks.Units
{
    public class Scout : MovableUnit
    {
        public Scout(int id) : base(id)
        {
        }

        public override string Name => "Scout";
        public override int FramesToProduce => 120;
        public override double Speed => 0.5;
        public override double RotationSpeed => 1;
    }
}
