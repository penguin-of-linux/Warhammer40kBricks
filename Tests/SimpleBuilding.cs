using Extensibility;

namespace Tests
{
    public class SimpleBuildingUnit : BuildingUnit
    {
        public SimpleBuildingUnit(int id) : base(id)
        {
        }

        public override string Name => "lalala";
        public override int MaxHeal => 100;
        public override int Width => 50;
        public override int Height => 50;
        public override int FramesToProduce => 100;
    }
}