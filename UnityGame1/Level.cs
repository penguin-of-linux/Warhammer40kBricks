using Extensibility;

namespace UnityGame
{
    public class Level
    {
        public readonly Map Map;
        public readonly GameState State;

        public Level(Map map, GameState state)
        {
            Map = map;
            State = state;
        }
    }
}