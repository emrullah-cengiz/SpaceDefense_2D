using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;

    public override void InstallBindings()
    {
        Container.Bind<InGameDataService>().AsSingle();
        Container.BindInstance<GameSettings>(_gameSettings).AsSingle();
    }
}