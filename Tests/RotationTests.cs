using System;
using Geometry;
using NUnit.Framework;

namespace Tests
{
    public class RotationTests : TestBase
    {
        [Test]
        public void Simple()
        {
            var unit = new SimpleMovableUnit(0);
            State.AddUnit(unit, new Vector2(0, 0));

            Engine.SetUnitRotation(unit, Math.PI);

            FullUpdate();

            Assert.AreEqual(Math.PI, unit.Rotation, 0.01);
        }

        [Test]
        public void RotationForMoving_Simple()
        {
            var unit = new SimpleMovableUnit(0);
            var start = new Vector2(0, 0);
            var end = new Vector2(10, 5);
            State.AddUnit(unit, start);
            var expected = Math.Acos(10 / GeometryMethods.GetDistance(start, end));

            Engine.SetUnitMovingTo(State, unit, end);
            FullUpdate();

            Assert.AreEqual(expected, unit.Rotation, 0.01);
        }
    }
}