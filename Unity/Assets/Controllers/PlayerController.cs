using System;
using System.Collections.Generic;
using Assets;
using Assets.Container;
using Extensibility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityGame;

public class PlayerController : MonoBehaviour, IPointerClickHandler
{
    public static List<Unit> SelectedUnits = new List<Unit>();
    public IServiceProvider Container;

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.pointerPress.transform.name)
        {
            case "ControlPanel":
                OnPanelPointerClick(eventData);
                break;

            case "ground":
                OnGroundPointerClick(eventData);
                break;

            default:
                OnUnitPointerClick(eventData);
                break;
        }
    }

    private void OnUnitPointerClick(PointerEventData eventData)
    {
        Debug.Log("Unit click");

        var id = int.Parse(eventData.pointerPress.transform.name);
        var unit = Container.GetService<Level>().State.GetUnit(id);
        SelectedUnits.Clear();
        SelectedUnits.Add(unit);
        Container.GetService<GraphicsController>().UpdateControlPanel(unit);
    }

    private void OnGroundPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ground click");

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

        var engine = Container.GetService<Engine>();
        var state = Container.GetService<Level>().State;
        engine.SetUnitsMovingTo(state, SelectedUnits, hit.point.ToGeometryVector2());
    }

    private void OnPanelPointerClick(PointerEventData eventData)
    {
        Debug.Log("Panel click");
    }
}