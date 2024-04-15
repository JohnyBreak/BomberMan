using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour, IExplodable
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private Explode _explode;
    [SerializeField] private int _radius = 2;
    [SerializeField]  private LayerMask _mask;
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
        Instantiate(_explode, transform.position, Quaternion.identity);

        for (int i = 0; i < _radius; i++)
        {
            var rayDir = transform.position + Vector3.up * (i + 1);
            var result = Physics2D.Linecast(transform.position, rayDir, _mask);
            if (result.collider == null) 
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.right * (i + 1);
            result = Physics2D.Linecast(transform.position, rayDir, _mask);
            if (result.collider == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.down * (i + 1);
            
            result = Physics2D.Linecast(transform.position, rayDir, _mask);
            if (result.collider == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.left * (i + 1);
            result = Physics2D.Linecast(transform.position, rayDir, _mask);
            if (result.collider == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }
        }
    }
}
