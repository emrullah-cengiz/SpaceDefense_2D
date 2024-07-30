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

        Container.BindFactory<IEffectDefinition, EffectHandler, IEffect, EffectFactory>().FromFactory<CustomEffectFactory>();


        Container.BindPoolGroup<Building, Building.Pool, Building.PoolGroup, BuildingType>("Prefabs/Buildings", _buildingsParent,
                                                                                     poolConfig => poolConfig.WithInitialSize(4)
                                                                                                             .ExpandByOneAtATime().NonLazy());

        //Bullets

        Container.BindPoolGroup<Bullet, Bullet.Pool, Bullet.PoolGroup, BulletType>("Prefabs/Bullets", poolsParent: null,
                                                                              poolConfig => poolConfig.WithInitialSize(4)
                                                                                                      .ExpandByDoubling().NonLazy());

    }


}