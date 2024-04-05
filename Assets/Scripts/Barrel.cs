using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField] private GameObject _explode;
    [SerializeField] private int _radius = 2;
    [SerializeField]  private LayerMask _mask;

    public void Init(Field field)
    {
        StartCoroutine(WaitRoutine());
    }

    private IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        Explode();
    }

    private void Explode() 
    {
        Destroy(gameObject);
        Instantiate(_explode, transform.position, Quaternion.identity);

        for (int i = 0; i < _radius; i++)
        {
            var rayDir = transform.position + Vector3.up * i;
            var result = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _mask);
            if (result == null) 
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.right * i;

            result = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _mask);
            if (result == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.down * i;

            result = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _mask);
            if (result == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }

            rayDir = transform.position + Vector3.left * i;

            result = Physics2D.OverlapBox(rayDir, Vector2.one * 0.9f, 0, _mask);
            if (result == null)
            {
                Instantiate(_explode, rayDir, Quaternion.identity);
            }
        }
    }
}
