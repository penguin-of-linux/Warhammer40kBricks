using System;
using Geometry;
using NUnit.Framework;

namespace Tests
{
    public class AttackTests : TestBase
    {
        [Test]
        public void Simple()
        {
            var attacker = new SimpleCombatUnit(0);
            var victim = new SimpleBuildingUnit(1);
            State.AddUnit(attacker,  new Vector2(0, 0));
            State.AddUnit(victim, new Vector2(0.5, 0.5) * attacker.FireRadius);

            Engine.SetUnitAttacking(State, attacker, victim);

            FullUpdate();

            Assert.False(State.Units.Contains(victim));
        }

        [Test]
        public void UnitCannotMove_NothingChaged()
        {
            var attacker = new SimpleCombatUnit(0);
            var victim = new SimpleBuildingUnit(1);
            var attackerStartPos = new Vector2(0, 0);
            var buildingPos = new Vector2(2, 2) * attacker.FireRadius;
            State.AddUnit(attacker, attackerStartPos);
            State.AddUnit(victim, buildingPos);

            Engine.SetUnitAttacking(State, attacker, victim);

            Assert.AreEqual(attackerStartPos, attacker.Position);
            Assert.Contains(victim, State.Units);
        }

        [Test]
        public void UnitGoToTarget()
        {
            var attacker = new SimpleCombatMovableUnit(0);
            var victim = new SimpleBuildingUnit(1);
            var attackerStartPos = new Vector2(0, 0);
            var buildingPos = new Vector2(2, 2) * attacker.FireRadius;
            State.AddUnit(attacker, attackerStartPos);
            State.AddUnit(victim, buildingPos);

            Engine.SetUnitAttacking(State, attacker, victim);
            FullUpdate();

            Assert.False(State.Units.Contains(victim));
            Assert.AreNotEqual(attackerStartPos, attacker.Position);
            Assert.AreNotEqual(buildingPos, attacker.Position);
        }
    }
}