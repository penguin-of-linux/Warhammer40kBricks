using System;
using UnityEngine;

using Extensibility;
using Geometry;

public class GameController : MonoBehaviour
{
    private readonly TimeSpan _updatePeriod = TimeSpan.FromSeconds(1 / 20f);

    public static Engine Engine;
    public  static GameState GameState;
    private DateTime _lastStateUpdate;


	// Use this for initialization
	void Awake ()
	{
        var map = new Map(100, 100);
	    GameState = new GameState(map);

        for(int i = 0; i < 1; i++)
	        GameState.AddUnit(new Scout(i), new Geometry.Vector2(1, 1 * i), 100);

        GameState.AddUnit(new Monastery(1), new Geometry.Vector2(25, 25), 100);

        Engine = new Engine();
	    _lastStateUpdate = DateTime.Now;

        // Other scripts enabling
	    GameObject.Find("GraphicsController").GetComponent<GraphicsController>().enabled = true;
	    GameObject.Find("PlayerController").GetComponent<PlayerController>().enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //Debug.Log(1 / Time.deltaTime);

        if (DateTime.Now - _lastStateUpdate >= _updatePeriod)
	    {
	        Engine.UpdateState(GameState);
	        _lastStateUpdate = DateTime.Now;
	    }

        Engine.UpdateUnitsPositions(GameState);
	}
}
