using UnityEngine;
using Zenject;

public class TransitionScreenInstaller : MonoInstaller
{
    [SerializeField] private Transition _screen;

    public override void InstallBindings()
    {
        var screen = Container.InstantiatePrefabForComponent<Transition>(_screen);
        Container.Bind<Transition>().FromInstance(screen).AsSingle();
        screen.SetValue(0);
        DontDestroyOnLoad(screen.gameObject);
    }
}
