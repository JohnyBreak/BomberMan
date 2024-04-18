using UnityEngine;

public class DestructionTarget : MonoBehaviour, IExplodable
{
    [SerializeField] private LevelSystem _levelSystem;
    [SerializeField] private PlayerScore _score;

    public void Explode()
    {
        _score.Increase(30);
        _levelSystem.ReduceTargets();

        Destroy(gameObject);
    }
}
