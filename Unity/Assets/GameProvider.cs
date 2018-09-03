using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityGame;

namespace Assets
{
    public class GameProvider
    {
        public IUnityGame GetGame(string pathToGameFolder)
        {
            return _game ?? (_game = LoadGame(pathToGameFolder));
        }

        private IUnityGame LoadGame(string pathToGameFolder)
        {
            var types = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), pathToGameFolder))
                .Select(Assembly.LoadFrom)
                .SelectMany(x => x.GetTypes())
                .Where(x => x.GetInterfaces().Contains(typeof(IUnityGame)))
                .ToArray();

            if (types.Length != 1)
                throw new Exception("Zero or more than 1 type implements IUnityGame");
            
            return Activator.CreateInstance(types[0]) as IUnityGame;
        }

        private IUnityGame _game;
    }
}