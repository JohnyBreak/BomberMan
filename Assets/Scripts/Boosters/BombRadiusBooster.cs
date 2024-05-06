using UnityEngine;
using Zenject;

public class BombRadiusBooster : MonoBehaviour, ICollectable
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
        Debug.LogError("Collect");
        Destroy(this.gameObject);
    }
}
