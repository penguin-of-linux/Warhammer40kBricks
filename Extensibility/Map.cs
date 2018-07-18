using System.Collections.Generic;
using Geometry;

namespace Extensibility
{
    public class Map
    {
        public readonly int Height;
        public readonly int Width;

        internal HashSet<SimplifiedRectangle> Squares;

        public Map(int width, int height)
        {
            Height = height;
            Width = width;
            Squares = new HashSet<SimplifiedRectangle>();
        }

        public bool PointInMap(Vector2 point)
        {
            return point.X >= 0 && point.X < Width && point.Y >= 0 && point.Y < Height;
        }
    }
}