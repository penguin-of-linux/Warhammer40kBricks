using System;
using Extensibility;
using Geometry;
using NUnit.Framework;

namespace Tests
{
    public class TestBase
    {
        protected Engine Engine;
        protected GameState State;
        protected TestUnitCreator UnitCreator;

        [SetUp]
        public void SetUp()
        {
            UnitCreator = new TestUnitCreator();
            Engine = new Engine(UnitCreator);
            State = new GameState(new Map(100, 100));
        }

        protected void FullUpdate(int cycles = 1000)
        {
            for (int i = 0; i < cycles; i++)
            {
                // тут частота одинаковая, в игре нет
                Engine.UpdateUnitsPositions(State);
                Engine.UpdateState(State);
            }
        }
    }
}