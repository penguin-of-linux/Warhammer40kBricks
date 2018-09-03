using Extensibility;
using UnityEngine;

namespace UnityGame
{
    public interface IObjectProvider
    {
        GameObject CreateGameObject(Unit unit);
    }
}