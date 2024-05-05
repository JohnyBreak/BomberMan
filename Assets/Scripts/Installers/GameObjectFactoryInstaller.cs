using Zenject;

public class GameObjectFactoryInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<GameObjectFactory>().FromNew().AsSingle();
    }
}
