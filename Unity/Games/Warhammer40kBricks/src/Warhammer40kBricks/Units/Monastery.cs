using Extensibility;
using Geometry;

namespace Warhammer40kBricks.Units
{
    public class Monastery : BuildingUnit, IProducingUnit
    {
        public Monastery(int id) : base(id)
        {
        }

        public override string Name => "Monastery";
        public override int MaxHeal => 100;
        public override int FramesToProduce => 5;
        public override int Width => 50;
        public override int Height => 50;

        public Vector2 GetOutputLocation() => new Vector2(0, 0);
        public string[] GetPossibleUnits() => new[] { "Scout" };
    }
}