using Extensibility;
using Warhammer40kBricks.Units;

namespace Warhammer40kBricks
{
    public class UnitCreator : IUnitCreator
    {
        private int _гыыыыыы = 0;

        public Unit CreateUnit(string unitName)
        {
            return new Scout(_гыыыыыы++);
        }
    }
}