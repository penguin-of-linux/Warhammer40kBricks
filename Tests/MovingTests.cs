using Extensibility;
using Geometry;
using NUnit.Framework;

namespace Tests
{
    public class MovingTests : TestBase
    {

        [Test]
        public void Simple()
        {
            var unit = new SimpleMovableUnit(0);
            State.AddUnit(unit, new Vector2(0, 0), 100);
            var start = new Vector2(0, 0);
            var finish = new Vector2(100, 100);

            Engine.SetUnitMovingTo(State, unit, finish);
            var количествоЦиклов = 200; //(int) (GeometryMethods.GetDistance(start, finish) / unit.Speed) + 1;
            FullUpdate(количествоЦиклов);

            Assert.AreEqual(finish, State.GetUnit(0).Position);
        }

        [Test]
        public void OneBarrier()
        {
            var unit = new SimpleMovableUnit(0);
            var building = new SimpleBuildingUnit(1);
            var start = new Vector2(0, 0);
            State.AddUnit(unit, start, 100);
            State.AddUnit(building, new Vector2(25, 25), 100);
            var finish = new Vector2(100, 100);

            Engine.SetUnitMovingTo(State, unit, finish);
            var количествоЦиклов = (int)(GeometryMethods.GetDistance(start, finish) / unit.Speed) + 1;
            FullUpdate(количествоЦиклов);

            Assert.AreNotEqual(finish, State.GetUnit(0).Position);
        }
    }
}