using UnityEngine;

namespace UnityGame
{
    public interface ISpriteProvider
    {
        Sprite GetSprite(string spriteName);
    }
}