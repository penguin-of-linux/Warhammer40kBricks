using System.Collections.Generic;
using Geometry;

namespace Extensibility
{
    public abstract class Unit
    {
        public readonly int Id;

        public int Heal { get; internal set; }
        public Vector2 Position { get; internal set; }
        public UnitState State { get; internal set; }
        public double Rotation { get; internal set; }

        public abstract int FramesToProduce { get; }

        public int? EnemyId { get; internal set; }

        internal Queue<Vector2> MovingTargets;
        internal Queue<Unit> UnitsToProduce;
        internal double? RotationTarget;
        internal int ProduceCounter = 0;

        protected Unit(int id)
        {
            Id = id;

            //todo: лишнее выделение памяти в куче
            MovingTargets = new Queue<Vector2>();
            UnitsToProduce = new Queue<Unit>();
        }


    }
}