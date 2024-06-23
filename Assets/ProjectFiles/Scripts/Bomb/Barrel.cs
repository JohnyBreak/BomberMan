using GameState;
using System.Collections;
using UnityEngine;
using Zenject;

public class Barrel : MonoBehaviour, IExplodable
{
    [SerializeField] private BoxCollider2D _boxCollider;
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private float _damageRadius = .8f;
    [SerializeField] private DamagingObject _explode;
    [SerializeField] private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _explodableMask;
    [SerializeField] private string _explodeClipName;

    private Coroutine _waitRoutine;
    private GameObjectFactory _factory;
    private PlayerStats _stats;
    private AudioManager _audioManager;
    private AudioDB _audioDB;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(
        GameObjectFactory factory, 
        PlayerStats stats, 
        AudioManager audioManager,
        AudioDB audioDB,
        GameStateMachine gameStateMachine)
    {
        _factory = factory;
        _stats = stats;
        _audioManager = audioManager;
        _audioDB = audioDB;
        _gameStateMachine = gameStateMachine;
    }

    public void Explode()
    {
        if (_waitRoutine != null)
        {
            StopCoroutine(_waitRoutine);
            _waitRoutine = null;
        }

        Destroy(gameObject);


        SpawnExplode(Vector3.up);
        SpawnExplode(Vector3.right);
        SpawnExplode(Vector3.down);
        SpawnExplode(Vector3.left);

        CreateExplode(transform.position);

        _audioManager.PlayOneShot(_audioDB.GetClip(_explodeClipName));

        _stats.ReturnBomb();
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
        //yield return new WaitForSeconds(_lifeTime);
        float time = 0;
        while (time < _lifeTime)
        {
            if (_gameStateMachine.IsCurrentState<GamePlayState>() == false)
            {
                yield return null;
                continue;
            }

            time += Time.deltaTime;

            yield return null;
        }

        Explode();
    }

    private void SpawnExplode(Vector3 direction) 
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

    private DamagingObject CreateExplode(Vector3 position) 
    {
        return _factory.InstantiatePrefab(_explode, position, Quaternion.identity);
    } 
}
