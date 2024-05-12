using System.Collections;
using UnityEngine;
using Zenject;

public class Barrel : MonoBehaviour, IExplodable
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private float _damageRadius = .8f;
    [SerializeField] private Explode _explode;
    //[SerializeField] private int _radius = 2;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _explodableMask;

    private Coroutine _waitRoutine;
    private GameObjectFactory _factory;
    private PlayerStats _stats;

    [Inject]
    private void Construct(GameObjectFactory factory, PlayerStats stats)
    {
        _factory = factory;
        _stats = stats;
    }

    private void OnEnable()
    {
        _waitRoutine = StartCoroutine(WaitRoutine());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Player>(out var player))
        {
            _boxCollider.isTrigger = false;
        }
    }

    private IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        Explode();
    }

    public void Explode() 
    {
        if (_waitRoutine != null) 
        {
            StopCoroutine(_waitRoutine);
            _waitRoutine = null;
        }

        Destroy(gameObject);
        

        spawnExplode(Vector3.up);
        spawnExplode(Vector3.right);
        spawnExplode(Vector3.down);
        spawnExplode(Vector3.left);
        
        CreateExplode(transform.position);
    }

    private void spawnExplode(Vector3 direction) 
    {
        for (int i = 0; i < _stats.BombRadius; i++)//_radius; i++)
        {
            var rayDir = transform.position + direction * (i + 1);
            var obstacleResult = Physics2D.OverlapBox(rayDir, Vector2.one * _damageRadius, 0, _obstacleMask);

            if (obstacleResult != null)
            {
                break;
            }

            var explodableResult = Physics2D.OverlapBox(rayDir, Vector2.one * _damageRadius, 0, _explodableMask);

            if (explodableResult != null) 
            {
                if (explodableResult.TryGetComponent<IExplodable>(out var explodable)) 
                {
                    explodable.Explode();
                }
                //CreateExplode(rayDir);
                break;
            }

            CreateExplode(rayDir);
        }
    }

    private Explode CreateExplode(Vector3 position) 
    {
        return _factory.InstantiatePrefab(_explode, position, Quaternion.identity);
    } 
}
