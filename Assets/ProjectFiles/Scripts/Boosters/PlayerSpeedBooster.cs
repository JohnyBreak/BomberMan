using UnityEngine;
using Zenject;

public class PlayerSpeedBooster : MonoBehaviour, ICollectable, IExplodable
{
    private PlayerStats _stats;

    [Inject]
    private void Construct(PlayerStats stats)
    {
        _stats = stats;
    }

    public void Collect()
    {
        _stats.IncreasePlayerSpeed(0.3f);
        Destroy(this.gameObject);
    }
    public void Explode()
    {
        Destroy(this.gameObject);
    }
}
