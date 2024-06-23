using UnityEngine;

public class EnemyHealth : MonoBehaviour, IExplodable
{
    [SerializeField] private GameObject _rootObject;

    public void Explode()
    {
        Destroy(_rootObject);
    }
}
