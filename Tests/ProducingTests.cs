using System.Linq;
using Geometry;
using NUnit.Framework;

namespace Tests
{
    public class ProducingTests : TestBase
    {
        [Test]
        public void Simple()
        {
            var producing = UnitCreator.CreateUnit("simple producing unit");
            State.AddUnit(producing, new Vector2(0, 0), 100);

            Engine.ProduceUnit(producing, "simple combat unit");
            FullUpdate();

            var expected = State.Units.FirstOrDefault(u => u.GetType() == typeof(SimpleCombatUnit));
            Assert.NotNull(expected);
            Assert.AreEqual(expected.Id, 1); // но это необязательно
            Assert.AreEqual(expected.Position, new Vector2(1, 1));
        }
    }
}