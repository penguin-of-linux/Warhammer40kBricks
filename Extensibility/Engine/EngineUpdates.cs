using System;
using System.Collections.Generic;
using System.Linq;

using Algorithms;
using Geometry;

namespace Extensibility
{
    public partial class Engine
    {
        public void UpdateState(GameState state)
        {
            var len = state.Units.Count;
            for(var i = 0; i < len; i++)
            {
                var unit = state.Units[i];

                if (unit is ICombatUnit combat)
                {
                    if (unit.Heal <= 0)
                        continue;
                    UpdateCombatUnit(state, combat);
                }

                if (unit is IProducingUnit producing)
                {
                    UpdateProducingUnit(state, unit, producing);
                }
            }

            DeleteZeroHealUnits(state);
        }

        private void UpdateProducingUnit(GameState state, Unit unit, IProducingUnit producing)
        {
            if (unit.UnitsToProduce.Count > 0)
            {
                var unitToProduce = unit.UnitsToProduce.Peek();

                if (unit.ProduceCounter >= unitToProduce.FramesToProduce)
                {
                    state.AddUnit(unit.UnitsToProduce.Dequeue(), producing.GetOutputLocation(), 100);
                    unit.ProduceCounter = 0;
                }
                else
                    unit.ProduceCounter++;
            }
        }

        public void UpdateUnitsPositions(GameState state)
        {
            foreach (var unit in state.Units)
            {
                if (unit is IMovableUnit movable)
                {
                    if (unit.Heal <= 0)
                        continue;
                    UpdateMovableUnit(state, movable);
                }
            }
        }

        private void DeleteZeroHealUnits(GameState state)
        {
            var units = state.Units.Where(e => e.Heal <= 0).ToArray();
            foreach (var unit in units)
            {
                state.DeleteUnit(unit);
            }
        }

        private void UpdateCombatUnit(GameState state, ICombatUnit combat)
        {
            var unit = (Unit) combat;

            if (!unit.EnemyId.HasValue) return;

            var enemyId = unit.EnemyId.Value;
            var enemy = state.GetUnit(enemyId);
            if (GeometryMethods.GetDistance(unit.Position, enemy.Position) > combat.FireRadius)
            {
                return;
            }

            unit.State = UnitState.Attacking;
            unit.MovingTargets.Clear();
            enemy.Heal -= combat.Damage;

            if (enemy.Heal <= 0)
            {
                //GameState.DeleteUnit(enemy.Id); - collection modified exception
                unit.EnemyId = null;
                unit.State = UnitState.Idle;
            }
        }

        private void UpdateMovableUnit(GameState state, IMovableUnit movable)
        {
            var unit = (Unit)movable;

            UpdateUnitPosition(unit, movable.Speed);
            UpdateUnitRotation(unit, movable.RotationSpeed);
        }

        private void UpdateUnitPosition(Unit unit, double speed)
        {
            if (unit.MovingTargets.Count == 0)
            {
                unit.State = UnitState.Idle;
                return;
            }

            var target = unit.MovingTargets.Peek();

            // угол между осью OX и вектором движения
            var angle = GeometryMethods.GetAngleBetweenVectorCww(new Vector2(1, 0), target - unit.Position);

            if (!unit.RotationTarget.HasValue && !unit.Rotation.Equal(angle))
                SetUnitRotation(unit, angle);

            if (unit.RotationTarget.HasValue)
            {
                // юнит поворачивается, не надо ему мешать
                return;
            }

            unit.State = UnitState.Moving;

            var dist = GeometryMethods.GetDistance(unit.Position, target);
            if (dist <= speed)
            {
                unit.Position = target;
                unit.MovingTargets.Dequeue();
            }
            else
            {
                var vector = (target - unit.Position).GetNormalized();
                unit.Position += vector * speed;
            }
        }

        private void UpdateUnitRotation(Unit unit, double rotationSpeed)
        {
            if (unit.RotationTarget.HasValue)
            {
                var diff = GeometryMethods.GetAnglesDifference(unit.Rotation, unit.RotationTarget.Value);

                if (Math.Abs(diff).LessOrEqual(rotationSpeed))
                {
                    unit.Rotation = unit.RotationTarget.Value;
                    unit.RotationTarget = null;
                }
                else
                {
                    unit.Rotation += rotationSpeed * Math.Sign(diff);
                }
            }
        }       
    }
}