using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private Transform _buildingsParent;

    public override void InstallBindings()
    {
        //Settings
        Container.BindInstance<GameSettings>(_gameSettings).AsSingle();

        //Services
        Container.Bind<InGameDataService>().AsSingle();

        ////Actors - Factories / Pools

        //Buildings
        Container.Bind<BuildingManager>()
                 .FromComponentInHierarchy()
                 .AsSingle();


        Container.BindPoolGroup<Building, Building.Pool, Building.PoolGroup>("Prefabs/Buildings", _buildingsParent,
                                                                            poolConfig => poolConfig.WithInitialSize(4)
                                                                                                    .ExpandByOneAtATime());
    }


}