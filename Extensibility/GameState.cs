using System;
using System.Collections.Generic;
using System.Linq;
using Geometry;

namespace Extensibility
{
    public class GameState
    {
        public Map Map;
        public List<Unit> Units;

        public GameState(Map map, params Unit[] units)
        {
            Units = units.ToList();
            Map = map;
        }

        public Unit GetUnit(int id)
        {
            var result = Units.FirstOrDefault(u => u.Id == id);

            if (result == null)
                throw new ArgumentException($"Unit with id = {id} not exist!");

            return result;
        }

        public void DeleteUnit(int id)
        {
            var unit = GetUnit(id);
            DeleteUnit(unit);
        }

        public void DeleteUnit(Unit unit)
        {
            Units.Remove(unit);
            if (unit is IBuildingUnit building)
                Map.Squares.Remove(new SimplifiedRectangle(unit.Position,
                    unit.Position + new Vector2(building.Width, building.Height)));
        }

        public void AddUnit(Unit unit, Vector2 position, int heal)
        {
            Units.Add(unit);
            unit.Position = position;
            unit.Heal = heal;
            unit.State = UnitState.Idle;
            unit.EnemyId = null;
            unit.MovingTargets = new Queue<Vector2>();
            unit.Rotation = 0;
            unit.RotationTarget = null;

            if (unit is IBuildingUnit building)
                Map.Squares.Add(new SimplifiedRectangle(unit.Position,
                    unit.Position + new Vector2(building.Width, building.Height)));
        }
    }
}