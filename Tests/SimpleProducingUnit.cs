using Extensibility;
using Geometry;

namespace Tests
{
    public class SimpleProducingUnit : Unit, IProducingUnit
    {
        public SimpleProducingUnit(int id) : base(id)
        {
        }

        public Vector2 GetOutputLocation()
        {
            return new Vector2(1, 1);
        }

        public string[] GetPossibleUnits()
        {
            return new [] { "simple combat unit" };
        }

        public override int FramesToProduce => 100;
    }
}