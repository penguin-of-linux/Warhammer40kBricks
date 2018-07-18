using Extensibility;

namespace Tests
{
    public class TestUnitCreator : IUnitCreator
    {
        private int _idCounter = 0;
        public Unit CreateUnit(string unitName)
        {
            var id = _idCounter++;

            switch (unitName)
            {
                case "simple producing unit":
                    return new SimpleProducingUnit(id);
                case "simple building unit":
                    return new SimpleBuildingUnit(id);
                case "simple combat unit":
                    return new SimpleCombatUnit(id);
            }

            return null;
        }
    }
}