using System;
using Extensibility;
using UnityEditor;
using UnityEngine;
using UnityGame;
using Warhammer40kBricks.Units;

namespace Warhammer40kBricks
{
    public class ObjectProvider : IObjectProvider
    {
        public ObjectProvider()
        {
            _legomanPrefab = BundleLoader.Bundle.LoadAsset<GameObject>("LegoMan");
            _monasteryPrefab = BundleLoader.Bundle.LoadAsset<GameObject>("Monastery");
            //myGameObject = (GameObject)Instantiate((GameObject)AssetDatabase.LoadAssetAtPath(
            //"Assets/your/nonResources/path/fileName.prefab",typeof(GameObject)), currentPosition, currentRotation);
        }

        public GameObject CreateGameObject(Unit unit)
        {
            GameObject result = null;

            if (unit is Scout)
                result = GameObject.Instantiate(_legomanPrefab);

            if (unit is IBuildingUnit)
            {
                result = GameObject.Instantiate(_monasteryPrefab);
                var building = unit as IBuildingUnit;
            }

            if (result == null)
                throw new NotSupportedException(string.Format("Unit type {0} not supported", unit.GetType()));

            result.name = unit.Id.ToString();

            return result;
        }

        private GameObject _legomanPrefab;
        private GameObject _monasteryPrefab;
    }
}