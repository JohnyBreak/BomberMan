using System.Collections;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;

    private WaitForSeconds _sleepTime;

    void Start()
    {
        _sleepTime = new WaitForSeconds(0.2f);
        StartCoroutine(CollectRoutine());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator CollectRoutine()
    {
        while (true)
        {
            yield return _sleepTime;

            var result = Physics2D.OverlapBox(transform.position, Vector2.one * 0.9f, 0, _mask);

            if (result == null)
            {
                continue;
            }

            if (result.TryGetComponent(out ICollectable collectable))
            {
                collectable.Collect();
            }
        }
    }
}
