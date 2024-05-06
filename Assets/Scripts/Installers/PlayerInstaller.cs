using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Player _player;

    public override void InstallBindings()
    {
        Container.Bind <PlayerStats>().FromMethod(GetPlayerStats).AsSingle();
        Container.Bind<Player>().FromInstance(_player).AsSingle();
        Container.Bind<PlayerScore>().FromNew().AsSingle();
    }

    private PlayerStats GetPlayerStats()
    {
        var stats = new PlayerStats(1, 3, 2f, 3.3f);
        return stats;
    }
}
