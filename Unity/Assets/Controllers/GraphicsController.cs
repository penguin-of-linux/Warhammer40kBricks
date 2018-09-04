using System;
using System.Collections.Generic;
using Assets;
using Extensibility;
using Geometry;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using UnityGame;
using Vector3 = UnityEngine.Vector3;

public class GraphicsController : MonoBehaviour
{
    public IServiceProvider Container;

    void Start()
    {
        BuidPanelButtons();
        DrawMap(Container.GetService<Level>().State.Map);
    }

    void Update()
    {
        var state = Container.GetService<Level>().State;

        foreach (var unit in state.Units)
        {
            if (!_objects.ContainsKey(unit.Id))
                _objects[unit.Id] = CreateGameObject(unit);

            var obj = _objects[unit.Id];

            if (unit is IBuildingUnit)
            {
                var building = unit as IBuildingUnit;
                obj.transform.position = (unit.Position + new Geometry.Vector2(building.Width, building.Height) * 0.5)
                    .ToUnityVector3();
            }
            else
            {
                obj.transform.position = (unit.Position).ToUnityVector3();
            }

            var angle = (float) (unit.Rotation * 180 / Math.PI);
            obj.transform.rotation = Quaternion.Euler(0, -angle, 0);

            var anim = obj.GetComponentInChildren<Animation>();
            if (anim == null)
                continue;

            var animationName = unit.State.ToString().ToLower();

            if (!anim.IsPlaying(animationName))
                anim.Play(animationName);
        }
    }

    private GameObject CreateGameObject(Unit unit)
    {
        var result = Container.GetService<IObjectProvider>().CreateGameObject(unit);
        var controller = result.AddComponent<PlayerController>();
        controller.Container = Container;

        return result;
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
        plane.AddComponent<PlayerController>().Container = Container;
    }

    private void BuidPanelButtons()
    {
        var panel = GameObject.Find("ControlPanel");
    }

    private readonly Dictionary<int, GameObject> _objects = new Dictionary<int, GameObject>();
}