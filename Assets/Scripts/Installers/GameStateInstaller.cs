using Zenject;

public class GameStateInstaller : Installer
{
    public override void InstallBindings()
    {
        Container.Bind<GameStates>().FromNew().AsSingle();
        Container.Bind<GameStateController>().FromNew().AsSingle();
    }
}
