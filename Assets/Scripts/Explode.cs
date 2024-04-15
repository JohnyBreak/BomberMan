using System.Collections;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    [SerializeField]  private LayerMask _mask;

    private void Start()
    {
        StartCoroutine(WaitRoutine());

        var result = Physics2D.OverlapBox(transform.position, Vector2.one * 0.9f, 0, _mask);

        if (result == null) 
        {
            return;
        }

        if (result.TryGetComponent(out IExplodable explodable)) 
        {
            explodable.Explode();
        }
    }

    private IEnumerator WaitRoutine()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }
}
