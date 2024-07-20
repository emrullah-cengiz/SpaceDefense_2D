using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;

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

        
        Container.BindMemoryPool<Building, Building.Pool>()
                 .WithInitialSize(5)
                 .ExpandByOneAtATime()
                 .FromComponentInNewPrefabResource($"Prefabs/{nameof(Building)}")
                 .UnderTransformGroup($"{nameof(Building)}s");

        //Factory like Pool binding
        //Container.BindFactory<BuildingData, Vector3, Building, Building.Pool>()
        //         .FromMonoPoolableMemoryPool(x => x
        //             .WithInitialSize(5)
        //             .ExpandByOneAtATime()
        //             .FromComponentInNewPrefabResource($"Prefabs/{nameof(Building)}")
        //             .UnderTransformGroup($"{nameof(Building)}s"));

    }
}