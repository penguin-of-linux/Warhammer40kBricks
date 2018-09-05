using System;
using System.Collections.Generic;
using System.Linq;
using Algorithms;
using Geometry;

namespace Extensibility
{
    public partial class Engine
    {
        /// <summary>
        /// Один юнит начинает производить другой
        /// </summary>
        public void ProduceUnit(Unit unit, string unitType)
        {
            if (unit == null)
                throw new ArgumentException(nameof(unit));

            if (!(unit is IProducingUnit producingUnit))
                throw new ArgumentException($"Unit with {unit.Id} is not IProducingUnit");

            if (!producingUnit.GetPossibleUnits().Contains(unitType))
                throw new ArgumentException($"Unit with {unit.Id} id can not create {unitType} unit");

            unit.UnitsToProduce.Enqueue(_unitCreator.CreateUnit(unitType));
        }

        /// <summary>
        /// Атака одним юнитом другого.
        /// </summary>
        public void SetUnitAttacking(GameState state, Unit unit, Unit target)
        {
            if (!(unit is ICombatUnit combat))
                throw new ArgumentException($"Unit with {unit.Id} is not ICombatUnit");

            if (GeometryMethods.GetDistance(unit.Position, target.Position) > combat.FireRadius)
            {
                if (!(unit is IMovableUnit))
                    return;

                SetUnitMovingTo(state, unit, target.Position);
            }
            else
                unit.MovingTargets.Clear();

            unit.EnemyId = target.Id;
        }

        /// <summary>
        /// Перемещение юнита в точку. Для перемещения нескольких юнитов лучше использовать соответствующий метод.
        /// </summary>
        public void SetUnitMovingTo(GameState state, Unit unit, Vector2 target)
        {

            if (!(unit is IMovableUnit))
                throw new ArgumentException($"Unit with {unit.Id} is not IMovableUnit");

            var path = AlgorithmsMethods.FindPathAmongRectangles(unit.Position, target, state.Map.Squares.ToArray());
            unit.MovingTargets.Clear();
            foreach (var v in path)
                unit.MovingTargets.Enqueue(v);

            if (unit is ICombatUnit combat)
                unit.EnemyId = null;
        }

        /// <summary>
        /// Перемещение выбранных юнитов в точку. Отпимизировано для нескольких юнитов.
        /// </summary>
        public void SetUnitsMovingTo(GameState state, IEnumerable<Unit> units, Vector2 target)
        {
            //todo: оптимизированный выбор целей
            foreach (var unit in units)
                SetUnitMovingTo(state, unit, target);
        }

        /// <summary>
        /// Устанавливает юниту угол относительно OX
        /// </summary>
        public void SetUnitRotation(Unit unit, double angle)
        {
            if (!(unit is IMovableUnit))
                throw new ArgumentException($"Unit with {unit.Id} is not IMovableUnit");

            if (unit.Rotation.Equal(angle, 0.01))
                return;

            unit.RotationTarget = angle;
        }
    }
}