using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Assets;
using Assets.Container;
using Extensibility;
using UnityEngine;
using UnityGame;

public class EntryPoint : MonoBehaviour
{
    void Awake()
    {

        var container = CreateContainer();

        var game = container.GetService<IUnityGame>();
        Debug.Log(string.Format("Game {0} loaded!", game.Name));

        
        ConfigureGraphicsController(container);
        ConfigureGameController(container);
    }

    private void ConfigureGraphicsController(IServiceProvider container)
    {
        var controller = container.GetService<GraphicsController>();
        controller.Container = container;
        controller.enabled = true;
    }

    private void ConfigureGameController(IServiceProvider container)
    {
        var controller = container.GetService<GameController>();
        controller.Container = container;
    }

    private IServiceProvider CreateContainer()
    {
        var container = new Container();
        var gameProvider = new GameProvider();
        var game = gameProvider.GetGame(Path.Combine("Games", "Warhammer40kBricks"));
        var level = game.CurrentLevel;
        var unitCreator = game.UnitCreator;
        var objectProvider = game.ObjectProvider;
        var spriteProvider = game.SpriteProvider;
        var graphicsController = GameObject.Find("GraphicsController").GetComponent<GraphicsController>();
        var gameController = GameObject.Find("GameController").GetComponent<GameController>();

        container.RegisterSingleton<Engine>();
        container.RegisterSingleton(gameProvider);
        container.RegisterSingleton<IUnityGame>(game);
        container.RegisterSingleton<Level>(level);
        container.RegisterSingleton<IUnitCreator>(unitCreator);
        container.RegisterSingleton<IObjectProvider>(objectProvider);
        container.RegisterSingleton<ISpriteProvider>(spriteProvider);
        container.RegisterSingleton<GameController>(gameController);
        container.RegisterSingleton<GraphicsController>(graphicsController);

        return container;
    }
}
