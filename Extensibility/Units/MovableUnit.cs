namespace Extensibility
{
    public abstract class MovableUnit : Unit, IMovableUnit
    {
        protected MovableUnit(int id) : base(id)
        {
        }

        public abstract double Speed { get; }
        public abstract double RotationSpeed { get; }
    }
}