using System;
using System.Collections.Generic;
using Extensibility;
using Geometry;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class GraphicsController : MonoBehaviour
{
    private GameObject _legomanPrefab;
    private GameObject _monasteryPrefab;

    private Dictionary<int, GameObject> _objects;

    void Start()
    {
        _objects = new Dictionary<int, GameObject>();

        DrawMap(GameController.GameState.Map);

        _legomanPrefab = Resources.Load<GameObject>("LegoMan");
        _monasteryPrefab = Resources.Load<GameObject>("Monastery");
    }

    void Update()
    {
        foreach (var unit in GameController.GameState.Units)
        {
            if (!_objects.ContainsKey(unit.Id))
                _objects[unit.Id] = CreateGameObject(unit);

            var obj = _objects[unit.Id];

            if (unit is IBuilding)
            {
                var building = unit as IBuilding;
                obj.transform.position = (unit.Position + new Geometry.Vector2(building.Width, building.Height) * 0.5)
                    .ToUnityVector3();
            }
            else
            {
                obj.transform.position = (unit.Position).ToUnityVector3();
            }

            var angle = (float) (unit.Rotation * 180 / Math.PI);
            obj.transform.rotation = Quaternion.Euler(0, -angle, 0);

            if (unit is Monastery)
                continue;

            var anim = obj.GetComponentInChildren<Animation>();

            var animationName = unit.State.ToString().ToLower();

            if (!anim.IsPlaying(animationName))
                anim.Play(animationName);
        }
    }

    public void DrawMap(Map map)
    {
        var plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        var w = map.Width / 10f;
        var h = map.Height / 10f;
        plane.transform.localScale = new Vector3(w, 1, h);
        plane.transform.position = new Vector3(w / 2 * 10, 0, h / 2 * 10);
        plane.name = "ground";
        plane.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private GameObject CreateGameObject(Unit unit)
    {
        GameObject result = null;

        if (unit is Scout)
            result = GameObject.Instantiate(_legomanPrefab);

        if (unit is Building)
        {
            result = GameObject.Instantiate(_monasteryPrefab);
            var building = unit as Building;
        }

        if (result == null)
            throw new NotSupportedException(string.Format("Unit type {0} not supported", unit.GetType()));

        result.name = unit.Id.ToString();

        return result;
    }
}