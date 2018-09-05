using Extensibility;
using UnityGame;
using Warhammer40kBricks.Units;

namespace Warhammer40kBricks
{
    public class WarhammerGame : IUnityGame
    {
        public string Name => nameof(WarhammerGame);
        public Level CurrentLevel => _level ?? (_level = CreateLevel());
        public IObjectProvider ObjectProvider => _objectProvider ?? (_objectProvider = new ObjectProvider());
        public IUnitCreator UnitCreator => _unitCreator ?? (_unitCreator = new UnitCreator());
        public ISpriteProvider SpriteProvider => _spriteProvider ?? (_spriteProvider = new SpriteProvider());

        private Level CreateLevel()
        {
            var map = new Map(100, 100);
            var gameState = new GameState(map);

            for (int i = 0; i < 1; i++)
                gameState.AddUnit(UnitCreator.CreateUnit("Scout"), new Geometry.Vector2(1, 1 * i), 100);

            gameState.AddUnit(UnitCreator.CreateUnit("Monastery"), new Geometry.Vector2(25, 25), 100);

            return new Level(map, gameState);
        }

        private Level _level;
        private IObjectProvider _objectProvider;
        private IUnitCreator _unitCreator;
        private ISpriteProvider _spriteProvider;
    }
}