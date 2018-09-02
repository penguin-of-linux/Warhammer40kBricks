using System;
using Geometry;

namespace Extensibility
{
    public partial class Engine
    {
        private readonly IUnitCreator _unitCreator;

        public Engine(IUnitCreator unitCreator)
        {
            _unitCreator = unitCreator;
        }
    }
}