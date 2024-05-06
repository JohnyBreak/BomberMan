using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour, IExplodable
{
    private Player _player;

    private PlayerDeadText _deadText;

    [Inject]
    private void Construct(Player player, PlayerDeadText playerDeadText) 
    {
        _player = player;
        _deadText = playerDeadText;
    }

    public void Explode()
    {
        TakeDamage();
    }

    private void TakeDamage() 
    {
        _player.Kill();
        _deadText.Activate();
    }
}
