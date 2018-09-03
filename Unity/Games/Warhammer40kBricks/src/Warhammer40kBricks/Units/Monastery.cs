using Extensibility;

namespace Warhammer40kBricks.Units
{
    public class Monastery : BuildingUnit
    {
        public Monastery(int id) : base(id)
        {
        }

        public override int FramesToProduce
        {
            get { return 5; }
        }
        public override int Width
        {
            get { return 50; }
        }
        public override int Height
        {
            get { return 50; }
        }
    }
}