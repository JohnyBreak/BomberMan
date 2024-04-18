using UnityEngine;

public class PlayerHealth : MonoBehaviour, IExplodable
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerDeadText _deadText;

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
