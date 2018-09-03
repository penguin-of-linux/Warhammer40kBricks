using Extensibility;

namespace Warhammer40kBricks.Units
{
    public class Scout : MovableUnit
    {
        public Scout(int id) : base(id)
        {
        }

        public override int FramesToProduce
        {
            get { return 5; }
        }
        public override double Speed
        {
            get { return 1; }
        }
        public override double RotationSpeed
        {
            get { return 1; }
        }
    }
}
