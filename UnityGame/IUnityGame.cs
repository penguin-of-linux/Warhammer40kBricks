using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Extensibility;

namespace UnityGame
{
    public interface IUnityGame
    {
        string Name { get; }
        Level CurrentLevel { get; }
        IObjectProvider ObjectProvider { get; }
        IUnitCreator UnitCreator { get; }
        ISpriteProvider SpriteProvider { get; }
    }
}
