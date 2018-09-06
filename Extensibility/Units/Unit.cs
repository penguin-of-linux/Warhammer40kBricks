using System.Collections.Generic;
using Geometry;

namespace Extensibility
{
    public abstract class Unit
    {
        public readonly int Id;

        public Vector2 Position { get; internal set; }
        public UnitState State { get; internal set; }
        public double Rotation { get; internal set; }

        public int Team { get;  set; }
        public int Heal { get; set; }

        public abstract string Name { get; }
        public abstract int MaxHeal { get; }
        public abstract int FramesToProduce { get; }

        public int? EnemyId { get; internal set; }

        internal Queue<Vector2> MovingTargets;
        internal Queue<Unit> UnitsToProduce;
        internal double? RotationTarget;
        internal int ProduceCounter = 0;

        protected Unit(int id)
        {
            Id = id;
            Heal = MaxHeal;

            //todo: лишнее выделение памяти в куче
            MovingTargets = new Queue<Vector2>();
            UnitsToProduce = new Queue<Unit>();
        }


    }
}