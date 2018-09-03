using System;
using System.IO;
using System.Reflection;
using Assets;
using UnityEngine;

using Extensibility;
using Geometry;
using UnityGame;

public class GameController : MonoBehaviour
{
    public IServiceProvider Container;

	void FixedUpdate ()
	{
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();

	    var state = Container.GetService<Level>().State;
	    var engine = Container.GetService<Engine>();

        if (DateTime.Now - _lastStateUpdate >= _updatePeriod)
	    {
	        engine.UpdateState(state);
	        _lastStateUpdate = DateTime.Now;
	    }

        engine.UpdateUnitsPositions(state);
	}

    private readonly TimeSpan _updatePeriod = TimeSpan.FromSeconds(1 / 20f);
    private DateTime _lastStateUpdate;
}
