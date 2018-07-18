using System.Collections.Generic;

using UnityEngine;

using Extensibility;

public class PlayerController : MonoBehaviour
{
    public List<Unit> SelectedUnits;

    void Start()
    {
        SelectedUnits = new List<Unit>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Debug.Log(hit.transform.name);
                int id;
                if (int.TryParse(hit.transform.name, out id))
                {
                    SelectedUnits.Clear();
                    SelectedUnits.Add(GameController.GameState.GetUnit(id));
                    return;
                }

                if (hit.transform.name == "ground" && SelectedUnits.Count > 0)
                    GameController.Engine.SetUnitsMovingTo(
                        GameController.GameState, SelectedUnits, hit.point.ToGeometryVector2());
            }
        }
    }
}