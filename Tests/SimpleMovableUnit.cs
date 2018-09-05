using Extensibility;

namespace Tests
{
    class SimpleMovableUnit : MovableUnit
    {
        public SimpleMovableUnit(int id) : base(id)
        {
        }

        public override string Name => "lalala";
        public override double Speed => 5;
        public override double RotationSpeed => 0.01;
        public override int FramesToProduce => 100;
    }
}
