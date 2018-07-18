namespace Extensibility
{
    public struct Cell
    {
        public bool IsPassable;

        public Cell(bool isPassable = true)
        {
            IsPassable = isPassable;
        }
    }
}