using Zenject;
using UnityEngine;

public class UiInstaller : MonoInstaller
{
    [SerializeField] private PlayerScoreView _playerScoreView;
    [SerializeField] private PlayerDeadText _playerDeadText;

    public override void InstallBindings()
    {
        Container.Bind<PlayerScoreView>().FromInstance(_playerScoreView).AsSingle().NonLazy();
        Container.Bind<PlayerDeadText>().FromInstance(_playerDeadText).AsSingle().NonLazy();
    }
}