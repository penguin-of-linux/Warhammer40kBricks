using System;
using Extensibility;
using Warhammer40kBricks.Units;

namespace Warhammer40kBricks
{
    public class UnitCreator : IUnitCreator
    {
        private int _гыыыыыы = 0;

        public Unit CreateUnit(string unitName)
        {
            switch (unitName)
            {
                case "Scout":
                    return new Scout(_гыыыыыы++);

                case "Monastery":
                    return new Monastery(_гыыыыыы++);

                default:
                    throw new ArgumentException("Unknown unit type: + + unitType");
            }
        }
    }
}