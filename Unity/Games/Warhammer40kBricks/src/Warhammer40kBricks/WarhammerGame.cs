using Extensibility;
using UnityGame;
using Warhammer40kBricks.Units;

namespace Warhammer40kBricks
{
    public class WarhammerGame : IUnityGame
    {
        public string Name
        {
            get { return nameof(WarhammerGame); }
        }

        public Level CurrentLevel
        {
            get { return _level ?? (_level = CreateLevel()); }
        }

        public IObjectProvider ObjectProvider
        {
            get { return _objectProvider ?? (_objectProvider = new ObjectProvider()); }
        }

        public IUnitCreator UnitCreator
        {
            get { return new UnitCreator(); }
        }

        public ISpriteProvider SpriteProvider
        {
            get { return new SpriteProvider(); }
        }

        private Level CreateLevel()
        {
            var map = new Map(100, 100);
            var gameState = new GameState(map);

            for (int i = 0; i < 1; i++)
                gameState.AddUnit(new Scout(i), new Geometry.Vector2(1, 1 * i), 100);

            gameState.AddUnit(new Monastery(1), new Geometry.Vector2(25, 25), 100);

            return new Level(map, gameState);
        }

        private Level _level;
        private IObjectProvider _objectProvider;
    }
}