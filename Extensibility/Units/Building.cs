namespace Extensibility
{
    public abstract class BuildingUnit : Unit,  IBuildingUnit
    {
        public BuildingUnit(int id) : base(id)
        {
        }

        public abstract int Width { get; }
        public abstract int Height { get; }
    }
}