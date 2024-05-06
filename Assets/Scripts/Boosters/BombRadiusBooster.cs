using UnityEngine;
using Zenject;

public class BombRadiusBooster : MonoBehaviour, ICollectable, IExplodable
{
    private PlayerStats _stats;
    
    [Inject]
    private void Construct(PlayerStats stats) 
    {
        _stats = stats;
    }

    public void Collect()
    {
        _stats.IncreaseBombRadius(1);
        Destroy(this.gameObject);
    }

    public void Explode()
    {
        Destroy(this.gameObject);
    }
}
