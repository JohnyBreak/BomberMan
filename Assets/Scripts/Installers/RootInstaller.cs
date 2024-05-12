using Zenject;

public class RootInstaller : MonoInstaller
{
    private readonly System.Type[] _installersTypes = new System.Type[]
    {
        typeof(GameObjectFactoryInstaller),
        typeof(GameStateInstaller),
        typeof(LevelInstaller)
    };

    public override void InstallBindings()
    {
        foreach (var type in _installersTypes) 
        {
            var installer = (IInstaller)Container.Instantiate(type);
            installer.InstallBindings();
        }
    }
}