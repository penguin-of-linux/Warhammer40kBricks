using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityGame;

namespace Warhammer40kBricks
{
    public class SpriteProvider : ISpriteProvider
    {
        private Dictionary<string, Sprite> _dict;

        public SpriteProvider()
        {
            _dict = BundleLoader.Bundle.LoadAllAssets<Texture2D>()
                .ToDictionary(x => x.name, x => Sprite.Create(x, new Rect(0, 0, x.width, x.height), Vector2.zero));
        }

        public Sprite GetSprite(string spriteName)
        {
            return _dict[spriteName];
        }
    }
}