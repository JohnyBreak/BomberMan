using System.Collections;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 3;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
