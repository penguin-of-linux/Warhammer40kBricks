namespace Extensibility
{
    public abstract class BuildingUnit : Unit,  IBuildingUnit
    {
        protected BuildingUnit(int id) : base(id)
        {
        }

        public abstract int Width { get; }
        public abstract int Height { get; }
    }
}