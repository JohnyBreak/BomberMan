using UnityEngine;
using Zenject;

public class RedBush : MonoBehaviour, IExplodable
{
    [SerializeField] private MonoBehaviour _collectable;

    private PlayerScore _score;
    private GameObjectFactory _factory;

    [Inject]
    private void Construct(PlayerScore score, GameObjectFactory factory)
    {
        _score = score;
        _factory = factory;
    }

    public void Explode()
    {
        _score.Increase(10);

        Destroy(gameObject);

        _factory.InstantiatePrefab(_collectable, transform.position, Quaternion.identity);
    }
}
