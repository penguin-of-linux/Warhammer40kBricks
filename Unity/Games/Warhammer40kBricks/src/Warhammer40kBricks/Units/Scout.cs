using Extensibility;

namespace Warhammer40kBricks.Units
{
    public class Scout : MovableUnit
    {
        public Scout(int id) : base(id)
        {
        }

        public override string Name => "Scout";
        public override int FramesToProduce => 5;
        public override double Speed => 1;
        public override double RotationSpeed => 1;
    }
}
