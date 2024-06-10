using UnityEngine;
using Zenject;

public class DestructionTarget : MonoBehaviour, IExplodable
{
    private LevelSystem _levelSystem;
    private PlayerScore _score;

    [Inject]
    private void Construct(LevelSystem levelSystem, PlayerScore score) 
    {
        _levelSystem = levelSystem;
        _score = score;
        _levelSystem.RegisterDestructable(this);
    }

    public void Explode()
    {
        _score.Increase(30);
        _levelSystem.ReduceTargets();

        Destroy(gameObject);
    }
}
