using System.Collections.Generic;
using UnityEngine;

using Extensibility;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerClickHandler
{
    public static List<Unit> SelectedUnits = new List<Unit>();

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.pointerPress.transform.name)
        {
            case "Panel":
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
        SelectedUnits.Clear();
        SelectedUnits.Add(GameController.GameState.GetUnit(id));
    }

    private void OnGroundPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ground click");

        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);

        GameController.Engine.SetUnitsMovingTo(
            GameController.GameState, 
            SelectedUnits, 
            hit.point.ToGeometryVector2());
    }

    private void OnPanelPointerClick(PointerEventData eventData)
    {
        Debug.Log("Panel click");
    }
}