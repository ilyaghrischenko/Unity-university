using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private HealthView _healthView;

    public override void InstallBindings()
    {
        Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
    }
}