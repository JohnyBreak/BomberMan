using UnityEngine;
using Zenject;

public class TransitionScreenInstaller : MonoInstaller
{
    [SerializeField] private TransitionScreen _screen;

    public override void InstallBindings()
    {
        var screen = Container.InstantiatePrefabForComponent<TransitionScreen>(_screen);
        Container.Bind<TransitionScreen>().FromInstance(screen).AsSingle();
        DontDestroyOnLoad(screen.gameObject);
    }
}
