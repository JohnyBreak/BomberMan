using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IExplodable
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private Explode _explode;
    [SerializeField] private int _radius = 2;
    [SerializeField]  private LayerMask _obstacleMask;
    [SerializeField] private LayerMask _explodableMask;

    private Coroutine _waitRoutine;

    public void Init(Field field)
    {
        _waitRoutine = StartCoroutine(WaitRoutine());
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

        Instantiate(_explode, transform.position, Quaternion.identity);
        //for (int i = 0; i < _radius; i++)
        //{
        //    var rayDir = transform.position + Vector3.up * (i + 1);
        //    var result = Physics2D.Linecast(transform.position, rayDir, _obstacleMask);
        //    if (result.collider == null) 
        //    {
        //        Instantiate(_explode, rayDir, Quaternion.identity);
        //    }

        //    rayDir = transform.position + Vector3.right * (i + 1);
        //    result = Physics2D.Linecast(transform.position, rayDir, _obstacleMask);
        //    if (result.collider == null)
        //    {
        //        Instantiate(_explode, rayDir, Quaternion.identity);
        //    }

        //    rayDir = transform.position + Vector3.down * (i + 1);

        //    result = Physics2D.Linecast(transform.position, rayDir, _obstacleMask);
        //    if (result.collider == null)
        //    {
        //        Instantiate(_explode, rayDir, Quaternion.identity);
        //    }

        //    rayDir = transform.position + Vector3.left * (i + 1);
        //    result = Physics2D.Linecast(transform.position, rayDir, _obstacleMask);
        //    if (result.collider == null)
        //    {
        //        Instantiate(_explode, rayDir, Quaternion.identity);
        //    }
        //}
    }

    private void spawnExplode(Vector3 direction) 
    {
        for (int i = 0; i < _radius; i++)
        {
            var rayDir = transform.position + direction * (i + 1);
            var obstacleResult = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _obstacleMask);
            //var result = Physics2D.Linecast(transform.position, rayDir, _obstacleMask);
            if (obstacleResult != null)
            {
                break;
            }

            var explodableResult = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _explodableMask);

            if (explodableResult != null) 
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
                break;
            }

            Instantiate(_explode, rayDir, Quaternion.identity);
        }
    }
}
