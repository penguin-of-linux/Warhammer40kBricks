using Geometry;

namespace Extensibility
{
    public interface IProducingUnit
    {
        Vector2 GetOutputLocation();
        string[] GetPossibleUnits();
    }
}