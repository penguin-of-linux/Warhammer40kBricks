using System;
using System.Collections.Generic;
using System.Linq;
using Assets;
using Extensibility;
using UnityEngine;
using UnityEngine.UI;
using UnityGame;
using Vector3 = UnityEngine.Vector3;

public class GraphicsController : MonoBehaviour
{
    public IServiceProvider Container;

    void Start()
    {
        BuidPanel();
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

    public void UpdateControlPanel(Unit selectedUnit)
    {
        var producingUnit = selectedUnit as IProducingUnit;
        var usedButtons = 0;

        if (producingUnit != null)
        {
            var possibleUnits = producingUnit.GetPossibleUnits();
            usedButtons = Math.Min(possibleUnits.Length, _buttons.Length);

            for (var i = 0; i < usedButtons; i++)
            {
                var text = _buttons[i].GetComponentInChildren<Text>();
                text.text = possibleUnits[i];
            }
        }

        for (var i = usedButtons; i < _buttons.Length; i++)
        {
            var text = _buttons[i].GetComponentInChildren<Text>();
            text.text = "NONE";
        }
    }

    private void BuidPanel()
    {
        var image = GameObject.Find("ControlPanelImage");
        var imageComponent = image.GetComponent<Image>();
        var spriteProvider = Container.GetService<ISpriteProvider>();
        imageComponent.sprite = spriteProvider.GetSprite("ControlPanelBackground");

        _buttons = Enumerable.Range(1, 2)
            .Select(x => GameObject.Find("ControlPanelButton" + x).GetComponent<Button>())
            .ToArray();
        UpdateControlPanel(null);
    }

    private readonly Dictionary<int, GameObject> _objects = new Dictionary<int, GameObject>();
    private Button[] _buttons;
}